import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PaginatedResult } from '../_interfaces/pagination';
import { Post } from '../_interfaces/post';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  baseurl:string= environment.baseUrl;
  //service:Service;
  paginatedResult:PaginatedResult<Post[]>= new PaginatedResult<Post[]>();
    
    constructor(private http:HttpClient) { }
    getPosts(pageNumber?:number,pageSize?:number){
      const parmsObj={
    
        pageNumber:pageNumber||undefined,
        pageSize:pageSize||undefined
      };
      const params = new HttpParams({fromObject:parmsObj});
      return this.http.get<Post[]>(this.baseurl +'posts',{observe:'response',params}).pipe(
        map(response=>{
          this.paginatedResult.result=response.body;
          if(response.headers.get('pagination')!==null){
            this.paginatedResult.pagination=JSON.parse(response.headers.get('pagination'));
          }
          
          return this.paginatedResult;
        })
      )
    }
  
    getPostById(postId:number){
      return this.http.get<Post>(this.baseurl + 'posts/'+postId)
    }
  
    createPost(post:any){
      return this.http.post<Post>(this.baseurl+ 'posts/',post);
    }
    updatePost(postId:number,post:any){
      return this.http.put(this.baseurl+ 'posts/'+postId,post);
    }
}