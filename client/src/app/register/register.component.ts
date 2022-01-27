import { error } from '@angular/compiler/src/util';
import {
  Component,
  EventEmitter,
  Input,
  OnDestroy,
  OnInit,
  Output,
} from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { serviceResponse } from '../_models/serviceResponse';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css'],
})
export class RegisterComponent implements OnInit, OnDestroy {
  @Output() cancelRegistration: any = new EventEmitter();
  model: any = {};
  sub: any;

  constructor(
    private accountService: AccountService,
    private toastr: ToastrService
  ) {}
  ngOnInit(): void {}

  register() {
    this.sub = this.accountService.register(this.model).subscribe(
      (response) => {
        this.cancel();
      },
      (err) => {
        console.log(err.error);
        this.toastr.error(err.error);
      }
    );
  }
  cancel() {
    this.cancelRegistration.emit(false);
  }
  ngOnDestroy() {
    if (this.sub) {
      this.sub.unsubscribe();
    }
  }
}
