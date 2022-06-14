import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { ToastrService } from 'ngx-toastr';
import { AuthService } from 'src/app/_services/auth.service';
import { MediaService } from 'src/app/_services/media.service';
import { TokenStorageService } from 'src/app/_services/token-storage.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  model:any={};
  logo:string;
  loggedIn:boolean=false;
  constructor(private authenticationService:AuthService, private router:Router,
    private toastr:ToastrService, private tokenService:TokenStorageService,
    private jwtHelper:JwtHelperService, private mediaService:MediaService) { }

  ngOnInit(): void {
    //this.getCurrentUser();
    this.logo=this.mediaService.logoUrl;
  }

  login(){
    this.authenticationService.login(this.model).subscribe(response=>{
    
      this.router.navigate(['home']);
    }
    );  
  }
  getCurrentUser(){
   this.loggedIn= this.authenticationService.loggedIn();
    if (this.loggedIn){
      this.router.navigate(['home']);
    }
  }
  

}
