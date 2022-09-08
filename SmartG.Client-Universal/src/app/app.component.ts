import { Component, OnInit } from '@angular/core';
import { Meta,Title } from '@angular/platform-browser';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'SmartG.Client-Universal';
  /**
   *
   */
  constructor( private metaTagService:Meta, private metaTitle:Title) {
    }
    ngOnInit(): void {
        this.addMetaTags();
    }
    addMetaTags(){
      this.metaTagService.addTags([
        {
          name:'keywords',
      content:'Smart is the man of the match'
      },
      { name: 'robots', content: 'index, follow' },
      { name: 'author', content: 'Digamber Singh' },
      { name: 'viewport', content: 'width=device-width, initial-scale=1' },
      { name: 'date', content: '2019-10-31', scheme: 'YYYY-MM-DD' },
      { charset: 'UTF-8' },
      {name:'description', content:'The inner part of the solar cooker is made up of mirrors.'}
      ])

      this.metaTitle.setTitle('Shumba test');
      
      
    }
}
