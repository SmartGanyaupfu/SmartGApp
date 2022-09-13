import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { map, Observable, of } from 'rxjs';
import { Portfolio } from '../_interfaces/portfolio';
import { Service } from '../_interfaces/service';
import { PortfolioService } from '../_services/portfolio.service';
import { SeoService } from '../_services/seo.service';
import { ServiceService } from '../_services/service.service';

@Injectable({
  providedIn: 'root'
})
export class PortfolioResolver implements Resolve<Portfolio> {
  constructor(private service:PortfolioService, private seoService:SeoService){}
  resolve(route: ActivatedRouteSnapshot): Observable<Portfolio> {
    return this.service.getPortfolioBySlug(route.paramMap.get('slug')).pipe(
      map(
        portfolio => {
          this.seoService.metaTitle.setTitle(portfolio.title)
          this.seoService.metaTagService.updateTag({name:'description', content:portfolio.metaDescription})
          this.seoService.metaTagService.updateTag({
            name:'keywords',
          content:portfolio.metaKeyWords
          })
          // the canActivate expect and Observable<boolean> that's why we have to return true here
          console.log('Called from the resolver')
          return portfolio;
        }
      ))
  }
}
