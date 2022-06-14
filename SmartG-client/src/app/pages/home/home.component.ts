import { Component, OnInit } from '@angular/core';
import { ContentBlock } from 'src/app/_interfaces/content-block';
import { Page } from 'src/app/_interfaces/page';
import { Portfolio } from 'src/app/_interfaces/portfolio';
import { Post } from 'src/app/_interfaces/post';
import { Service } from 'src/app/_interfaces/service';
import { PageService } from 'src/app/_services/page.service';
import { PortfolioService } from 'src/app/_services/portfolio.service';
import { PostService } from 'src/app/_services/post.service';
import { ServiceService } from 'src/app/_services/service.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
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
  ages = [3, 10, 18, 20];
  constructor(private pageService:PageService, private serviceService:ServiceService,
     private portfolioService:PortfolioService, private postService:PostService) { }

  ngOnInit(): void {
    this.GetHomePage();
    this.GetServices();
    this.GetPortfolios();
    this.getBlogs();

  }

  GetHomePage(){
    this.pageService.getPageById(1).subscribe(pageReturned=>{
      this.page= pageReturned;
      this.skillBlock= this.page.contentBlocks.find(x=>x.contentBlockId==="2c02cd05-8411-45d1-0bf3-08da3e6d127f");
      this.workBlock=this.page.contentBlocks.find(x=>x.contentBlockId==="7069474f-dcb2-4dcc-0bf4-08da3e6d127f");
      this.eduBlock=this.page.contentBlocks.find(x=>x.contentBlockId==="2d43cb6a-e3d2-4bf9-511e-08da4a2dbc76");
      this.InterestBlock=this.page.contentBlocks.find(x=>x.contentBlockId==="9d33622d-82d7-4a81-511f-08da4a2dbc76")
      console.log(this.page);
   
    })
  }

  GetServices(){
this.serviceService.getServices(this.pageNumber,this.pageSize).subscribe(response=>{
  this.myServices=response.result;
  console.log(this.myServices);
})
  }

  GetPortfolios(){
    this.portfolioService.getPortfolios(this.pageNumber,this.pageSize).subscribe(response=>{
      this.portfolios=response.result;
      console.log(this.portfolios);
    })
  }

getBlogs(){
this.postService.getPosts(this.pageNumber,this.pageSize).subscribe(response=>{
this.posts=response.result;
console.log(this.posts);
})
}

}
