import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Widget } from '../_interfaces/widget';

@Injectable({
  providedIn: 'root'
})
export class WidgetService {
  baseurl:string= environment.baseUrl;
    
    constructor(private http:HttpClient) { }


    getWidget(){
      return this.http.get<Widget>(this.baseurl +'widgets' )
    }
  
    getWidgetById(widgetId:number){
      return this.http.get<Widget>(this.baseurl +'widgets/'+widgetId )
    }
  
    createWidget(widget:any){
      return this.http.post<Widget>(this.baseurl+'widgets/',widget);
    }
    updateWidget(widgetId:number,widget:any){
      return this.http.put(this.baseurl+'widgets/'+widgetId,widget);
    }
    deleteWidget(widgetId:any){
      return this.http.delete<Widget>(this.baseurl+'widgets/'+widgetId);
    }
}
