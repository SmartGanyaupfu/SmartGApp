import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { PaginatedResult } from '../_interfaces/pagination';
import { Portfolio } from '../_interfaces/portfolio';
import { Service } from '../_interfaces/service';

@Injectable({
  providedIn: 'root'
})
export class PortfolioService {
  baseurl:string= environment.baseUrl;
  //portfolio:Portfolio;
  paginatedResult:PaginatedResult<Portfolio[]>= new PaginatedResult<Portfolio[]>();
    
    constructor(private http:HttpClient) { }
    getPortfolios(pageNumber?:number,pageSize?:number){
      const parmsObj={
    
        pageNumber:pageNumber||undefined,
        pageSize:pageSize||undefined
      };
      const params = new HttpParams({fromObject:parmsObj});
      return this.http.get<Portfolio[]>(this.baseurl +'portfolios',{observe:'response',params}).pipe(
        map(response=>{
          this.paginatedResult.result=response.body;
          if(response.headers.get('x-pagination')!==null){
            this.paginatedResult.pagination=JSON.parse(response.headers.get('x-pagination'));
          }
          
          return this.paginatedResult;
        })
      )
    }
  
    getPortfolioById(portfolioId:any){
      return this.http.get<Portfolio>(this.baseurl + 'portfolios/'+portfolioId )
    }
    getPageBySlug(pageSlug:string){
      return this.http.get<Portfolio>(this.baseurl + 'portfolios/slug/'+pageSlug )
    }
  
   
  
    createPortfolio(portfolio:any){
      return this.http.post<Portfolio>(this.baseurl+ 'portfolios/',portfolio);
    }
    updatePortfolio(portfolioId:any,portfolio:any){
      return this.http.put(this.baseurl+ 'portfolios/'+portfolioId,portfolio);
    }
    deletePortfolio(portfolioId:any){
      return this.http.delete<Portfolio>(this.baseurl+'portfolios/'+portfolioId);
    }
}
