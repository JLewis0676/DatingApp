import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AccountService {
  baseUrl:string ="https://localhost:5001/api/";
  constructor(private http:HttpClient) { }

  public async login(model:any){
    return this.http.post(this.baseUrl + 'account/login',model);
  }
}
