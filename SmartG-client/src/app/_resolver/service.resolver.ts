import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { map, Observable, of } from 'rxjs';
import { Service } from '../_interfaces/service';
import { SeoService } from '../_services/seo.service';
import { ServiceService } from '../_services/service.service';

@Injectable({
  providedIn: 'root'
})
export class ServiceResolver implements Resolve<Service> {
  constructor(private service:ServiceService, private seoService:SeoService){}
  resolve(route: ActivatedRouteSnapshot): Observable<Service> {
    return this.service.getServiceBySlug(route.paramMap.get('slug')).pipe(
      map(
        service => {
          this.seoService.metaTitle.setTitle(service.title)
          this.seoService.metaTagService.updateTag({name:'description', content:service.metaDescription})
          this.seoService.metaTagService.updateTag({
            name:'keywords',
          content:service.metaKeyWords
          })
          // the canActivate expect and Observable<boolean> that's why we have to return true here
          console.log('Called from the resolver')
          return service;
        }
      ))
  }
}
