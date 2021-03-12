import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { ReplaySubject } from 'rxjs';
import { User } from './_models/user';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  baseUrl = 'http://localhost:5000/api/';
  private currentUserSource$ = new ReplaySubject<User>(1);

  constructor(private http: HttpClient) {}
  login(model: any) {
    return this.http.post(this.baseUrl + 'auth/login', model).pipe(
      map((response: User) => {
        const user = response;
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource$.next(user);
        }
      })
    );
  }

  signup(model:any) {
    return this.http.post(this.baseUrl + 'auth/register', model).pipe(
      map((response: any) => {
        console.log(response);
      })
    );
  }

  resetpassword(model: any) {
    console.log('reset password here');
  }

  logout() {
    localStorage.removeItem('user');
  }


   setCurrentuser(model: any){
    
   }
}
