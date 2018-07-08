import { Component, OnInit } from '@angular/core';
import { HeaderHelperService } from '../../services/header-helper.service';
import { Http, RequestOptionsArgs } from '@angular/http';
import { LaboratoryModel } from '../../models/laboratory';
import { environment } from '../../../environments/environment';
import { UserModel } from '../../models/user-model';

@Component({
  selector: 'app-lab-management',
  templateUrl: './lab-management.component.html',
  styleUrls: ['./lab-management.component.css']
})
export class LabManagementComponent implements OnInit {
  labs: LaboratoryModel[];
  students:UserModel[];
  searchCriteria: string;
  newLaboratory: LaboratoryModel;
  token: string;
  editLaboratory: LaboratoryModel;
  constructor(private headerHelper: HeaderHelperService, private http: Http) { }

  ngOnInit() {
    this.newLaboratory = { Id: 0 };
    this.editLaboratory = { Id: 0 };
    this.searchCriteria = "";
    var opts: RequestOptionsArgs = { headers: this.headerHelper.getHeader() } as RequestOptionsArgs;
    this.http.get(environment.APIUrl + "/api/admin/laboratory", opts).subscribe(response => {
      console.log(response.text());
      this.labs = JSON.parse(response.text()) as LaboratoryModel[];
      this.http.get(environment.APIUrl + "/api/admin/student", opts).subscribe(response => {
        console.log(response.text());
        this.students = JSON.parse(response.text()) as UserModel[];
      });
    });
    
  }

  deleteLaboratory(id: number) {
    var opts: RequestOptionsArgs = { headers: this.headerHelper.getHeader() } as RequestOptionsArgs;
    this.http.delete(environment.APIUrl + "/api/admin/laboratory/?id=" + id, opts).subscribe(response => {
      window.alert("Laboratory deleted");
      window.location.reload();
    })
  }

  createLaboratory() {
    var opts: RequestOptionsArgs = { headers: this.headerHelper.getHeader() } as RequestOptionsArgs;
    this.http.post(environment.APIUrl + "/api/admin/laboratory", this.newLaboratory, opts).subscribe(response => {
      window.alert("lab created");
      window.location.reload();
    }, error => console.log(error))
  }

  search() {
    console.log(this.searchCriteria);
    var opts: RequestOptionsArgs = { headers: this.headerHelper.getHeader() } as RequestOptionsArgs;
    this.http.get(environment.APIUrl + "api/admin/laboratory/search/" + this.searchCriteria, opts).subscribe(response => {
      console.log(response.text());
      this.labs = JSON.parse(response.text()) as LaboratoryModel[];
    });
  }

  addAttendance(userId: number, labId: number) {
    var opts: RequestOptionsArgs = { headers: this.headerHelper.getHeader() } as RequestOptionsArgs;
    let body = {
      "LabId": labId,
      "StudentId": userId
    }
    this.http.post(environment.APIUrl + "/api/admin/laboratory", body, opts).subscribe(response => {
      window.alert("attendance succesfully created");
    }, error => {
      console.log(error.text());
      window.alert("something went wrong");
    });
  }
}
