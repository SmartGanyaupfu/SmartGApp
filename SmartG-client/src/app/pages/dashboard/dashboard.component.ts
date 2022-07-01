import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSidenav } from '@angular/material/sidenav';
import { BreakpointObserver } from '@angular/cdk/layout';
import { AuthService } from 'src/app/_services/auth.service';
import { TokenStorageService } from 'src/app/_services/token-storage.service';

@Component({
  selector: 'app-dashboard',
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.css']
})
export class DashboardComponent implements OnInit {
  @ViewChild(MatSidenav) sidenav!:MatSidenav;
show:boolean=false;
  constructor(public observer: BreakpointObserver, private authService:AuthService,public tokenService:TokenStorageService) { }

  ngOnInit(): void {
    this.signedIn();
  }
  ngAfterViewInit() {
    setTimeout(()=>{
      this.getViewPort();
    },0)
   }
  
   getViewPort(){
     this.observer.observe(['(max-width: 800px)']).subscribe((res) => {
       if (res.matches) {
         this.sidenav.mode = 'over';
         
         this.sidenav.close();
       } else {
         this.sidenav.mode = 'side';
         this.sidenav.open();
       }
     });
   }

   signedIn(){
   this.show=this.authService.loggedIn();
   }

}
