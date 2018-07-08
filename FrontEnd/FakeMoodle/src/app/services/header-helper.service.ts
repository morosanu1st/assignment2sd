import { Injectable } from '@angular/core';
import { Headers } from "@angular/http";
@Injectable()
export class HeaderHelperService {

  constructor() { }

  getHeader(): Headers {
    var t = localStorage["token"];
    var authString: string = "Basic " + localStorage["token"].toString();
    var headers: Headers = new Headers();
    headers.append("Content-Type", "application/json");
    headers.append("Authorization", authString);
    return headers;
  }
}
