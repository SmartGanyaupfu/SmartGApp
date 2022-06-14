import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Category } from '../_interfaces/category';
import { PaginatedResult } from '../_interfaces/pagination';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  baseurl:string= environment.baseUrl;
  //service:Service;
  paginatedResult:PaginatedResult<Category[]>= new PaginatedResult<Category[]>();
    
    constructor(private http:HttpClient) { }
    getServices(pageNumber?:number,pageSize?:number){
      const parmsObj={
    
        pageNumber:pageNumber||undefined,
        pageSize:pageSize||undefined
      };
      const params = new HttpParams({fromObject:parmsObj});
      return this.http.get<Category[]>(this.baseurl +'categories',{observe:'response',params}).pipe(
        map(response=>{
          this.paginatedResult.result=response.body;
          if(response.headers.get('pagination')!==null){
            this.paginatedResult.pagination=JSON.parse(response.headers.get('pagination'));
          }
          
          return this.paginatedResult;
        })
      )
    }
  
    getCategoryById(categoryId:number){
      return this.http.get<Category>(this.baseurl + 'categories/'+categoryId )
    }
  
    createCategory(category:any){
      return this.http.post<Category>(this.baseurl+ 'categories/',category);
    }
    updateCategory(categoryId:number,category:any){
      return this.http.put(this.baseurl+ 'categories/'+categoryId,category);
    }
}