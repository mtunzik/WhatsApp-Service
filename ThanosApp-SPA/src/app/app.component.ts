import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from './core/auth/auth.service';
import { User } from './core/auth/_models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  
  PageTitle = 'ThanosApp-SPA';
  users : any;
   
  constructor(private http: HttpClient,
     private authService: AuthService, 
     private router : Router) {}

  ngOnInit() {
    this.setCurrentUser();
  }

  setCurrentUser(){
    const user: User = JSON.parse(localStorage.getItem('user'));
     if(user){
       this.authService.setCurrentuser(user);
     }
     else 
     {
      this.router.navigate(['/auth/login']);
     }
  }

}
