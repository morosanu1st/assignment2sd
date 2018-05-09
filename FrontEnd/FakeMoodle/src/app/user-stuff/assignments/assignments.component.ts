import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Router } from '@angular/router';
import { HeaderHelperService } from '../../services/header-helper.service';

@Component({
  selector: 'app-assignments',
  templateUrl: './assignments.component.html',
  styleUrls: ['./assignments.component.css']
})
export class AssignmentsComponent implements OnInit {

  constructor(private http: Http, private router: Router, private headerHelper: HeaderHelperService) { }

  ngOnInit() {
  }

}
