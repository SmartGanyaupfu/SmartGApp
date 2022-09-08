import { isPlatformBrowser } from '@angular/common';
import { Inject, Injectable, PLATFORM_ID } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ToastrService } from 'ngx-toastr';

const TOKEN_KEY = 'my-token';
const CURRENT_USER = 'currentUser';
@Injectable({
  providedIn: 'root'
})
export class TokenStorageService {
  constructor(private router:Router,private toastService:ToastrService,
    @Inject(PLATFORM_ID) private platformId) { }

  signOut(): void {
    if(isPlatformBrowser(this.platformId)){
      localStorage.clear();
    }
    this.router.navigate(["auth/login"]);
  }
  public saveToken(token: string): void {
    if(isPlatformBrowser(this.platformId)){
      localStorage.removeItem(TOKEN_KEY);
    localStorage.setItem(TOKEN_KEY, token);
    }
    const user= this.getUser();
    if(user){
      this.saveUser({...user});
    }
  }
  public getToken(): string | null {

    if(isPlatformBrowser(this.platformId)){
      return localStorage.getItem(TOKEN_KEY);
    }
    
  }
  
  public saveUser(user: any): void {
   if(isPlatformBrowser(this.platformId)){
    localStorage.removeItem(CURRENT_USER);
    localStorage.setItem(CURRENT_USER, JSON.stringify(user));
   }
  }
  public getUser(): any {
   if(isPlatformBrowser(this.platformId)){
    const user = localStorage.getItem(CURRENT_USER);
    if (user) {
      return JSON.parse(user);
    }
   }
    return {};
  }
  public getUserRoles(){
    if(isPlatformBrowser(this.platformId)){
     // let decodedToken=this.jwtHelper.decodeToken( this.getToken());
    let userRoles= ['Admin']
  
     return userRoles;
    }
   }
}
