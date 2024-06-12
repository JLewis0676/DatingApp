import { Component, OnInit } from '@angular/core';
import { AccountService } from '../../../services/account.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {
  model:any ={};
  loggedIn = false;
  constructor(private accountServ:AccountService){

  }
  ngOnInit(): void {
    this.getCurrentUser();
  }

  getCurrentUser(){
    this.accountServ.currentUsers.subscribe({
      next: user=>this.loggedIn = !!user,
      error:error=>console.log()
    })
  }
  async login(){
     (await this.accountServ.login(this.model)).subscribe({
      next: response=>{
        console.log(response);
        this.loggedIn = true;
      },
      error: error=>console.log(error)
    })
  }

  logout(){
    this.accountServ.logout();
    this.loggedIn = false;
  }
}
