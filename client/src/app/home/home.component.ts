import { Component, OnInit } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  registerMode: Boolean = false;
  constructor(private accountService: AccountService) {}

  ngOnInit(): void {}
  registerToggle() {
    this.registerMode = !this.registerMode;
  }
  cancelRegistrationMode(event: boolean) {
    this.registerMode = event;
  }
}
