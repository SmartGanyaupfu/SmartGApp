import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Service } from 'src/app/_interfaces/service';
import { ServiceService } from 'src/app/_services/service.service';

@Component({
  selector: 'app-service-detail',
  templateUrl: './service-detail.component.html',
  styleUrls: ['./service-detail.component.css']
})
export class ServiceDetailComponent implements OnInit {

  page:Service;
  pageSlug:string;

  constructor(private serviceService:ServiceService,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {

  
    this.pageSlug= this.router.url.split('?')[0].split('/').pop();
    //console.log(this.route.parent.url)
    if(history.state.postData){
      localStorage.setItem('postData',JSON.stringify(history.state.postData));
      this.page=JSON.parse(localStorage.getItem('postData'));
    }else {
      localStorage.removeItem('postData');
      this.serviceService.getServiceBySlug(this.pageSlug).subscribe(res=>{
        this.page=res;
      })
    }

  }
}
