import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { map, Observable, of } from 'rxjs';
import { Page } from '../_interfaces/page';
import { PageService } from '../_services/page.service';
import { SeoService } from '../_services/seo.service';

@Injectable({
  providedIn: 'root'
})
export class HomeResolver implements Resolve<Page> {
  constructor(private service:PageService, private seoService:SeoService){}
  resolve(route: ActivatedRouteSnapshot): Observable<Page> {
    return this.service.getPageBySlug(route.paramMap.get('slug')).pipe(
      map(
        page => {
          this.seoService.metaTitle.setTitle(page.title)
          this.seoService.metaTagService.updateTag({name:'description', content:page.metaDescription})
          this.seoService.metaTagService.updateTag({
            name:'keywords',
          content:page.metaKeyWords
          })
          // the canActivate expect and Observable<boolean> that's why we have to return true here
          
          return page;
        }
      ))
  }
}
