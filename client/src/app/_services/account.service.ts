import { HttpClient, HttpHeaders } from '@angular/common/http';
import { isNull } from '@angular/compiler/src/output/output_ast';
import { Injectable } from '@angular/core';
import { Observable, ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { serviceResponse } from '../_models/serviceResponse';
import { User } from '../_models/user';

@Injectable({
  providedIn: 'root',
})
export class AccountService {
  baseUrl: string = 'https://localhost:44332/api/';
  private currentUserSource: any = new ReplaySubject<User>(1);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) {}

  login(model: any) {
    return this.http
      .post<User>(this.baseUrl + 'Account/login', model)
      .pipe<any>(
        map((response: any) => {
          const user = response.data;
          if (user) {
            localStorage.setItem('user', JSON.stringify(user));
            this.currentUserSource.next(user);
            return user;
          }
        })
      );
  }
  register(model: any) {
    return this.http
      .post<User>(this.baseUrl + 'Account/register', model)
      .pipe<any>(
        map((response: any) => {
          const user = response.data;
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
          return user;
        })
      );
  }
  setCurrentUser(user: User) {
    this.currentUserSource.next(user);
  }
  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
  getUsers() {
    return this.http.get<serviceResponse>(this.baseUrl + 'users');
  }
}
