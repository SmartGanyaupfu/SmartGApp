import { Component, OnInit } from '@angular/core';
import { Service } from 'src/app/_interfaces/service';
import { Widget } from 'src/app/_interfaces/widget';
import { ServiceService } from 'src/app/_services/service.service';
import { WidgetService } from 'src/app/_services/widget.service';

@Component({
  selector: 'app-service',
  templateUrl: './service.component.html',
  styleUrls: ['./service.component.css']
})
export class ServiceComponent implements OnInit {
  public myServices:Service[]=[];
  pageNumber:number=1;
  pageSize:number=6;
  widget:Widget;

  constructor(private serviceService:ServiceService, private widgetService:WidgetService) { }

  ngOnInit(): void {
    this.getWidgets();
  }

  GetServices(){
    this.serviceService.getServices(this.pageNumber,this.widget.postPageSize).subscribe(response=>{
      this.myServices=response.result;
      console.log(this.myServices);
    })
      }
      getWidgets(){
        this.widgetService.getWidget().subscribe(res=>{
          this.widget= res;
         
          this.GetServices();
        
         
        })
      }

}
