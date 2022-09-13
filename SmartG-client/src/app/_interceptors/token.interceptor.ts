import { Inject, Injectable, PLATFORM_ID } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse
} from '@angular/common/http';
import { BehaviorSubject, catchError, filter, Observable, switchMap, take, throwError } from 'rxjs';
import { AuthService } from '../_services/auth.service';
import { TokenStorageService } from '../_services/token-storage.service';
import { isPlatformBrowser } from '@angular/common';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  @Inject(PLATFORM_ID) private platformId;
 
  private isRefreshing = false;
  private refreshTokenSubject: BehaviorSubject<any> = new BehaviorSubject<any>(
    null
  );

  constructor(public authService: AuthService, private tokenService:TokenStorageService) {}

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if(isPlatformBrowser){
      let authReq = request;
      const token = this.tokenService.getToken();
      if (token != null) {
        authReq = this.addTokenHeader(request, token);
      }
      return next.handle(authReq).pipe(catchError(error => {
        if (error instanceof HttpErrorResponse && authReq.url.includes('/auth/login') && error.status === 401) {
          return this.handle401Error(authReq, next);
        }
        return throwError(error);
      }));
    }
 
  }
  private handle401Error(request: HttpRequest<any>, next: HttpHandler) {
    if(isPlatformBrowser){
      if (!this.isRefreshing) {
        this.isRefreshing = true;
        this.refreshTokenSubject.next(null);
        const tokenModel = this.tokenService.getUser();
        if (tokenModel)
        
          return this.authService.refreshToken(tokenModel).pipe(
            switchMap((token: any) => {
              this.isRefreshing = false;
              this.tokenService.saveToken(token.accessToken);
              this.refreshTokenSubject.next(token.accessToken);
              
              return next.handle(this.addTokenHeader(request, token.accessToken));
            }),
            catchError((err) => {
              this.isRefreshing = false;
              this.tokenService.signOut();
              return throwError(err);
            })
          );
      }
      return this.refreshTokenSubject.pipe(
        filter(token => token !== null),
        take(1),
        switchMap((token) => next.handle(this.addTokenHeader(request, token)))
      );
    }
  
  }
  private addTokenHeader(request: HttpRequest<any>, token: string) {
    /* for Spring Boot back-end */
    // return request.clone({ headers: request.headers.set(TOKEN_HEADER_KEY, 'Bearer ' + token) });
    /* for Node.js Express back-end */
    if(isPlatformBrowser){
      return request.clone({
        setHeaders: {
          Authorization: `Bearer ${token}`,
        },
      });
    }
  
  }
}
