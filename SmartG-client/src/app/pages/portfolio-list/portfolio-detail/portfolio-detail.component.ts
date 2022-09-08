import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Portfolio } from 'src/app/_interfaces/portfolio';
import { PortfolioService } from 'src/app/_services/portfolio.service';

@Component({
  selector: 'app-portfolio-detail',
  templateUrl: './portfolio-detail.component.html',
  styleUrls: ['./portfolio-detail.component.css']
})
export class PortfolioDetailComponent implements OnInit {

  page:Portfolio;
  pageSlug:string;

  constructor(private portfolioService:PortfolioService,private route:ActivatedRoute,private router:Router) { }

  ngOnInit(): void {

  
    this.pageSlug= this.router.url.split('?')[0].split('/').pop();
    //console.log(this.route.parent.url)
 /*
    if(history.state.portfolioData){
      localStorage.setItem('portfolioData',JSON.stringify(history.state.portfolioData));
      this.page=JSON.parse(localStorage.getItem('portfolioData'));
    }else {
      localStorage.removeItem('portfolioData');
      this.portfolioService.getPageBySlug(this.pageSlug).subscribe(res=>{
        this.page=res;
      })
    }
 */

  }

}
