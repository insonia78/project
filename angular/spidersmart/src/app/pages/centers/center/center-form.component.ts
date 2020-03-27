import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, AsyncValidatorFn } from '@angular/forms';
import { takeUntil, take, catchError, finalize } from 'rxjs/operators';

import { Center, GraphQLResponse, PageMode, TextMask, PageService, ValidatorService, PageActions, PageActionPosition } from '@spidersmart/core';
import { CenterService } from './center.service';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject } from 'rxjs';

@Component({
    selector: 'sm-center-form',
    templateUrl: './center-form.component.html'
})
export class CenterFormComponent implements OnInit, OnDestroy {
    /** The current center */
    public center: Center = {
        id: null,
        type: 'local',
        name: '',
        label: '',
        streetAddress: '',
        city: '',
        state: '',
        postalCode: '',
        country: '',
        email: '',
        phone: '',
        dateFrom: null
    };
    public TextMask = TextMask;
    public form: FormGroup;
    public backRoute = ['/center'];
    protected apiValidator: AsyncValidatorFn = ValidatorService.ApiValidator(this.pageService);
    private ngUnsubscribe: Subject<any> = new Subject();

    constructor(
        private fb: FormBuilder,
        private activatedRoute: ActivatedRoute,
        private router: Router,
        private pageService: PageService,
        private centerService: CenterService,

    ) {
        // define form structure
        this.form = this.fb.group({
            name: ['', null, this.apiValidator],
            label: ['', null, this.apiValidator],
            streetAddress: ['', null, this.apiValidator],
            city: ['', null, this.apiValidator],
            state: ['', null, this.apiValidator],
            postalCode: ['', null, this.apiValidator],
            country: ['', null, this.apiValidator],
            email: ['', null, this.apiValidator],
            phone: ['', null, this.apiValidator],
        });
    }

    ngOnInit() {
        this.pageService.setTitle('Create Center');
        this.pageService.setMode(PageMode.CREATE);


        // if there is an id, then we are in edit mode so there are a few extra tasks to perform
        if (this.activatedRoute.snapshot.params.hasOwnProperty('id')) {
            this.pageService.setMode(PageMode.EDIT);
            this.pageService.setTitle('Edit Center');
            this.backRoute = ['/center', this.activatedRoute.snapshot.params.id, 'view'];

            this.centerService.get(this.activatedRoute.snapshot.params.id).pipe(take(1)).subscribe((response: GraphQLResponse<Center>) => {
                // update data object and form data to response data, then set form as initialized
                this.center = response.data;
                this.form.patchValue({
                    name: this.center.name,
                    label: this.center.label,
                    streetAddress: this.center.streetAddress,
                    city: this.center.city,
                    state: this.center.state,
                    postalCode: this.center.postalCode,
                    country: this.center.country,
                    email: this.center.email,
                    phone: this.center.phone,
                });
            });
        }

        // add listener to email field to enforce "spidersmart.com" email addresses
        this.form.get('email').valueChanges.pipe(takeUntil(this.ngUnsubscribe)).subscribe((val: string) => {
            if (val.indexOf('@') !== -1) {
                const emailParts = val.split('@');
                if (emailParts[1] !== 'spidersmart.com') {
                    this.form.get('email').setValue(emailParts[0] + '@spidersmart.com');
                }
            }
        });
    }

    ngOnDestroy() {
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    /**
     * Saves the current form state
     * @return void
     */
    public save = (): void => {
        this.pageService.setLoading(true);
        this.pageService.clearErrors();

        const action = (this.pageService.isMode(PageMode.EDIT)) ? this.centerService.modify : this.centerService.create;
        action(Object.assign({}, this.center, this.form.value, {
            type: 'local',
            phone: TextMask.phone.unmask(this.form.get('phone').value)
        })).pipe(
            take(1),
            finalize(() => {
                this.pageService.setLoading(false);
            })
        ).subscribe(response => {
            if (response.success) {
                alert('Success');
                this.form.markAsPristine();
                this.form.markAsUntouched();
                this.router.navigate(this.backRoute);
            }
        });
    }

    /**
     * Syncs the label field to match the name field
     * @return void
     */
    public syncLabelToName = (name: string): void => {
        this.form.get('label').setValue(
            name.toLocaleLowerCase().replace(/[ _]/g, '-').replace(/[^a-z0-9-]+/g, '')
        );
    }
}
