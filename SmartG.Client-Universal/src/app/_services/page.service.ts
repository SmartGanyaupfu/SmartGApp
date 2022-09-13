import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Page } from '../_interfaces/page';

@Injectable({
  providedIn: 'root'
})
export class PageService {
baseurl=environment.baseUrl;
  constructor(private http:HttpClient) { }
  getPageById(pageId:any){
    return this.http.get<Page>(this.baseurl + 'pages/'+pageId )
  }
}
