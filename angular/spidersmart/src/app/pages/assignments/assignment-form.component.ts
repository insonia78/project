import { Component, OnInit } from '@angular/core';

import { Assignment, GraphQLResponse, PageMode, PageService, ValidatorService, PageActionPosition, PageActions } from '@spidersmart/core';
import { AssignmentService } from './assignment.service';
import { FormBuilder, FormGroup, AsyncValidatorFn } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject } from 'rxjs';
import { take, finalize } from 'rxjs/operators';

@Component({
    selector: 'sm-assignment-form',
    templateUrl: './assignment-form.component.html'
})
export class AssignmentFormComponent implements OnInit {
    /** The current assignment */
    public assignment: Assignment = {
        id: null,
        book: null,
        title: '',
        level: null,
        active: true,
        dateFrom: null,
    };
    public form: FormGroup;
    public backRoute = ['/assignment'];
    protected apiValidator: AsyncValidatorFn = ValidatorService.ApiValidator(this.pageService);
    private ngUnsubscribe: Subject<any> = new Subject();

    constructor(
        private fb: FormBuilder,
        private activatedRoute: ActivatedRoute,
        private router: Router,
        private pageService: PageService,
        private assignmentService: AssignmentService
    ) {
        // define form structure
        this.form = this.fb.group({
            name: '',
            label: '',
            streetAddress: '',
            city: '',
            state: '',
            postalCode: ['', null, this.apiValidator],
            country: ['', null, this.apiValidator],
            email: '',
            phone: '',
            fax: ''
        });
    }

    ngOnInit() {
        this.pageService.setTitle('Create Assignment');
        this.pageService.setMode(PageMode.CREATE);

        // if there is an id, then we are in edit mode so there are a few extra tasks to perform
        if (this.activatedRoute.snapshot.params.hasOwnProperty('id')) {
            this.pageService.setMode(PageMode.EDIT);
            this.pageService.setTitle('Edit Assignment');
            this.backRoute = ['/assignment', this.activatedRoute.snapshot.params.id, 'view'];

            this.assignmentService.get(this.activatedRoute.snapshot.params.id).subscribe((response: GraphQLResponse<Assignment>) => {
                // update data object and form data to response data, then set form as initialized
                this.assignment = response.data;
                this.form.patchValue({
                    title: this.assignment.title,
                    // ...
                });
            });
        }
    }

    /**
     * Saves the current form state
     * @return void
     */
    public save = (): void => {
        this.pageService.setLoading(true);
        this.pageService.clearErrors();

        const action = (this.pageService.isMode(PageMode.EDIT)) ? this.assignmentService.modify : this.assignmentService.create;
        action(Object.assign({}, this.assignment, this.form.value, {
            type: 'local'
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
}
