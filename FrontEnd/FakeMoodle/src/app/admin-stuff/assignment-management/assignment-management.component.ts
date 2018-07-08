import { Component, OnInit } from '@angular/core';
import { HeaderHelperService } from '../../services/header-helper.service';
import { Http, RequestOptionsArgs } from '@angular/http';
import { AssignmentModel } from '../../models/assignment';
import { environment } from '../../../environments/environment';
import { LaboratoryModel } from '../../models/laboratory';

@Component({
  selector: 'app-assignment-management',
  templateUrl: './assignment-management.component.html',
  styleUrls: ['./assignment-management.component.css']
})
export class AssignmentManagementComponent implements OnInit {

  assignments: AssignmentModel[];
  labs: LaboratoryModel[];
  searchCriteria: string;
  newAssignment: AssignmentModel;
  token: string;
  editAssignment: AssignmentModel;
  constructor(private headerHelper: HeaderHelperService, private http: Http) { }

  ngOnInit() {
    this.newAssignment = { Id: 0 };
    this.editAssignment = { Id: 0 };
    this.searchCriteria = "";
    var opts: RequestOptionsArgs = { headers: this.headerHelper.getHeader() } as RequestOptionsArgs;
    this.http.get(environment.APIUrl + "/api/admin/Assignment", opts).subscribe(response => {
      console.log(response.text());
      this.assignments = JSON.parse(response.text()) as AssignmentModel[];
      this.http.get(environment.APIUrl + "/api/admin/laboratory", opts).subscribe(response => {
        console.log(response.text());
        this.labs = JSON.parse(response.text()) as LaboratoryModel[];
      });
    });

  }

  deleteAssignment(id: number) {
    var opts: RequestOptionsArgs = { headers: this.headerHelper.getHeader() } as RequestOptionsArgs;
    this.http.delete(environment.APIUrl + "/api/admin/Assignment/?id=" + id, opts).subscribe(response => {
      window.alert("Assignment deleted");
      window.location.reload();
    })
  }

  createAssignment() {
    var opts: RequestOptionsArgs = { headers: this.headerHelper.getHeader() } as RequestOptionsArgs;
    this.http.post(environment.APIUrl + "/api/admin/Assignment", this.newAssignment, opts).subscribe(response => {
      window.alert("lab created");
      window.location.reload();
    }, error => console.log(error))
  }

  search() {
    console.log(this.searchCriteria);
    var opts: RequestOptionsArgs = { headers: this.headerHelper.getHeader() } as RequestOptionsArgs;
    this.http.get(environment.APIUrl + "api/admin/Assignment/search/" + this.searchCriteria, opts).subscribe(response => {
      console.log(response.text());
      this.assignments = JSON.parse(response.text()) as AssignmentModel[];
    });
  }

}
