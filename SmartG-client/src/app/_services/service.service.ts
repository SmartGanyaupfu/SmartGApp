import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PaginatedResult } from '../_interfaces/pagination';
import { Service } from '../_interfaces/service';

@Injectable({
  providedIn: 'root'
})
export class ServiceService {
  baseurl:string= environment.baseUrl;
  //service:Service;
  paginatedResult:PaginatedResult<Service[]>= new PaginatedResult<Service[]>();
    
    constructor(private http:HttpClient) { }
    getServices(pageNumber?:number,pageSize?:number){
      const parmsObj={
    
        pageNumber:pageNumber||undefined,
        pageSize:pageSize||undefined
      };
      const params = new HttpParams({fromObject:parmsObj});
      return this.http.get<Service[]>(this.baseurl +'services',{observe:'response',params}).pipe(
        map(response=>{
          this.paginatedResult.result=response.body;
          if(response.headers.get('pagination')!==null){
            this.paginatedResult.pagination=JSON.parse(response.headers.get('pagination'));
          }
          
          return this.paginatedResult;
        })
      )
    }
  
    getServiceById(serviceId:number){
      return this.http.get<Service>(this.baseurl + 'services/'+serviceId )
    }
  
    createImageForPage(pageId:number){
      
    }
  
    createService(service:any){
      return this.http.post<Service>(this.baseurl+ 'services/',service);
    }
    updateService(serviceId:number,service:any){
      return this.http.put(this.baseurl+ 'services/'+serviceId,service);
    }
}
