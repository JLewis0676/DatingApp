import { inject } from '@angular/core';
import { CanActivateFn } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { map } from 'rxjs';
import { AccountService } from 'src/app/services/account.service';

export const authGuard: CanActivateFn = (route, state) => {
  const accountService = inject(AccountService);
  const toastr = inject(ToastrService);

  
  return accountService.currentUsers.pipe(
    map(user =>{
      if(user)return true;
      else{
        toastr.error("User not logged in")
        return false;
      }
    })
  )
};
