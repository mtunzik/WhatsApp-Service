import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-nav-bar',
  templateUrl: './nav-bar.component.html',
  styleUrls: ['./nav-bar.component.css'],
})
export class NavBarComponent implements OnInit {
  constructor() {}

  ngOnInit() {}

  toogleSwitch(event: Event): void {
    const element = document.querySelector('body').className;
    if (element == 'open-sidebar-menu') {
      window.document.body.classList.remove('open-sidebar-menu');
    } else {
      window.document.body.classList.add('open-sidebar-menu');
    }
  }
}
