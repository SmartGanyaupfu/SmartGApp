import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { Meta, Title } from '@angular/platform-browser';
import { ActivatedRoute } from '@angular/router';
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

  // Slide for portfolio
  itemsPerSlide = 3;
  singleSlideOffset = true;
  noWrap = false;

  constructor(private pageService:PageService, private serviceService:ServiceService,private blockService:ContentBlockService,
     private portfolioService:PortfolioService, private postService:PostService, private widgetService:WidgetService
     ,private metaTagService:Meta, private metaTitle:Title, private route: ActivatedRoute) { 

//this.getBlocks();
//this.getWidgets();

     }

  ngOnInit(): void {

    
    this.route.data.subscribe(data=>{
      this.page=data.home;
      this.getWidgets();
    })
    

  }
  addMetaTags(){
    
    this.metaTagService.updateTag({name:'keywords', content:"Xamarin, Xamarin Forms, C# Developer, .net, javascript,webiste Design, rest api"})
this.metaTagService.updateTag({name:'description', content:"A professional, results-driven, and dedicated full-stack web developer who is experienced in developing REST APIs using .Net Core. In addition to my academic qualifications, I am experienced in various programming & scripting languages such as C#, PHP, JavaScript and TypeScript"})
    this.metaTitle.setTitle('Home | Smart Ganyaupfu - Web and Mobile App Developer');
    
    
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
     
      this.addMetaTags();
   
    })
  }

  getWidgets(){
    this.widgetService.getWidget().subscribe(res=>{
      this.widget= res;
     // this.GetHomePage();
      this.getBlocks();
      this.GetServices();
    this.GetPortfolios();
     
    this.getBlogs();
     
    })
  }

  GetServices(){
this.serviceService.getServices(this.pageNumber,this.widget?.homePageSize).subscribe(response=>{
  this.myServices=response.result;
})
  }

  GetPortfolios(){
    this.portfolioService.getPortfolios(this.pageNumber,this.widget.homePageSize).subscribe(response=>{
      this.portfolios=response.result;
    })
  }

getBlogs(){
this.postService.getPosts(this.pageNumber,this.widget?.homePageSize).subscribe(response=>{
this.posts=response.result;
})
}

}
