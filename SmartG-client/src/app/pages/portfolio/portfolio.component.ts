import { Component, OnInit } from '@angular/core';
import { Portfolio } from 'src/app/_interfaces/portfolio';
import { PortfolioService } from 'src/app/_services/portfolio.service';

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
  constructor(private portfolioService:PortfolioService) { }

  ngOnInit(): void {
    this.GetPortfolios();
  }
  GetPortfolios(){
    this.portfolioService.getPortfolios(this.pageNumber,this.pageSize).subscribe(response=>{
      this.portfolios=response.result;
      this.webPortfolio=this.portfolios.filter(x=>x.category.categoryId===1);
      this.mobilePortfolio=this.portfolios.filter(x=>x.category.categoryId===2);
      console.log(this.mobilePortfolio);
    })
  }
}
