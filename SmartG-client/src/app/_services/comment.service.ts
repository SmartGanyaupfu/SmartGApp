import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PaginatedResult } from '../_interfaces/pagination';

@Injectable({
  providedIn: 'root'
})
export class CommentService {

  baseurl:string= environment.baseUrl;
  //service:Service;
  paginatedResult:PaginatedResult<Comment[]>= new PaginatedResult<Comment[]>();
    
    constructor(private http:HttpClient) { }
    getComments(postType:string,pageNumber?:number,pageSize?:number){
      const parmsObj={
    
        pageNumber:pageNumber||undefined,
        pageSize:pageSize||undefined
      };
      const params = new HttpParams({fromObject:parmsObj});
      return this.http.get<Comment[]>(this.baseurl +postType+'/comments',{observe:'response',params}).pipe(
        map(response=>{
          this.paginatedResult.result=response.body;
          if(response.headers.get('pagination')!==null){
            this.paginatedResult.pagination=JSON.parse(response.headers.get('pagination'));
          }
          
          return this.paginatedResult;
        })
      )
    }
  
    getCommentById(postType:string,commentId:number){
      return this.http.get<Comment>(this.baseurl +postType+'/comments/'+commentId )
    }
  
    createComment(postType:string,comment:any){
      return this.http.post<Comment>(this.baseurl+postType+'/comments/',comment);
    }
    updateComment(postType:string,commentId:number,comment:any){
      return this.http.put(this.baseurl+postType+'/comments/'+commentId,comment);
    }
    deleteComment(commentId:any){
      return this.http.delete<Comment>(this.baseurl+'comments/'+commentId);
    }
}
