import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Page } from '../_interfaces/page';
import { PaginatedResult } from '../_interfaces/pagination';

@Injectable({
  providedIn: 'root'
})
export class PageService {
  baseurl:string= environment.baseUrl;
  //page: Page;
  paginatedResult:PaginatedResult<Page[]>= new PaginatedResult<Page[]>();
    
    constructor(private http:HttpClient) { }
    getPages(pageNumber?:number,pageSize?:number){
      const parmsObj={
    
        pageNumber:pageNumber||undefined,
        pageSize:pageSize||undefined
      };
      const params = new HttpParams({fromObject:parmsObj});
      return this.http.get<Page[]>(this.baseurl +'pages',{observe:'response',params}).pipe(
        map(response=>{
          this.paginatedResult.result=response.body;
          if(response.headers.get('pagination')!==null){
            this.paginatedResult.pagination=JSON.parse(response.headers.get('pagination'));
          }
          console.log(JSON.parse(response.headers.get('pagination')));
          return this.paginatedResult;
        })
      )
    }
  
    getPageById(pageId:number){
      return this.http.get<Page>(this.baseurl + 'pages/'+pageId )
    }
  
    createImageForPage(pageId:number){
      
    }
  
    createPage(page:any){
      return this.http.post<Page>(this.baseurl+ 'pages/',page);
    }
    updatePage(pageId:number,page:any){
      return this.http.put(this.baseurl+ 'pages/'+pageId,page);
    }
  }