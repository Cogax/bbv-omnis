import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';

import { JwtHelperService } from '@auth0/angular-jwt';
import { tap } from 'rxjs/operators';

import { EventBusService } from '../event-bus.service';
import { LoginState } from './login.state';

export interface User {
  username: string;
  password: string;
}

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private USERNAME = 'http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name';

  private helper = new JwtHelperService();
  private redirectUrl = '/home';

  constructor(
    private http: HttpClient,
    private router: Router,
    private bus: EventBusService,
    @Inject('baseUrl') private baseUrl: string
  ) {}

  login(username: string, password: string) {
    const url = `${this.baseUrl}/oauth/token`;

    const urlSearchParams = new URLSearchParams();
    urlSearchParams.set('grant_type', 'password');
    urlSearchParams.set('username', username);
    urlSearchParams.set('password', password);

    const body = urlSearchParams.toString();

    const httpOptions = {
      headers: new HttpHeaders({
        Authorization: 'Authorization',
        'Content-Type': 'application/x-www-form-urlencoded'
      })
    };

    return this.http.post<User>(url, body, httpOptions).pipe(
      tap(res => this.setSession(res)),
      tap(res => this.publishUserName(res)),
      tap(() => this.redirect())
    );
  }

  logout() {
    localStorage.removeItem('access_token');
    this.bus.publish('LoginState', LoginState.LoggedOut());
  }

  isLoggedIn() {
    const access_token = localStorage.getItem('access_token');

    if (access_token) {
      return !this.helper.isTokenExpired(access_token);
    }

    return false;
  }

  isLoggedOut() {
    return !this.isLoggedIn();
  }

  userName() {
    const access_token = localStorage.getItem('access_token');

    if (access_token) {
      return this.helper.decodeToken(access_token)[this.USERNAME];
    }

    return '';
  }

  getToken() {
    const access_token = localStorage.getItem('access_token');

    if (access_token) {
      return access_token;
    }

    return '';
  }

  saveRedirectUrl(url: string) {
    this.redirectUrl = url;
  }

  private setSession(authResult) {
    localStorage.setItem('access_token', authResult.access_token);
  }

  private publishUserName(authResult) {
    let token = {} as any;
    token = this.helper.decodeToken(authResult.access_token);

    this.bus.publish('LoginState', LoginState.LoggedIn(token[this.USERNAME]));
  }

  private redirect() {
    const url = this.redirectUrl;
    this.redirectUrl = '/home';

    this.router.navigate([url]);
  }
}
