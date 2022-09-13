import { Injectable } from '@angular/core';
import {
  Router, Resolve,
  RouterStateSnapshot,
  ActivatedRouteSnapshot
} from '@angular/router';
import { Observable, of } from 'rxjs';
import { Page } from '../_interfaces/page';
import { PageService } from '../_services/page.service';

@Injectable({
  providedIn: 'root'
})
export class PageResolverResolver implements Resolve<Page> {
  constructor(private pageService:PageService){}
  resolve(route: ActivatedRouteSnapshot): Observable<Page> {
    return this.pageService.getPageById(1);
  }
}
