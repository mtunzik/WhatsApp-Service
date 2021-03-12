import { NgModule } from '@angular/core';
import { PreloadAllModules, RouterModule, Routes } from '@angular/router';
import { from } from 'rxjs';
import { MainPageComponent } from './main-page/main-page.component';
import { ChatComponent } from './views/pages/auth/chat-service/chat/chat.component';
import { SettingsComponent } from './views/pages/auth/settings/settings.component';
 
const routes: Routes = [ 
  {
    path: 'auth', 
    loadChildren: () => 
    import('./views/pages/auth/auth.module').then(m => m.AuthModule)
  },
  {
    path: 'account', 
    loadChildren: () => 
    import('./views/pages/auth/auth.module').then(m => m.AuthModule)
  },
  {
    path: 'home',
    component: MainPageComponent,
    children : [
      {
        path: 'chat-service:',
        component : ChatComponent,
        pathMatch : 'full',
        data : { breadcrumb :  'Home', title : 'Home Page > Chat-Service', url : '/dashboard/chat-service'}
      },
      {
        path: 'chat-service/settings',
        component : SettingsComponent,
        pathMatch : 'full',
        data : { breadcrumb :  'Home > Settings ', title : 'Home Page > Settings', url : '/dashboard/settings/:string'}
      },
      {
        path: 'chat-service/:id',
        component : ChatComponent,
        pathMatch : 'full',
        data : { breadcrumb :  'Home', title : 'Home Page > Chat-Service', url : '/dashboard/chat-service/:string'}
      },
      {
        path: 'chat-service/group-chat/:string',
        component : ChatComponent,
        pathMatch : 'full',
        data : { breadcrumb :  'Home', title : 'Home Page > Chat-Service', url : '/dashboard/chat-service/:string'}
      }
      
    ],
    
  },
  { 
    path: 'home', component: MainPageComponent,
    data : { breadcrumb :  'Home', title : 'Home Page', url : '/home'}
  },
  {
    path: '**', component: MainPageComponent,
    data : { breadcrumb :  'Home', title : 'Home Page', url : '/dashboard'}
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes,{
    preloadingStrategy: PreloadAllModules
  })],
  exports: [RouterModule]
})
export class AppRoutingModule { }

