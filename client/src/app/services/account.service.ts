import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { User } from '../models/user';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl:string ="https://localhost:5001/api/";
  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentUsers = this.currentUserSource.asObservable()
  constructor(private http:HttpClient) { }

  public  login(model:any){
    return this.http.post<User>(this.baseUrl + 'account/login',model).pipe(
        map((response:User)=>{
            const user = response;
            if(user){
              localStorage.setItem('user',JSON.stringify(user))
              this.currentUserSource.next(user);
            }
        })
    );
  }

  public register(model:any){
    return this.http.post<User>(this.baseUrl + "account/register",model).pipe(
      map(user=>{
        if(user){
          localStorage.setItem('user',JSON.stringify(user));
          this.currentUserSource.next(user);
        }
        return user;
      })
    )
  }

  logout(){
    localStorage.removeItem('user');
    this.currentUserSource.next(null);

  }

  setCurrentUser(user:User){
    this.currentUserSource.next(user);
  }
}
