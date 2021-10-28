import { HttpClient } from '@angular/common/http';
import { Component, Injectable, OnInit } from '@angular/core';
import { serviceResponse } from './Models/serviceResponse';
@Injectable({
  providedIn: 'root',
})
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
})
export class AppComponent implements OnInit {
  title: string = "Friend's Beep";
  users: any;
  constructor(private http: HttpClient) {}
  ngOnInit(): void {
    this.getUsers();
  }
  getUsers() {
    this.http
      .get<serviceResponse>('https://localhost:44332/api/Users')
      .subscribe(
        (response: any) => {
          this.users = response.data;
          console.log("data----->",this.users);
        },
        (error: any) => {
          console.log(error);
        }
      );
  }
}
