import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { catchError, Observable, throwError } from 'rxjs';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  constructor(private router:Router, private toastrService:ToastrService) { }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    return next.handle(request).pipe(catchError(err => {
        if ([401, 403].includes(err.status)) {
            // auto logout if 401 or 403 response returned from api
            this.toastrService.error('Unauthorized','Not allowed');
            this.router.navigate(['/home']);
            return;
        }
        if([422].includes(err.status)){
          this.toastrService.error('Unprocessable, please fill in all required fields','Error');
          return;
        }

        if([400].includes(err.status)){
          this.toastrService.error(err.error, 'Bad Request');
          return;
        }
        if([500].includes(err.status)){
          this.toastrService.error(err.error,'Error');
          return;
        }

        const error = (err && err.error && err.error.message) || err.statusText;
       // this.toastrService.error(error,'Error');
        return throwError(err);
    }))
    }
}
