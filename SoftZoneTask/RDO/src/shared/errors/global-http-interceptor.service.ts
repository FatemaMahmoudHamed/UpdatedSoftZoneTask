import { Injectable } from "@angular/core";
import {
  HttpInterceptor,
  HttpRequest,
  HttpResponse,
  HttpHandler,
  HttpEvent,
  HttpErrorResponse
} from '@angular/common/http';
import { Observable, throwError } from "rxjs";
import { map, catchError } from 'rxjs/operators';
import { MatDialog } from '@angular/material/dialog';
import { ErrorDialogComponent } from '../components/error-dialog/error-dialog.component';

@Injectable()
export class GlobalHttpInterceptorService implements HttpInterceptor {

  constructor(private dialog: MatDialog,) {
  }

  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

    return next.handle(request).pipe(
      map((event: HttpEvent<any>) => {
        if (event instanceof HttpResponse) {
        }
        return event;
      }),
      catchError((error) => {
        if (error.error.errorList?.length > 0)
          this.openModal(error.error.errorList);
        //console.error(error);
        return throwError(error.message);
      })
    );
  }

  //intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

  //    const token = localStorage.getItem('token');

  //    if (token) {
  //        request = request.clone({ headers: request.headers.set('Authorization', 'Bearer ' + token) });
  //    }

  //    if (!request.headers.has('Content-Type')) {
  //        request = request.clone({ headers: request.headers.set('Content-Type', 'application/json') });
  //    }

  //    request = request.clone({ headers: request.headers.set('Accept', 'application/json') });

  //    return next.handle(request).pipe(
  //        map((event: HttpEvent<any>) => {
  //            if (event instanceof HttpResponse) {
  //            }
  //            return event;
  //        }),
  //        catchError((error: HttpErrorResponse) => {
  //            this.openModal(error.error.errorList);
  //            return throwError(error);
  //        }));
  //}

  openModal(errorList: any): void {

    this.dialog.open(ErrorDialogComponent, {
      width: '30em',
      data: { errorList: errorList },
    });

  }

}
