import { Component, OnInit } from '@angular/core';
import { LaboratoryModel } from '../../models/laboratory';
import { Http, RequestOptionsArgs } from '@angular/http';
import { Router } from '@angular/router';
import { HeaderHelperService } from '../../services/header-helper.service';
import { environment } from '../../../environments/environment';

@Component({
  selector: 'app-laboratories',
  templateUrl: './laboratories.component.html',
  styleUrls: ['./laboratories.component.css']
})
export class LaboratoriesComponent implements OnInit {
  labs: LaboratoryModel[];
  siteUrl:string;
  constructor(private http: Http, private router: Router, private headerHelper: HeaderHelperService) { }

  ngOnInit() {
    var opts: RequestOptionsArgs = { headers: this.headerHelper.getHeader() } as RequestOptionsArgs;
    this.siteUrl=environment.APIUrl;
    this.http.get(this.siteUrl+ "api/user/laboratory", opts).subscribe(response => {
      if (response.status / 100 == 4 || response.status / 100 == 5) {
        this.router.navigate(["/login"]);
      }
      if (response.text() == null) {
        console.log("something went wrong");
      }
      else {
        this.handleResponse(response);
      }
    },
      error => {
        if (error.status == 401) {
          this.router.navigate(["/login"]);
        }
        console.log(error.toString())
      });
  }

  handleResponse(response) {
    this.labs = JSON.parse(response.text());
  }

}
