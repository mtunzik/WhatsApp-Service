import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-bread-crumbs',
  templateUrl: './bread-crumbs.component.html',
  styleUrls: ['./bread-crumbs.component.css']
})
export class BreadCrumbsComponent implements OnInit {

public constructor(private route: ActivatedRoute, private router: Router) {
    console.log(route.url[0]);
}

  ngOnInit() {
  }

}

 
