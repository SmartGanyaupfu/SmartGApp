import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { SeoService } from '../_services/seo.service';
import { ServiceService } from '../_services/service.service';

@Injectable({
  providedIn: 'root'
})
export class LearnResolver implements Resolve<boolean> {

  constructor(private service:ServiceService, private seoService:SeoService){}
  resolve(route: ActivatedRouteSnapshot, state: RouterStateSnapshot): Observable<boolean> {
    this.seoService.metaTitle.setTitle('Learn To Code');
    this.seoService.metaTagService.updateTag({name:'description', content: " I help code beginners to reach their full potential. As I was once a beginner myself, I understand how difficult it can be to grasp coding and gain confidence."})
    this.seoService.metaTagService.updateTag({
      name:'keywords',
    content:'coding coach, mentorship, learn to code, how to code'
    })
    console.log('seo test')
    return of(true);
  }
}
