import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { HttpClientModule } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavBarComponent } from './nav-bar/nav-bar.component';
import { SideBarComponent } from './side-bar/side-bar.component';
import { MainPageComponent } from './main-page/main-page.component';
import { RightBarComponent } from './right-bar/right-bar.component';

import { BreadCrumbsComponent } from './nav-bar/bread-crumbs/bread-crumbs.component';
import { ToggleDirective} from './core/_directives/toggle.directive';


@NgModule({
  declarations: [				
    AppComponent,
      NavBarComponent,
      SideBarComponent,
      MainPageComponent,
      RightBarComponent,
      BreadCrumbsComponent,
      ToggleDirective
   ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
