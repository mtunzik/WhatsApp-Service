
import { HttpClient } from '@angular/common/http';
import { Component, OnInit,ViewEncapsulation } from '@angular/core';
import { Router } from '@angular/router';
import { ReplaySubject } from 'rxjs';
import { map } from 'rxjs/operators';
import { AuthService } from 'src/app/core/auth/auth.service';
import { User } from 'src/app/core/auth/_models/user';


@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  encapsulation: ViewEncapsulation.None
})
export class LoginComponent implements OnInit {
  model: any = {};
 
  constructor(private router : Router,private authService : AuthService) {}

  ngOnInit() {}

  login() {
    this.authService.login(this.model).subscribe(
      (response) => {
        console.log(response);
        //this.authService.authToken = response.toString() ;
        this.router.navigate(['/home']);
      },
      (error) => {
        console.log(error);
      }
    );
  }

  setCurrentUser(user : User){
    localStorage.removeItem('user');
  }

  logout(){
    console.log('logout');
  }

  resetpassword(){
    this.router.navigate(['/auth/reset-password']);
  }




}
