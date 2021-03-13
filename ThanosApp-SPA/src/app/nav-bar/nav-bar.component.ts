import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AuthService } from '../core/auth/auth.service';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css'],
})
export class NavBarComponent implements OnInit {
  constructor(private http : HttpClient, private authservice : AuthService) {}

  ngOnInit() {
    this.getnavbar();
  }


  getnavbar (){
    this.http.get(this.authservice.baseUrl + 'navbar/menu').subscribe( data => {
      console.log(data);
    });
  }

  toogleSwitch(event: Event): void {
    const element = document.querySelector('body').className;
    if (element == 'open-sidebar-menu') {
      window.document.body.classList.remove('open-sidebar-menu');
    } else {
      window.document.body.classList.add('open-sidebar-menu');
    }
  }
}
