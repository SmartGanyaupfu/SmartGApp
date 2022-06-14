import { Component, OnInit } from '@angular/core';
import { Service } from 'src/app/_interfaces/service';
import { ServiceService } from 'src/app/_services/service.service';

@Component({
  selector: 'app-service',
  templateUrl: './service.component.html',
  styleUrls: ['./service.component.css']
})
export class ServiceComponent implements OnInit {
  public myServices:Service[]=[];
  pageNumber:number=1;
  pageSize:number=6;

  constructor(private serviceService:ServiceService) { }

  ngOnInit(): void {
    this.GetServices();
  }

  GetServices(){
    this.serviceService.getServices(this.pageNumber,this.pageSize).subscribe(response=>{
      this.myServices=response.result;
      console.log(this.myServices);
    })
      }

}
