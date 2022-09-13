import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot } from '@angular/router';
import { map } from 'rxjs';
import { PageService } from './page.service';
import { SeoService } from './seo.service';

@Injectable({
  providedIn: 'root'
})
export class HomeGuardService {

  constructor(private pageService:PageService,private seoService:SeoService) { }
  canActivate() {
    // fetching id  from the url
  const id =1;

  // calling our API service like we would usually do but instead of a subscribe, we do a pipe map.
  return this.pageService.getPageById(id).pipe(
    map(
      page => {
        this.seoService.metaTitle.setTitle(page.title)
        this.seoService.metaTagService.updateTag({name:'description', content:page.metaDescription})
        this.seoService.metaTagService.updateTag({
          name:'keywords',
        content:page.metaKeyWords
        })
        // the canActivate expect and Observable<boolean> that's why we have to return true here
        return true
      }
    ))
    }
     
}
