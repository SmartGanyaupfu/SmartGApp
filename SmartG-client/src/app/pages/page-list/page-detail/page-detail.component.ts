import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Page } from 'src/app/_interfaces/page';
import { AuthService } from 'src/app/_services/auth.service';
import { PageService } from 'src/app/_services/page.service';

@Component({
  selector: 'app-page-detail',
  templateUrl: './page-detail.component.html',
  styleUrls: ['./page-detail.component.css']
})
export class PageDetailComponent implements OnInit {
  page:Page;
  pageSlug:string;
  loggedIn:boolean;

  constructor(private pageService:PageService,private route:ActivatedRoute,private router:Router,private authService:AuthService) { }

  ngOnInit(): void {

  
    this.route.data.subscribe(data=>{
      this.page=data.page;
    })
    this.loggedIn=this.authService.loggedIn();
  }

  

}
