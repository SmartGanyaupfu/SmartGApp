import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { Widget } from 'src/app/_interfaces/widget';
import { WidgetService } from 'src/app/_services/widget.service';

@Component({
  selector: 'app-widget-list',
  templateUrl: './widget-list.component.html',
  styleUrls: ['./widget-list.component.css']
})
export class WidgetListComponent implements OnInit {


page:Widget;
  constructor(private widgetService:WidgetService, private toastr:ToastrService) { }

  ngOnInit(): void {
   this.getWidgets();
  

  }

getWidgets(){
  this.widgetService.getWidget().subscribe(res=>{
    this.page=res;
    
  })
}

deleteWidget(page:Widget){
this.widgetService.deleteWidget(page.widgetId).subscribe(res=>{
  this.page=null;
  this.toastr.success("Widget has been permanently deleted", "Deleted")
})
}

}
