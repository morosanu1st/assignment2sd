import { Component, OnInit } from '@angular/core';
import { HeaderHelperService } from '../../services/header-helper.service';
import { Http, RequestOptionsArgs } from '@angular/http';
import { AssignmentModel } from '../../models/assignment';
import { SubmissionModel } from '../../models/submission';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-grading',
  templateUrl: './grading.component.html',
  styleUrls: ['./grading.component.css']
})
export class GradingComponent implements OnInit {
  submissions: SubmissionModel[];

  constructor(private headerHelper: HeaderHelperService, private http: Http) { }

  ngOnInit() {
    var opts: RequestOptionsArgs = { headers: this.headerHelper.getHeader() } as RequestOptionsArgs;
    this.http.get(environment.APIUrl + "/api/admin/submissions", opts).subscribe(response => {
      this.submissions = JSON.parse(response.text()) as SubmissionModel[];
      this.submissions.forEach(x => x.isGraded = x.Grade != 0);
    });
  }

  grade(id: number, grade: number) {
    var opts: RequestOptionsArgs = { headers: this.headerHelper.getHeader() } as RequestOptionsArgs;
    this.http.put(environment.APIUrl + "/api/admin/submissions/grade/" + id + "/" + grade, opts).subscribe(response => {
      window.alert("Submission graded");
      window.location.reload();
    }, error => window.alert(error.text()));
  }

}
