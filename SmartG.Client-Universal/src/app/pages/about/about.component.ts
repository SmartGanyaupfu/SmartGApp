import { Component, Inject, OnInit, PLATFORM_ID } from '@angular/core';
import { Meta, Title } from '@angular/platform-browser';
import { Page } from 'src/app/_interfaces/page';
import { PageService } from 'src/app/_services/page.service';

@Component({
  selector: 'app-about',
  templateUrl: './about.component.html',
  styleUrls: ['./about.component.css']
})
export class AboutComponent implements OnInit {
  @Inject(PLATFORM_ID) private platformId;
  page:Page;
  /**
   *
   */
  constructor( private metaTagService:Meta, private metaTitle:Title,private pageService:PageService) {
    }
  ngOnInit(): void {
    
     // this.GetHomePage();
   
    
    
    
  }
  addMetaTags(){
  
    this.metaTagService.updateTag(   {
      name:'keywords',
    content:this.page.metaKeyWords
    });
    this.metaTagService.updateTag(  {name:'description', content:this.page.metaDescription});
    this.metaTitle.setTitle(this.page.title);
    
    
  }
  GetHomePage(){
    this.pageService.getPageById(1).subscribe(pageReturned=>{
      this.page= pageReturned;
      this.addMetaTags();
      console.log(this.page);
    
   
    })
  }

}
