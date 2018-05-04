import { Injectable } from '@angular/core';

@Injectable()
export class AuthService {

  constructor() { }

  public isAuthenticated(): boolean {
    const token = localStorage['token'];
    console.log(token);

    // Check whether the token is expired and return
    // true or false
    return token!="null";
  }

}
