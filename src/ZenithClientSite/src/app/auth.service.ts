import { Injectable } from '@angular/core';
import { AuthHttp, AuthConfig, AUTH_PROVIDERS } from 'angular2-jwt';

@Injectable()
export class AuthService {

  constructor(public authHttp: AuthHttp) { }

  data;

  Login() {
    var creds = {
      username: "a",
      password: "P@$$w0rd",
    }
    // this uses authHttp, instead of http
    this.authHttp.post('http://localhost:54675/api/authApi/Login', creds)
      .subscribe(
        data => this.data = data,
        err => console.log(err),
        () => console.log(this.data)
      );
  }
}
