import { useAnimation } from '@angular/animations';
import { HttpClient } from '@angular/common/http';
import { Component, Injectable, OnInit } from '@angular/core';
import { serviceResponse } from './_models/serviceResponse';
import { User } from './_models/user';
import { AccountService } from './_services/account.service';
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
  constructor(private accountService:AccountService) {}
  ngOnInit(): void {
    // this.getUsers();
    this.setCurrentUser();
  }

  setCurrentUser() {
    const user: User = JSON.parse(localStorage.getItem('user') || '{}');
    this.accountService.setCurrentUser(user);
  }

  // getUsers() {
  //   this.http
  //     .get<serviceResponse>('https://localhost:44332/api/Users')
  //     .subscribe(
  //       (response: any) => {
  //         this.users = response.data;
  //         console.log("data----->",this.users);
  //       },
  //       (error: any) => {
  //         console.log(error);
  //       }
  //     );
  // }
}
