import { Component, OnInit } from '@angular/core';
import { take, finalize } from 'rxjs/operators';
import { cloneDeep } from 'lodash';

import { Center, Contact, Student, Level, Enrollment, GraphQLResponse, PageMode, PageService, PageActionPosition, PageActions, ValidatorService } from '@spidersmart/core';
import { StudentService } from './student.service';
import { StudentFormAction } from './student-form-action.enum';
import { ActivatedRoute, Router } from '@angular/router';
import { FormGroup, AsyncValidatorFn, FormBuilder } from '@angular/forms';

@Component({
    selector: 'sm-student-form',
    templateUrl: './student-form.component.html',
    styleUrls: ['./student-form.component.scss']
})
export class StudentFormComponent implements OnInit {
    /** The current student */
    public student: Student = {
        id: null,
        email: '',
        prefix: '',
        firstName: '',
        middleName: '',
        lastName: '',
        suffix: '',
        gender: 'M',
        school: '',
        dateOfBirth: null,
        theme: '',
        active: true,
        verified: false,
        enrollments: [],
        contacts: [],
        dateFrom: null
    };
    public form: FormGroup;
    public backRoute = ['/student'];
    protected apiValidator: AsyncValidatorFn = ValidatorService.ApiValidator(this.pageService);


    /** Template access to page mode and page actions */
    public PageMode = PageMode;
    public StudentFormAction = StudentFormAction;
    /** The current student and representation of the cache student */
    public studentCache: Student = null;
    /** Object to hold gender options */
    public genders = [
        {
            label: 'Male',
            value: 'M'
        },
        {
            label: 'Female',
            value: 'F'
        }
    ];
    /** The current state of contacts */
    public contacts: Contact[] = [];
    /** The current state of enrollments */
    public enrollments: Enrollment[] = [];
    /** The current edit mode */
    public editMode: StudentFormAction = StudentFormAction.DETAILS;
    /** If we are showing the password in plain text */
    public showPassword: boolean = false;

    constructor(
        private fb: FormBuilder,
        private activatedRoute: ActivatedRoute,
        private router: Router,
        public pageService: PageService,
        private studentService: StudentService
    ) {
        // define form structure
        this.form = this.fb.group({
            email: ['', null, this.apiValidator],
            password: ['', null, this.apiValidator],
            prefix: ['', null, this.apiValidator],
            firstName: ['', null, this.apiValidator],
            middleName: ['', null, this.apiValidator],
            lastName: ['', null, this.apiValidator],
            suffix: ['', null, this.apiValidator],
            gender: ['', null, this.apiValidator],
            school: ['', null, this.apiValidator],
            dateOfBirth: ['', null, this.apiValidator]
        });
    }

    ngOnInit() {
        this.pageService.setTitle('Create Student');
        this.pageService.setMode(PageMode.CREATE);

        // if there is an id, then we are in edit mode so there are a few extra tasks to perform
        if (this.activatedRoute.snapshot.params.hasOwnProperty('id')) {
            this.pageService.setMode(PageMode.EDIT);
            this.pageService.setTitle('Edit Student');
            if (this.activatedRoute.snapshot.data.hasOwnProperty('action')) {
                this.editMode = this.activatedRoute.snapshot.data.action;
            }
            this.backRoute = ['/student', this.activatedRoute.snapshot.params.id, 'view'];

            this.studentService.get(this.activatedRoute.snapshot.params.id).pipe(take(1)).subscribe((response: GraphQLResponse<Student>) => {
                // update the data cache with the retrieved data
                this.studentCache = response.data;

                // create a clone of the cache for use in the component for manipulation through UI
                // any changes made to a direct reference to the response will result in the cache updating as well
                // which can cause unintended consequences
                // this.student = cloneDeep(this.studentCache);
                this.student = response.data;

                console.log('STUDENT', this.student);
                // patch the form with current values
                this.form.patchValue({
                    email: this.student.email,
                    prefix: this.student.prefix,
                    firstName: this.student.firstName,
                    middleName: this.student.middleName,
                    lastName: this.student.lastName,
                    suffix: this.student.suffix,
                    gender: this.student.gender,
                    school: this.student.school,
                    dateOfBirth: new Date(this.student.dateOfBirth),
                });

                // set contacts
                this.contacts = this.student.contacts;

                // set enrollments
                this.enrollments = this.student.enrollments;
            });
        }
    }

    /**
     * Update the current contacts reference with given
     * @param contacts The contacts to which the current contacts should be updated
     */
    public updateContacts(contacts: Contact[]): void {
        this.contacts = this.formatContacts(contacts);
    }

    public formatContacts(contacts: Contact[]): Contact[] {
        for (let i = contacts.length - 1; i >= 0; i--) {
            contacts[i].value = contacts[i].value.replace(/[^\w\s]/gi, '').replace(/\s/g, '');
        }
        return contacts;
    }

    /**
     * Update the current enrollments reference with given
     * @param enrollments The enrollments to which the current enrollments should be updated
     */
    public updateEnrollments(enrollments: Enrollment[]): void {
        this.enrollments = enrollments;
    }

    /**
     * Saves the current form state
     * @return void
     */
    public save = (): void => {
        this.pageService.setLoading(true);
        this.pageService.clearErrors();

        // prepare enrollments
        const preparedEnrollments = [];
        this.enrollments.forEach(enrollment => {
            preparedEnrollments.push({
                id: enrollment.id,
                user: null,
                center: this.prepareRelationForMutate<Center>(enrollment.center, ['id']),
                level: this.prepareRelationForMutate<Level>(enrollment.level, ['id']),
                tuitionRate: enrollment.tuitionRate
            });
        });

        const action = (this.pageService.isMode(PageMode.EDIT)) ? this.studentService.modify : this.studentService.create;
        action(Object.assign({}, this.student, this.form.value, {
            contacts: this.prepareRelationForMutate<Contact>(this.contacts, ['id', 'type', 'title', 'value']),
            enrollments: preparedEnrollments
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
     * TODO: FACTOR THIS OUT
     * Retuns a copy of the given relation with all properties stripped except for the given fields to prepare it for submission
     * via a graphql mutate request to the server
     * @param relation The object from which properties should be stripped
     * @param keep The properties which should not be stripped
     * @return The given object with typename stripped
     */
    protected prepareRelationForMutate<T>(relation: T | T[], keep: String | String[] = []): T | T[] {
        const updatedRelation = cloneDeep(relation);
        keep = (keep instanceof Array) ? keep : [keep];
        if (updatedRelation instanceof Array) {
            return updatedRelation.map((rel: T) => {
                for (const prop in rel) {
                    if (keep instanceof Array && !keep.includes(prop)) {
                        delete rel[prop];
                    }
                }
                // if (rel.hasOwnProperty('__typename')) {
                //     delete rel['__typename'];
                // }
                return rel;
            });
        }
        else {
            for (const prop in updatedRelation) {
                if (!keep.includes(prop)) {
                    delete updatedRelation[prop];
                }
            }
            console.log(updatedRelation);
            // if (relation.hasOwnProperty('__typename')) {
            //     delete relation['__typename'];
            // }
            return updatedRelation;
        }
    }



    /**
     * Hides the text in the password field
     * @return void
     */
    public hidePassword() {
        this.showPassword = false;
    }

    /**
     * Toggles between showing and hiding the text in the password field
     * @return void
     */
    public togglePassword() {
        this.showPassword = !(this.showPassword);
    }
}
