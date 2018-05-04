import { Component, OnInit } from '@angular/core';
import { UserModel } from '../models/user-model';
import { Http, Request, RequestOptionsArgs, RequestOptions, ResponseContentType, Headers } from '@angular/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit {
  public userModel: UserModel;
  constructor(private http: Http, private router: Router) { }

  ngOnInit() {
    this.userModel = { Email: "", PasswordHash: "" };
    localStorage["token"] = null;
  }

  onSubmit() {
    var token = "";
    var headers: Headers = new Headers();
    headers.append("Content-Type", "application/json");
    var opts: RequestOptionsArgs = { headers: headers } as RequestOptionsArgs;
    this.http.post("http://mchindris-win:6854/api/Login", this.userModel, opts).subscribe(response => {
      if (response.text == null) {
        console.log("username or password incorrect");

      }
      else {
        localStorage["token"] = response.text;
        this.router.navigate(["/home"]);
      }
    },
      error => {
        console.log(error.toString())
      });
  }

}
