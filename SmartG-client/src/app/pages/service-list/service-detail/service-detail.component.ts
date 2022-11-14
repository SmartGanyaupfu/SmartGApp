import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Service } from 'src/app/_interfaces/service';
import { AuthService } from 'src/app/_services/auth.service';
import { ServiceService } from 'src/app/_services/service.service';

@Component({
  selector: 'app-service-detail',
  templateUrl: './service-detail.component.html',
  styleUrls: ['./service-detail.component.css']
})
export class ServiceDetailComponent implements OnInit {

  page:Service;
  pageSlug:string;
  loggedIn:boolean;
  constructor(private authService:AuthService,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {

    this.route.data.subscribe(data=>{
      this.page=data.service;
     // console.log(data.service);
     this.loggedIn=this.authService.loggedIn();
     //console.log(this.loggedIn)
    })
    this.pageSlug= this.router.url.split('?')[0].split('/').pop();
    
    /*this.serviceService.getServiceBySlug(this.pageSlug).subscribe(res=>{
      this.page=res;
    })*/


  }
  
}
