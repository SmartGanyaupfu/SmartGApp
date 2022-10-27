import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import {  map, Observable, of, switchMap } from 'rxjs';
import { Page } from '../_interfaces/page';
import { Service } from '../_interfaces/service';
import { PageService } from '../_services/page.service';
import { SeoService } from '../_services/seo.service';
import { ServiceService } from '../_services/service.service';
import { WidgetService } from '../_services/widget.service';

@Injectable({
  providedIn: 'root'
})
export class DetailedViewResolver implements Resolve<Page> {
  constructor(private service:WidgetService,private pageService:PageService, private seoService:SeoService){}
  resolve(route: ActivatedRouteSnapshot): Observable<Page> {
    let myPage: Page;
   return this.service.getWidget().pipe(
      switchMap(
        widget => {
         
        // page start
        return this.pageService.getPageById(widget?.homePage>0?widget?.homePage:1).pipe(
          
          map(
            page => {
    
              
              this.seoService.metaTitle.setTitle(page.title)
              this.seoService.metaTagService.updateTag({name:'description', content:page.metaDescription})
              this.seoService.metaTagService.updateTag({
                name:'keywords',
              content:page.metaKeyWords
              
              })
              // the canActivate expect and Observable<boolean> that's why we have to return true here
            
              myPage=page;
              return page;
              // page end
            }
          ))
        
        }
        
      ))
   
  }
}
