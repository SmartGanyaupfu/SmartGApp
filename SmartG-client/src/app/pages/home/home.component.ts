import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { ContentBlock } from 'src/app/_interfaces/content-block';
import { Page } from 'src/app/_interfaces/page';
import { Portfolio } from 'src/app/_interfaces/portfolio';
import { Post } from 'src/app/_interfaces/post';
import { Service } from 'src/app/_interfaces/service';
import { Widget } from 'src/app/_interfaces/widget';
import { ContentBlockService } from 'src/app/_services/content-block.service';
import { PageService } from 'src/app/_services/page.service';
import { PortfolioService } from 'src/app/_services/portfolio.service';
import { PostService } from 'src/app/_services/post.service';
import { ServiceService } from 'src/app/_services/service.service';
import { WidgetService } from 'src/app/_services/widget.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  encapsulation: ViewEncapsulation.None,
})
export class HomeComponent implements OnInit {
  public page:Page;
  skillBlock:ContentBlock;
  workBlock:ContentBlock;
  eduBlock:ContentBlock;
  InterestBlock:ContentBlock;
  posts:Post[];
  public myServices:Service[]=[];
  portfolios:Portfolio[];
  pageNumber:number=1;
  pageSize:number=6;
  blocks:ContentBlock[];
  widget:Widget;
  ages = [3, 10, 18, 20];
  constructor(private pageService:PageService, private serviceService:ServiceService,private blockService:ContentBlockService,
     private portfolioService:PortfolioService, private postService:PostService, private widgetService:WidgetService) { 

//this.getBlocks();
//this.getWidgets();

     }

  ngOnInit(): void {
    this.getWidgets();
    
    

  }

  getBlocks(){
    this.blockService.getContentBlocks(1,50).subscribe(res=>{
      this.blocks=res.result;
      
     // this.getWidgets();
     this.skillBlock= this.blocks?.find(x=>x.contentBlockId===this.widget?.skillBlock)
     this.workBlock=this.blocks?.find(x=>x.contentBlockId===this.widget?.workBlock);
     this.eduBlock=this.blocks?.find(x=>x.contentBlockId===this.widget?.educationBlock);
     this.InterestBlock=this.blocks?.find(x=>x.contentBlockId===this.widget?.interestBlock)
    })
  }

  GetHomePage(){
    this.pageService.getPageById(this.widget?.homePage).subscribe(pageReturned=>{
      this.page= pageReturned;
      
      console.log(this.page);
   
    })
  }

  getWidgets(){
    this.widgetService.getWidget().subscribe(res=>{
      this.widget= res;
      this.GetHomePage();
      this.getBlocks();
      this.GetServices();
    this.GetPortfolios();
     
    this.getBlogs();
     
    })
  }

  GetServices(){
this.serviceService.getServices(this.pageNumber,this.widget?.homePageSize).subscribe(response=>{
  this.myServices=response.result;
  console.log(this.myServices);
})
  }

  GetPortfolios(){
    this.portfolioService.getPortfolios(this.pageNumber,this.widget.homePageSize).subscribe(response=>{
      this.portfolios=response.result;
      console.log(this.portfolios);
    })
  }

getBlogs(){
this.postService.getPosts(this.pageNumber,this.widget?.homePageSize).subscribe(response=>{
this.posts=response.result;
console.log(this.posts);
})
}

}
