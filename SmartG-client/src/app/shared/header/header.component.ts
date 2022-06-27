import { Component, OnInit } from '@angular/core';
import { Widget } from 'src/app/_interfaces/widget';
import { WidgetService } from 'src/app/_services/widget.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {
widget:Widget;
  constructor(private widgetService:WidgetService) { }

  ngOnInit(): void {
    this.getWidget();
  }
  getWidget(){
    this.widgetService.getWidget().subscribe(res=>{
      this.widget=res;
    })
  }

}
