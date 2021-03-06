import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Page } from 'src/app/_interfaces/page';
import { PageService } from 'src/app/_services/page.service';

@Component({
  selector: 'app-page-detail',
  templateUrl: './page-detail.component.html',
  styleUrls: ['./page-detail.component.css']
})
export class PageDetailComponent implements OnInit {
  page:Page;
  pageSlug:string;

  constructor(private pageService:PageService,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {

  
    this.pageSlug= this.router.url.split('?')[0].split('/').pop();
    //console.log(this.route.parent.url)
    if(history.state.pageData){
      localStorage.setItem('pageDetail',JSON.stringify(history.state.pageData));
      this.page=JSON.parse(localStorage.getItem('pageDetail'));
    }else {
      localStorage.removeItem('pageDetail');
      this.pageService.getPageBySlug(this.pageSlug).subscribe(res=>{
        this.page=res;
      })
    }

  }

  

}
