import { Component, OnInit } from '@angular/core';
import { UserModel } from '../models/user-model';
import { Http, Request, RequestOptionsArgs, RequestOptions, ResponseContentType, Headers } from '@angular/http';
import { Router } from '@angular/router';
import { environment } from '../../environments/environment';
import { RegisterModel } from '../models/register-model';
import {Md5} from 'ts-md5/dist/md5';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  public userModel: UserModel;
  public registrationModel: RegisterModel;
  constructor(private http: Http, private router: Router) { }

  ngOnInit() {
    this.userModel = { Email: "", PasswordHash: "" };
    this.registrationModel = { Email: "", PasswordHash: "", Token: "" };
    localStorage["token"] = null;
    localStorage["isAdmin"] = false;
  }

  login() {
    var token = "";
    var headers: Headers = new Headers();
    headers.append("Content-Type", "application/json");
    var opts: RequestOptionsArgs = { headers: headers } as RequestOptionsArgs;
    var body=Md5.hashStr(this.userModel.PasswordHash) as string;
    var payload= {Email: this.userModel.Email, PasswordHash: body };
    this.http.put(environment.APIUrl + "api/Login", JSON.stringify(payload), opts).subscribe(response => {
      if (response.text() == "null") {
        console.log("mail or password incorrect");

      }
      else {
        var token = response.text();
        token = token.substring(1, token.length - 1);
        localStorage["token"] = token;
        this.router.navigate(["/home"]);
      }
    },
      error => {
        console.log(error.toString())
      });
  }

  register() {
    var token = "";
    var headers: Headers = new Headers();
    headers.append("Content-Type", "application/json");
    var opts: RequestOptionsArgs = { headers: headers } as RequestOptionsArgs;
    var body=Md5.hashStr(this.registrationModel.PasswordHash) as string;
    var payload= {Email: this.registrationModel.Email, PasswordHash: body,Token:this.registrationModel.Token };
    this.http.put(environment.APIUrl + "api/register", JSON.stringify(payload), opts).subscribe(response => {
      if (response.status<200||response.status>=400){
        console.log("somethings wrong with your credentials");
        return;
      }
      if (response.text() == "null") {
        console.log("mail, token or password incorrect");
      }
      else {
        var token = response.text();
        token = token.substring(1, token.length - 1);
        localStorage["token"] = token;
        this.router.navigate(["/home"]);
      }
    },
      error => {
        console.log("das ist eninen errot"+error.toString())
      });
  }


}
