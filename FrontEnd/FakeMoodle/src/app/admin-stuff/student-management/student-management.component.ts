import { Component, OnInit } from '@angular/core';
import { UserModel } from '../../models/user-model';
import { RequestOptionsArgs, Http } from '@angular/http';
import { HeaderHelperService } from '../../services/header-helper.service';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-student-management',
  templateUrl: './student-management.component.html',
  styleUrls: ['./student-management.component.css']
})
export class StudentManagementComponent implements OnInit {
  students: UserModel[];
  searchCriteria:string;
  newStudent: UserModel;
  token:string;
  editStudent: UserModel;
  constructor(private headerHelper: HeaderHelperService, private http: Http) { }

  ngOnInit() {
    this.newStudent = { Id: 0 };
    this.editStudent = { Id: 0 };
    this.searchCriteria="";
    var opts: RequestOptionsArgs = { headers: this.headerHelper.getHeader() } as RequestOptionsArgs;
    this.http.get(environment.APIUrl + "/api/admin/student", opts).subscribe(response => {
      console.log(response.text());
      this.students = JSON.parse(response.text()) as UserModel[];
    });
  }

  deleteStudent(id:number){
    var opts: RequestOptionsArgs = { headers: this.headerHelper.getHeader() } as RequestOptionsArgs;
    this.http.delete(environment.APIUrl + "/api/admin/student/?id="+id, opts).subscribe(response => {
      window.alert("student deleted");
      window.location.reload();
    })
  }

  createStudent(){
    var opts: RequestOptionsArgs = { headers: this.headerHelper.getHeader() } as RequestOptionsArgs;
    this.http.post(environment.APIUrl + "/api/admin/student",this.newStudent, opts).subscribe(response => {
      this.token=response.text();
    },error=>console.log(error))
  }

  search(){
    console.log(this.searchCriteria);
    var opts: RequestOptionsArgs = { headers: this.headerHelper.getHeader() } as RequestOptionsArgs;
    this.http.get(environment.APIUrl + "api/admin/student/search/"+this.searchCriteria, opts).subscribe(response => {
      console.log(response.text());
      this.students = JSON.parse(response.text()) as UserModel[];
    });
  }
}
