import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { SearchDto } from '../_interfaces/search-dto';

@Injectable({
  providedIn: 'root'
})
export class SearchService {
  baseurl:string= environment.baseUrl;
  result:SearchDto;
  constructor(private http:HttpClient) { }
  getSearchResults(pageNumber?:number,pageSize?:number, searchTerm?:string){
    const parmsObj={
  
      pageNumber:pageNumber||undefined,
      pageSize:pageSize||undefined,
      searchTerm:searchTerm||undefined
    };
    const params = new HttpParams({fromObject:parmsObj});
    return this.http.get<SearchDto>(this.baseurl +'search',{observe:'response',params}).pipe(
      map(response=>{
        this.result=response.body;
      
       // console.log(this.result);
        return this.result;
      })
    )
  }
}
