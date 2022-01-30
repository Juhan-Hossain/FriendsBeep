import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@microsoft/signalr';

@Component({
  selector: 'app-test-errors',
  templateUrl: './test-errors.component.html',
  styleUrls: ['./test-errors.component.css'],
})
export class TestErrorsComponent implements OnInit {
  baseUrl: string = 'https://localhost:44332/api/';

  constructor(private http: HttpClient) {}

  ngOnInit(): void {}
  get500Error() {
    this.http.get(this.baseUrl + 'Buggy/server-error').then(
      (res) => {
        console.log(res);
      },
      (er) => {
        console.log(er);
      }
    );
  }
}
