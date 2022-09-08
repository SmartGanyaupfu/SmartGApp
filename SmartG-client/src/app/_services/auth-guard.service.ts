import { isPlatformBrowser } from '@angular/common';
import { HttpClient } from '@angular/common/http';
import { Inject, Injectable, PLATFORM_ID } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ToastrService } from 'ngx-toastr';
import { lastValueFrom } from 'rxjs';
import { environment } from 'src/environments/environment';
import { AuthService } from './auth.service';
import { TokenStorageService } from './token-storage.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuardService {
  constructor(private authenticationService:AuthService, private router: Router, 
    private jwtHelper:JwtHelperService, private http:HttpClient, private toastrService:ToastrService,
    private tokenService:TokenStorageService, @Inject (PLATFORM_ID) private platformId) {
  }
  baseUrl:string= environment.baseUrl;
  

  async canActivate() {
 if(isPlatformBrowser(this.platformId)){
  const token = this.tokenService.getToken();
  if (token && !this.jwtHelper.isTokenExpired(token)) {
  
    return true;
  }
  const isRefreshSuccess = await this.tryRefreshingTokens(token);
  if (!isRefreshSuccess) {
  this.tokenService.signOut();
  this.toastrService.error('Your Session has expired, please log in again','Invalid session token!');
    this.router.navigate(["auth/login"]);
  }
  return isRefreshSuccess;
 }
  }
  private async tryRefreshingTokens(token: string): Promise<boolean> {
   if(isPlatformBrowser(this.platformId)){
     // Try refreshing tokens using refresh token
     const tokenDto: string = this.tokenService.getUser();
     if (!token || !tokenDto) { 
       return false;
     }
   
     let isRefreshSuccess: boolean;
     try {
       const response = await lastValueFrom(this.http.post(this.baseUrl+ 'Token/refresh',tokenDto));
       const newToken = (<any>response).accessToken;
       const  newUser = (<any>response);
       
     this.tokenService.saveToken(newToken);
       this.tokenService.saveUser(newUser)
       isRefreshSuccess = true;
     }
     catch (ex) {      
       isRefreshSuccess = false;
     }
     return isRefreshSuccess;
   }
    
  }
}
