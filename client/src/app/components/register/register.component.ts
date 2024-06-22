import { Component, EventEmitter, Input, Output } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/services/account.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent {
  @Output() cancelEmit:EventEmitter<boolean> = new EventEmitter<boolean>();
  model:any ={}

constructor(private accountServ:AccountService,private toastr:ToastrService){}

  ngOnInit():void{

  }
  register(){
    this.accountServ.register(this.model).subscribe({
      next: response=>{
        console.log(response)
        this.cancel();
      },
      error: error=>{
        console.log(error);
        this.toastr.error(error.error);
      }
    })
  }
  cancel(){
    console.log("cancel");
    this.cancelEmit.emit(false);
  }
}
