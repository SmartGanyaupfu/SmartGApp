import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { ContentBlock } from '../_interfaces/content-block';
import { PaginatedResult } from '../_interfaces/pagination';

@Injectable({
  providedIn: 'root'
})
export class ContentBlockService {
  baseurl:string= environment.baseUrl;
  //service:Service;
  paginatedResult:PaginatedResult<ContentBlock[]>= new PaginatedResult<ContentBlock[]>();
    
    constructor(private http:HttpClient) { }
    getContentBlocks(pageNumber?:number,pageSize?:number){
      const parmsObj={
    
        pageNumber:pageNumber||undefined,
        pageSize:pageSize||undefined
      };
      const params = new HttpParams({fromObject:parmsObj});
      return this.http.get<ContentBlock[]>(this.baseurl +'content-blocks',{observe:'response',params}).pipe(
        map(response=>{
          this.paginatedResult.result=response.body;
          if(response.headers.get('pagination')!==null){
            this.paginatedResult.pagination=JSON.parse(response.headers.get('pagination'));
          }
          
          return this.paginatedResult;
        })
      )
    }
  
    getBlockById(blockId:number){
      return this.http.get<ContentBlock>(this.baseurl + 'content-blocks/'+blockId)
    }
  
    createBlock(block:any){
      return this.http.post<ContentBlock>(this.baseurl+ 'content-blocks/',block);
    }
    updateBlock(blockId:number,block:any){
      return this.http.put(this.baseurl+ 'content-blocks/'+blockId,block);
    }
}
