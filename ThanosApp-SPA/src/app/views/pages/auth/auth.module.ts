import { ModuleWithProviders, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';

//Module Components
import { AuthComponent } from './auth.component';
import { LoginComponent } from './login/login.component';
import { ForgotPasswordComponent } from './forgot-password/forgot-password.component';
import { RegisterComponent } from './register/register.component';
import { RouterModule,Routes } from '@angular/router';

//Auth
import { AuthService } from '../../../core/auth/auth.service';


const routes:  Routes = [
  {path: '', component : AuthComponent,
  children : [
    {
      path: '',
      redirectTo : 'login',
      pathMatch : 'full'
    },
    {
      path : 'login',
      component : LoginComponent,
      data : {returnUrl: window.location.pathname}
    },
    {
      path : 'forgot-password',
      component : ForgotPasswordComponent
    }
  ]

}
];

@NgModule({
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forChild(routes),
    TranslateModule.forChild()
  ],
  providers : [],
  exports: [AuthComponent, RouterModule,FormsModule],
  declarations: [AuthComponent, LoginComponent, ForgotPasswordComponent, RegisterComponent]
})
export class AuthModule {
  static forRoot() : ModuleWithProviders<any>{
		return {
			ngModule: AuthModule,
      providers: [
				AuthService
			]
		};
    }	
 }
