import { Component, OnInit, OnDestroy } from '@angular/core';
import { FormGroup, FormBuilder, AsyncValidatorFn } from '@angular/forms';
import { takeUntil, take, catchError, finalize } from 'rxjs/operators';

import { GraphQLResponse, PageMode, TextMask, PageService, ValidatorService, PageActions, PageActionPosition, Publisher } from '@spidersmart/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject } from 'rxjs';
import { PublishersService } from './publishers.service';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'sm-publishers-form',
    templateUrl: './publishers-form.component.html'
})
export class PublishersFormComponent implements OnInit, OnDestroy {

    public publisher: Publisher = {
        id: null,
        name: '',
        dateFrom: null

    };
    private data: any;
    public form: FormGroup;
    protected apiValidator: AsyncValidatorFn = ValidatorService.ApiValidator(this.pageService);
    private ngUnsubscribe: Subject<any> = new Subject();
    public backRoute = ['/publishers'];
    constructor(
        private fb: FormBuilder,
        private activatedRoute: ActivatedRoute,
        private router: Router,
        private pageService: PageService,
        private PublishersService: PublishersService,
        private toastService: ToastrService,

    ){
        this.form = this.fb.group({
            name: ['', null, this.apiValidator]
        });
    }

    ngOnInit(){
        this.pageService.setTitle('Create Publisher');
        this.pageService.setMode(PageMode.CREATE);

        if (this.activatedRoute.snapshot.params.hasOwnProperty('id')) {
            this.pageService.setMode(PageMode.CREATE);
            this.pageService.setTitle('Create Publisher');
            this.backRoute = ['/publishers', this.activatedRoute.snapshot.params.id, 'view'];

            this.PublishersService.get(this.activatedRoute.snapshot.params.id).pipe(take(1)).subscribe((response: GraphQLResponse<Publisher>) => {
                // update data object and form data to response data, then set form as initialized
                this.publisher = response.data;
                this.form.patchValue({
                    name: this.publisher.name,
                });
            });
        }

        else{
            this.PublishersService.getAll().subscribe(( response: GraphQLResponse<Publisher[]> ) => {
               this.data = response.data;

            });

        }

    }
    ngOnDestroy(){
        this.ngUnsubscribe.next();
        this.ngUnsubscribe.complete();
    }

    public save = (): void => {

        if (this.form.value.name === ''){
            this.pageService.clearErrors();
            this.toastService.error('Empty values are not allowed!', 'Publisher Not Created');
            return;
        }
        for (let i = 0 ; i < this.data.length; i++){
            if (this.form.value.name.toUpperCase().trim() === this.data[i].name.toUpperCase()){
                this.pageService.clearErrors();
                this.toastService.error('The Publisher already exists!', 'Publisher Not Created');
                return;
            }

        }

        this.pageService.setLoading(true);
        this.pageService.clearErrors();

        const action = this.PublishersService.create;
        action(Object.assign({}, this.publisher, this.form.value, {
            type: 'local'

        })).pipe(
            take(1),
            finalize(() => {
                this.pageService.setLoading(false);
            })
        ).subscribe(response => {
            if (response.success) {
                this.toastService.success('The publisher was created successfully!', 'Publisher created');
                this.form.markAsPristine();
                this.form.markAsUntouched();
                this.router.navigate(this.backRoute);

            }
            else{
                this.toastService.error('The publisher was not created!', 'Publisher Not Created');
                this.form.markAsPristine();
                this.form.markAsUntouched();
                this.router.navigate(this.backRoute);
            }

        });
    }
}
