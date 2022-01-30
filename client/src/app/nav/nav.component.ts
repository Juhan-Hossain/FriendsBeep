import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { User } from '../_models/user';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
})
export class NavComponent implements OnInit {
  model: any = {};
  loggedIn: boolean;
  userName: any;

  constructor(
    public accountService: AccountService,
    private router: Router,
    private toastr: ToastrService
  ) {}

  ngOnInit(): void {
    this.getCurrentUser();
  }
  login() {
    this.accountService.login(this.model).subscribe(
      (response): any => {
        this.loggedIn = true;
        this.userName = response.userName;
        this.router.navigateByUrl('/friends');

        this.toastr.success('Welcome ' + this.userName);
      }
      // (error) => {
      //   this.toastr.error(error.error.message);
      // }
    );
  }
  logOut() {
    this.accountService.logout();
    this.loggedIn = false;
    this.router.navigateByUrl('/');
  }
  getCurrentUser() {
    this.accountService.currentUser$.subscribe(
      (user: User) => {
        this.loggedIn = !!user;
      },
      (error: any) => {
        console.log(error);
      }
    );
  }
}
