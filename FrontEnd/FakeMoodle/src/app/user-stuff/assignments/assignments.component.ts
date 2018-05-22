import { Component, OnInit } from '@angular/core';
import { Http, RequestOptionsArgs } from '@angular/http';
import { Router, ActivatedRoute } from '@angular/router';
import { HeaderHelperService } from '../../services/header-helper.service';
import { AssignmentModel } from '../../models/assignment';
import { environment } from '../../../environments/environment';
import { SubmissionModel } from '../../models/submission';
import { UserModel } from '../../models/user-model';

@Component({
  selector: 'app-assignments',
  templateUrl: './assignments.component.html',
  styleUrls: ['./assignments.component.css']
})
export class AssignmentsComponent implements OnInit {
  assignments: AssignmentModel[];
  submission: SubmissionModel;
  apiUrl: string;
  id: number;

  constructor(private http: Http, private router: Router, private headerHelper: HeaderHelperService, private route: ActivatedRoute) { }

  ngOnInit() {
    this.submission = { Id: 0, Student: localStorage["user"] as UserModel, Assignment: { Id: this.id }, Link: "", Remarks: "", Grade: 0, Attempt: 0 };
    this.id = 0;
    var opts: RequestOptionsArgs = { headers: this.headerHelper.getHeader() } as RequestOptionsArgs;
    this.route.params.subscribe(params => {
      var v = params["id"];
      v = v.toString();
      var n = Number(v);
      this.id = n;
      this.apiUrl = environment.APIUrl + "api/user/laboratory/" + this.id + "/assignments";
      this.http.get(this.apiUrl, opts).subscribe(response => {
        this.assignments = JSON.parse(response.text()) as AssignmentModel[];
        // this.submissions=Array<Sub>(this.assignments.length);
        // for (let s of this.submissions) {
        //   s = { Id: 0, Student: localStorage["user"] as UserModel, Assignment: { Id: this.id }, Link: "", Remarks: "", Grade: 0, Attempt: 0 };
        // }
      });

    });
  }

  submit(id: Number, submission: SubmissionModel) {
  }


}
