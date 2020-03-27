import { Component, OnInit, OnDestroy} from '@angular/core';
import { FormGroup, FormBuilder, AsyncValidatorFn } from '@angular/forms';
import { takeUntil, take, catchError, finalize } from 'rxjs/operators';

import { GraphQLResponse, PageMode, TextMask, PageService, ValidatorService, PageActions, PageActionPosition, Author } from '@spidersmart/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject } from 'rxjs';
import { AuthorService } from './author.service';
import { ToastrService } from 'ngx-toastr';

@Component({
    selector: 'sm-author-form',
    templateUrl: './author-form.component.html'
})
export class AuthorFormComponent implements OnInit, OnDestroy {

    public author: Author = {
        id: null,
        name: '',
        dateFrom: null

    };
    private data: any;

    public form: FormGroup;
    protected apiValidator: AsyncValidatorFn = ValidatorService.ApiValidator(this.pageService);
    private ngUnsubscribe: Subject<any> = new Subject();
    public backRoute = ['/authors'];
    constructor(
        private fb: FormBuilder,
        private activatedRoute: ActivatedRoute,
        private router: Router,
        private pageService: PageService,
        private AuthorService: AuthorService,
        private toastService: ToastrService,
    ){
        this.form = this.fb.group({
            name: ['', null, this.apiValidator]
        });
    }

    ngOnInit(){
        this.pageService.setTitle('Create Author');
        this.pageService.setMode(PageMode.CREATE);
        if (this.activatedRoute.snapshot.params.hasOwnProperty('id')) {
            this.pageService.setMode(PageMode.EDIT);
            this.pageService.setTitle('Edit Author');
            this.backRoute = ['/authors', this.activatedRoute.snapshot.params.id, 'view'];

            this.AuthorService.get(this.activatedRoute.snapshot.params.id).pipe(take(1)).subscribe((response: GraphQLResponse<Author>) => {
                // update data object and form data to response data, then set form as initialized
                this.author = response.data;
                this.form.patchValue({
                    name: this.author.name,
                });
            });
        }
        else{
              this.AuthorService.getAll().subscribe((response: GraphQLResponse<Author[]>) => {
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
            this.toastService.error('Empty values are not allowed!', 'Author Not Created');
            return;
        }
        for (let i = 0 ; i < this.data.length; i++){
            if (this.form.value.name.toUpperCase().trim() === this.data[i].name.toUpperCase()){
                this.pageService.clearErrors();
                this.toastService.error('The author already exists!', 'Author Not Created');
                return;
            }

        }


        this.pageService.setLoading(true);
        this.pageService.clearErrors();
        const action = (this.pageService.isMode(PageMode.EDIT)) ? this.AuthorService.modify : this.AuthorService.create;
        action(Object.assign({}, this.author, this.form.value, {
            type: 'local'

        })).pipe(
            take(1),
            finalize(() => {
                this.pageService.setLoading(false);
            })
        ).subscribe(response => {
            console.log('RRR:', response);
            if ( action === this.AuthorService.create){
                if (response.success) {
                    this.toastService.success('The author was created successfully!', 'Author created');
                    this.form.markAsPristine();
                    this.form.markAsUntouched();
                    this.router.navigate(this.backRoute);

                }
                else{
                    this.toastService.error('The author was not created!', 'Author Not Created');
                    this.form.markAsPristine();
                    this.form.markAsUntouched();
                    this.router.navigate(this.backRoute);
                }
            }
            else if ( action === this.AuthorService.modify){
                if (response.success) {
                    this.toastService.success('The author was updated successfully!', 'Author updated');
                    this.form.markAsPristine();
                    this.form.markAsUntouched();
                    this.router.navigate(this.backRoute);
                }
                else{
                    this.toastService.error('The author was not updated!', 'Author Not Upated');
                    this.form.markAsPristine();
                    this.form.markAsUntouched();
                    this.router.navigate(this.backRoute);
                }
            }
        });
    }
}
