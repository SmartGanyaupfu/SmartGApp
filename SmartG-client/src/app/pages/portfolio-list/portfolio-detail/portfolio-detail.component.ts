import { Component, OnInit, TemplateRef } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { Portfolio } from 'src/app/_interfaces/portfolio';
import { AuthService } from 'src/app/_services/auth.service';
import { PortfolioService } from 'src/app/_services/portfolio.service';

@Component({
  selector: 'app-portfolio-detail',
  templateUrl: './portfolio-detail.component.html',
  styleUrls: ['./portfolio-detail.component.css']
})
export class PortfolioDetailComponent implements OnInit {

  page:Portfolio;
  pageSlug:string;
  modalRef?: BsModalRef;
  loggedIn:boolean;
  images:string[]=["https://res.cloudinary.com/smart-ganyaupfu/image/upload/v1653559849/tjwrgprd4lfvjvdyzfgf.png","https://res.cloudinary.com/smart-ganyaupfu/image/upload/v1664375876/soyqmyhhz7hybruexszn.png"]

  constructor(private authService:AuthService,private route:ActivatedRoute,private modalService: BsModalService) { }
  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template,{class: 'modal-xl'});
  }

  ngOnInit(): void {

    this.route.data.subscribe(data=>{
      this.page=data.portfolio;
    })

    this.loggedIn=this.authService.loggedIn();
    }
 

  }


