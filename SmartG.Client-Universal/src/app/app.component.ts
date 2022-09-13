import { isPlatformBrowser, isPlatformServer } from '@angular/common';
import { Component, Inject, OnInit, PLATFORM_ID } from '@angular/core';
import { Meta,Title } from '@angular/platform-browser';
import { Page } from './_interfaces/page';
import { PageService } from './_services/page.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'SmartG.Client-xUniversal';
  public page:Page;
  @Inject(PLATFORM_ID) private platformId;
  
  /**
   *
   */
  constructor( private metaTagService:Meta, private metaTitle:Title,private pageService:PageService) {
    }
    ngOnInit(): void {
    
      //  this.GetHomePage();
      this.addMetaTags();
      
      
      
    }
    addMetaTags(){
      this.metaTagService.addTags([
        {
          name:'keywords',
      content:'test sg'
      },
      { name: 'robots', content: 'index, follow' },
      { name: 'author', content: 'Digamber Singh' },
      { name: 'viewport', content: 'width=device-width, initial-scale=1' },
      { name: 'date', content: '2019-10-31', scheme: 'YYYY-MM-DD' },
      { charset: 'UTF-8' },
      {name:'description', content:'The inner part of the solar cooker is made up of mirrors.'}
      ])

      this.metaTitle.setTitle('test hard code');
      
      
    }
    GetHomePage(){
      this.pageService.getPageById(1).subscribe(pageReturned=>{
        this.page= pageReturned;
        this.addMetaTags();
        console.log(this.page);
      
     
      })
    }
}
