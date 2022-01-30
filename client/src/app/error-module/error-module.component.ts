import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-error-module',
  templateUrl: './error-module.component.html',
  styleUrls: ['./error-module.component.css'],
})
export class ErrorModuleComponent implements OnInit {
  baseUrl: string = 'https://localhost:44332/api/';
  validationErrors: string[];

  constructor(private http: HttpClient) {}

  ngOnInit(): void {}
  get500Error() {
    this.http.get(this.baseUrl + 'Buggy/server-error').subscribe(
      (res) => {
        console.log(res);
      },
      (er) => {
        console.log(er);
        this.validationErrors = er;
      }
    );
  }
  get400Error() {
    this.http.get(this.baseUrl + 'Buggy/server-error').subscribe(
      (res) => {
        console.log(res);
      },
      (er) => {
        console.log(er);
        this.validationErrors = er;
      }
    );
  }
}
