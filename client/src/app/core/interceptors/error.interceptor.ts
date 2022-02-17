import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { NavigationExtras, Router } from "@angular/router";
import { ToastrService } from "ngx-toastr";
import { Observable, throwError } from "rxjs";
import { catchError } from "rxjs/operators";

@Injectable()

export class ErrorInterceptor implements HttpInterceptor {

    constructor(private router: Router, private toastr: ToastrService) {}
    
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        return next.handle(req).pipe(
            catchError(error => {
                if (error) {
                    
                    if(error.status === 400) {
                        // Check if it is a 400 validation error (check if we have the errors array)
                        if(error.error.errors) {
                            throw error.error;
                        } else {
                            this.toastr.error(error.error.message, error.error.statusCode);
                        }
                    }

                    if(error.status === 401) {
                        this.toastr.error(error.error.message, error.error.statusCode);
                    }

                    if(error.status === 404) {
                        this.router.navigateByUrl('/not-found');
                    }

                    if(error.status === 500) {
                        // Create navigation extras so that we can send the error information to the 
                        // server error component
                        const navigationExtras: NavigationExtras = {state: {error: error.error}};
                        this.router.navigateByUrl('/server-error', navigationExtras);
                    }

                    return throwError(error);
                }

                
            })
        );
    }

}
