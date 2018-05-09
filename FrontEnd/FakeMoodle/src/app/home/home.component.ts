import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserModel } from '../models/user-model';
import { RequestOptionsArgs, Http } from '@angular/http';
import { Headers } from '@angular/http';
import { environment } from '../../environments/environment';
import { HeaderHelperService } from '../services/header-helper.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  public user: UserModel;

  constructor(private http: Http, private router: Router, private headerHelper: HeaderHelperService) { }


  ngOnInit() {
    var t = localStorage.getItem("token");
    this.user = { Email: "No User" };    

    var opts: RequestOptionsArgs = { headers: this.headerHelper.getHeader() } as RequestOptionsArgs;
    this.http.get("http://localhost:65267/api/user/details", opts).subscribe(response => {
      if (response.status / 100 == 4 || response.status / 100 == 5) {
        this.router.navigate(["/login"]);
      }
      if (response.text() == null) {
        console.log("something went wrong");
      }
      else {
        var v = JSON.parse(response.text());
        this.user = {
          Name: v.Name,
          Email: v.Email,
          Hobby: v.Hobby,
          Group: +v.Group,
          Id: +v.Id,
          IsAdmin: v.IsAdmin
        }
        if (this.user.IsAdmin) {
          localStorage["isAdmin"] = true;
        }
      }
    },
      error => {
        if (error.status == 401) {
          this.router.navigate(["/login"]);
        }
        console.log(error.toString())
      });
  }

  logout() {
    var authString: string = "Basic " + localStorage["token"].toString();
    var headers: Headers = new Headers();
    headers.append("Content-Type", "application/json");
    headers.append("Authorization", authString);
    headers.append("withCredentials", "true");
    headers.append("crossDomain", "true");
    var opts: RequestOptionsArgs = { headers: headers } as RequestOptionsArgs;
    this.http.put(environment.APIUrl + "api/logout", "'" + localStorage["token"] + "'", opts).subscribe(response => {
      localStorage["token"] = null;
      this.router.navigate(["/login"]);
    });
  }

}
