import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { map, Observable, of } from 'rxjs';
import { Post } from '../_interfaces/post';
import { PostService } from '../_services/post.service';
import { SeoService } from '../_services/seo.service';

@Injectable({
  providedIn: 'root'
})
export class BlogResolver implements Resolve<Post> {
  constructor(private service:PostService, private seoService:SeoService){}
  resolve(route: ActivatedRouteSnapshot): Observable<Post> {
    return this.service.getPostBySlug(route.paramMap.get('slug')).pipe(
      map(
        post => {
          this.seoService.metaTitle.setTitle(post.title)
          this.seoService.metaTagService.updateTag({name:'description', content:post.metaDescription})
          this.seoService.metaTagService.updateTag({
            name:'keywords',
          content:post.metaKeyWords
          })
          // the canActivate expect and Observable<boolean> that's why we have to return true here
         
          return post;
        }
      ))
  }
}
