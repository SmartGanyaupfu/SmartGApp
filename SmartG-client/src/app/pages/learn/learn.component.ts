import { Component, OnInit } from '@angular/core';
import { Page } from 'src/app/_interfaces/page';
import { Widget } from 'src/app/_interfaces/widget';
import { PageService } from 'src/app/_services/page.service';
import { WidgetService } from 'src/app/_services/widget.service';

@Component({
  selector: 'app-learn',
  templateUrl: './learn.component.html',
  styleUrls: ['./learn.component.css']
})
export class LearnComponent implements OnInit {
page:Page;
widget:Widget;
  constructor(private pageService:PageService,private widgetService:WidgetService) { }

  ngOnInit(): void {
    this.getWidgets();
  }

  getLearnPage(){
    this.pageService.getPageById(this.widget.learnToCode).subscribe(response=>{
      this.page=response;
    })
  }

  getWidgets(){
    this.widgetService.getWidget().subscribe(res=>{
      this.widget= res;
      this.getLearnPage();
      
     
    })
  }
}
