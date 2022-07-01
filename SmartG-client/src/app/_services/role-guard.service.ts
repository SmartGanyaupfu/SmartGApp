import { Injectable } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { TokenStorageService } from './token-storage.service';

@Injectable({
  providedIn: 'root'
})
export class RoleGuardService {
  allowedRoles:string[]= ['Editor','Admin'];
  constructor(private tokenService:TokenStorageService,private toast:ToastrService){}
  async canActivate() {
    let hasAccess=this.CheckAccess();
    if(!hasAccess){
      this.toast.error('No permission', 'Not Authorized')
    }
  return hasAccess;
}
CheckAccess(){
  let hasAccess:boolean=false;
  let data:string[]= [];

  if(this.tokenService.getUserRoles()==='Admin' || this.tokenService.getUserRoles()==='Editor')
  {
    hasAccess=true;
  }

  
  if(Array.isArray(data)){
    if ( data.find(rols => rols === 'Admin' ) ||data.find(rols => rols === 'Editor' )) {
     
      hasAccess=true;
  }
    
  }
  return hasAccess;
}
}
