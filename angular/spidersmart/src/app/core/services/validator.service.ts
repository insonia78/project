import { Injectable } from '@angular/core';
import { AbstractControl, AsyncValidatorFn, ValidationErrors } from '@angular/forms';
import { Observable } from 'rxjs';
import { take, map } from 'rxjs/operators';

import { PageError } from '../interfaces/page-error.interface';
import { PageService } from './page.service';

@Injectable({
    providedIn: 'root'
})
export class ValidatorService {
    /**
     * Asynchronous validator that will trigger error messages on associated field when corresponding messages are triggered by the given service
     * @param pageService The reference to the service which will trigger errors from the api
     * @return The asynchronous function that can be given to a form control
     */
    public static ApiValidator(pageService: PageService): AsyncValidatorFn {
        return (control: AbstractControl): Observable<ValidationErrors | null> => {
            // get the name of the control to compare to any errors in the service
            const controlName = (control.parent) ? Object.keys(control.parent.controls).find(name => control === control.parent.controls[name]) : null;
            // return any errors that exist for the current control, or null if none do
            return pageService.getFieldErrors().pipe(take(1), map((errors: PageError[]) => {
                if (errors && errors.length > 0) {
                    const fieldErrors = errors.filter((error: PageError) => error.field === controlName);
                    return (fieldErrors.length > 0) ? {'apiValidation': fieldErrors} : null;
                }
                return null;
            }));
        };
    }
}
