import { Component, OnInit } from '@angular/core';
import { Service } from 'src/app/_interfaces/service';
import { Widget } from 'src/app/_interfaces/widget';
import { SeoService } from 'src/app/_services/seo.service';
import { ServiceService } from 'src/app/_services/service.service';
import { WidgetService } from 'src/app/_services/widget.service';

@Component({
  selector: 'app-service',
  templateUrl: './service.component.html',
  styleUrls: ['./service.component.css']
})
export class ServiceComponent implements OnInit {
  public myServices:Service[];
  pageNumber:number=1;
  pageSize:number=6;
  widget:Widget;

  constructor(private serviceService:ServiceService, private widgetService:WidgetService, private seoService:SeoService) { }

  ngOnInit(): void {
    this.getWidgets();
    this.seoService.metaTitle.setTitle('SG | Services - Browse some of my software developement services I offer')
    this.seoService.metaTagService.updateTag({name:'description', content:'SG | Browse through some of the software development services I offer. If you need a website, mobile app, hosting and web apps, I will be your guy.'})
    this.seoService.metaTagService.updateTag({
      name:'keywords',
    content:' Hosting, Android and IOS mobile app development, Developer, Web design, Graphic Design'
    })
  }

  GetServices(){
    this.serviceService.getServices(this.pageNumber,this.widget.postPageSize).subscribe(response=>{
      this.myServices=response.result;
    })
      }
      getWidgets(){
        this.widgetService.getWidget().subscribe(res=>{
          this.widget= res;
         
          this.GetServices();
        
         
        })
      }

}
