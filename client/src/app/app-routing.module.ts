import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { MemberListComponent } from './components/memebers/member-list/member-list.component';
import { MemberDetailComponent } from './components/memebers/member-detail/member-detail.component';
import { ListsComponent } from './components/lists/lists.component';
import { MessagesComponent } from './components/messages/messages.component';
import { authGuard } from './components/_guards/auth.guard';

const routes: Routes = [
  {path:'', component:HomeComponent},
  {path: '',
    runGuardsAndResolvers:'always',
    canActivate: [authGuard],
    children:[
      {path:'members', component:MemberListComponent},
      {path:'members/:id', component:MemberDetailComponent},
      {path:'lists', component:ListsComponent},
      {path:'messages', component:MessagesComponent},
      {path:'**',component:HomeComponent,pathMatch:'full'}
    ]
  }
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { 
  
}
