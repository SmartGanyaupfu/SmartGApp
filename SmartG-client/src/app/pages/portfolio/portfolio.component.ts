import { Component, OnInit } from '@angular/core';
import { Portfolio } from 'src/app/_interfaces/portfolio';
import { Widget } from 'src/app/_interfaces/widget';
import { PortfolioService } from 'src/app/_services/portfolio.service';
import { SeoService } from 'src/app/_services/seo.service';
import { WidgetService } from 'src/app/_services/widget.service';

@Component({
  selector: 'app-portfolio',
  templateUrl: './portfolio.component.html',
  styleUrls: ['./portfolio.component.css']
})
export class PortfolioComponent implements OnInit {
  portfolios:Portfolio[];
  webPortfolio:Portfolio[];
  mobilePortfolio:Portfolio[];
  pageNumber:number=1;
  pageSize:number=6;
  widget:Widget;
  constructor(private portfolioService:PortfolioService, private widgetService:WidgetService, private seoService:SeoService) { }

  ngOnInit(): void {
    this.seoService.metaTitle.setTitle('SG |Software Developer Portfolio')
    this.seoService.metaTagService.updateTag({name:'description', content:'SG | Developer Portfolio - If you are interested in my previous work, the portfolio section has all the details'})
    this.seoService.metaTagService.updateTag({
      name:'keywords',
    content:' Blog Hosting, Android and IOS mobile app development, Developer, Web design, Graphic Design'
    })
    this.getWidgets();
  }
  GetPortfolios(){
    this.portfolioService.getPortfolios(this.pageNumber,this.widget.postPageSize).subscribe(response=>{
      this.portfolios=response.result;
      
     
    })
  }

  getWidgets(){
    this.widgetService.getWidget().subscribe(res=>{
      this.widget= res;
     
      this.GetPortfolios();
    
     
    })
  }
}
