import { isPlatformBrowser } from '@angular/common';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Inject, Injectable, PLATFORM_ID } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { CustomEncoder } from '../shared/custom-encoder/custom-encoder';
import { JwtUser } from '../_interfaces/jwt-user';
import { User } from '../_interfaces/user';
import { UserForRegistration } from '../_interfaces/user-for-registration';
import { TokenStorageService } from './token-storage.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  url=environment.baseUrl;
  helper = new JwtHelperService();
  private readonly token = "my-token";
  private readonly currentUser= "currentUser";
  
  constructor(private http:HttpClient,private router:Router,private tokenStorageService:TokenStorageService, @Inject (PLATFORM_ID) private platformId) { }
    getAllUsers(){
      return this.http.get<User[]>(this.url+'authentication/get-all-users');
    }
  
    createUser(user:UserForRegistration){
      return this.http.post<UserForRegistration>(this.url +'authentication/register',user);
    }
    updateUser(user:User, userId:string){
      return this.http.put<User>(this.url +'authentication/'+userId,user)
    }
  
  login(model:any){
    return this.http.post(this.url + 'authentication/login', model).pipe(
      map((response:JwtUser)=>{
        const user = response;
        
        if(user){
          
          
         if(isPlatformBrowser(this.platformId)){
          this.tokenStorageService.saveToken(user.accessToken);
          this.tokenStorageService.saveUser(user);
         }
         
          return user;
        }
  
      })
    );
  }
  
  loggedIn(): boolean {
    if(isPlatformBrowser(this.platformId)){
      const token = localStorage.getItem('my-token');
    
    return !this.helper.isTokenExpired(token);
    }
  }
  
  public logout = () => {
    if(isPlatformBrowser){
      localStorage.removeItem('my-token');
     localStorage.removeItem('currentUser');
     this.router.navigate(['auth/login'])
    }
     
     
   }
  
  forgotPassword(model:any){
    return this.http.post(this.url + 'authentication/forgotpassword', model);
  }
  
  resetPassword(model:any){
    return this.http.post(this.url + 'authentication/resetpassword', model);
  }
  getEmailConfirmation(token:any, email:any){
   
   let params= new HttpParams({encoder:new CustomEncoder});
    params = params.append('token', token);
    params = params.append('email', email);
    return this.http.get(this.url+'authentication/EmailConfirmation',{params});
  }
  
  getUserById(id:any){
    return this.http.get(this.url+'authentication/get-user/'+id);
  }
  delete(id:any){
    return this.http.delete(this.url+'authentication/delete-user/'+id);
  }
  
  refreshToken(user:any){
  
    return this.http.post(this.url+ 'Token/refresh', user)
      
   }
   getJwtToken() {
   if(isPlatformBrowser(this.platformId)){
    return localStorage.getItem(this.token);
   }
  }
}
