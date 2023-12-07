import {
  HttpInterceptor,
  HttpRequest,
  HttpHandler,
  HttpHeaders,
  HttpEvent,
  HttpErrorResponse,
} from '@angular/common/http';
import { Observable, from, throwError, lastValueFrom } from 'rxjs';
import { Injectable } from '@angular/core';
import { SecureService } from '../services/security.service';
import { environment } from '../../environments/environment';
import { catchError } from 'rxjs/operators';
import { AlertMessageModule } from './alert-message.module';
import { Router } from '@angular/router';

declare const Zone: any;

@Injectable({
  providedIn: 'root',
})
export class AuthInterceptorService implements HttpInterceptor {
  constructor(private _authService: SecureService, private alertModule: AlertMessageModule, private _router: Router) {}

  intercept(
    req: HttpRequest<any>,
    next: HttpHandler,
  ): Observable<HttpEvent<any>> {
    if (req.url.startsWith(environment.baseUrl)) {
      return from(
        this._authService.getAccessToken().then((token) => {
          const headers = new HttpHeaders().set(
            'Authorization',
            `Bearer ${token}`
          );
          const authRequest = req.clone({ headers });
          return lastValueFrom(next.handle(authRequest).pipe(
            catchError((error: HttpErrorResponse) => {
              let errorMsg = '';
              if (error.error instanceof ErrorEvent) {
                console.log('This is client side error');
                errorMsg = `Error: ${error.error.message}`;
              } else {
                console.log('This is server side error');
                errorMsg = `Error Code: ${error.status},  Message: ${error.message}`;
              }

              if(error.status == 401){
                this._authService.saveCurrentUrl();
                this._router.navigate(['/'], { replaceUrl: true });                
                return throwError(errorMsg);
              }
              
              this.alertModule.showAlertFromHttpResponse(error);
              return throwError(errorMsg);
            })
          ));
        })
      );
    } else {
      return next.handle(req);
    }
  }
}
