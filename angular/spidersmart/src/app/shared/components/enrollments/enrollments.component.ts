import { Component, OnInit, Input, OnChanges, Output, EventEmitter } from '@angular/core';
import { FormGroup, FormBuilder, FormArray } from '@angular/forms';

import { Center, Enrollment, Level, Subject, EmptyEnrollment } from '@spidersmart/core';
import { takeWhile, takeUntil } from 'rxjs/operators';


@Component({
    selector: 'sm-enrollments',
    templateUrl: './enrollments.component.html'
})
export class EnrollmentsComponent implements OnInit, OnChanges {
    /** The form to edit contacts in edit  mode */
    public form: FormGroup;
    /** Available subjects, levels, and centers */
    public availableCenters = <Center[]>[
        <Center>{
            id: 1,
            type: 'local',
            name: 'Gaithersburg',
            label: 'gaithersburg',
            streetAddress: '420 Main St',
            city: 'Gaithersburg',
            state: 'MD',
            postalCode: '20878',
            country: 'US',
            dateFrom: new Date('2012-06-15'),
            dateTo: null,
            email: 'gaithersburg@spidersmart.com',
            phone: '3019901179',
            availableSubjects: <Subject[]>[
                <Subject>{
                    id: 1,
                    name: 'Reading/Writing',
                    description: null,
                    active: true,
                    availableLevels: <Level[]>[
                        <Level>{
                            id: 1,
                            name: 'RW 1',
                            description: null
                        },
                        <Level>{
                            id: 2,
                            name: 'RW 2',
                            description: null
                        }
                    ]
                },
                <Subject>{
                    id: 2,
                    name: 'Math',
                    description: null,
                    active: true,
                    availableLevels: <Level[]>[
                        <Level>{
                            id: 3,
                            name: 'Math 1',
                            description: null
                        },
                        <Level>{
                            id: 4,
                            name: 'Math 2',
                            description: null
                        }
                    ]
                }
            ]
        },
        <Center>{
            id: 2,
            type: 'local',
            name: 'Germantown',
            label: 'germantown',
            streetAddress: '19739 Executive Park Circle',
            city: 'Germantown',
            state: 'MD',
            postalCode: '20874',
            country: 'US',
            dateFrom: new Date('2014-06-15'),
            dateTo: null,
            email: 'gaithersburg@spidersmart.com',
            phone: '3015285551',
            availableSubjects: <Subject[]>[
                <Subject>{
                    id: 1,
                    name: 'Reading/Writing',
                    description: null,
                    active: true,
                    availableLevels: <Level[]>[
                        <Level>{
                            id: 1,
                            name: 'RW 1',
                            description: null
                        },
                        <Level>{
                            id: 2,
                            name: 'RW 2',
                            description: null
                        }
                    ]
                }
            ]
        }
    ];

    /** The internal list of contacts */
    protected currentEnrollments: Enrollment[] = [];

    /** The enrollments provided when loading */
    @Input()
    set enrollments(enrollments: Enrollment[]) {
        console.log('SETTING ENROLLMENTS TO', enrollments);
        if (enrollments) {
            // TODO: CONVERT STRUCTURE TO HAVE SUBJECT AND LEVEL AS SEPARATE TOP LEVEL PROPERTIES IN THE ENROLLMENT OBJECT
            // PERHAPS WE NEED A DIFFERENTIATION BETWEEN AN ENROLLMENT OBJECT WHICH REPRESENTS THE DATA STRUCTURE IN API AND
            // AN ENROLLMENT AS REPRESENTED HERE
            for (const enrollment of enrollments) {
                if (!enrollment.hasOwnProperty('subject') && enrollment.hasOwnProperty('level') && enrollment.level.hasOwnProperty('subject')) {
                    enrollment.subject = enrollment.level.subject;
                }
            }
            this.currentEnrollments = enrollments;
        }
    }
    /** The current mode of the component */
    @Input() mode: 'VIEW' | 'EDIT' = 'VIEW';
    /** The layout type of the component */
    @Input() layout: 'LIST' | 'TABLE' = 'LIST';
    /** The context view of the component */
    @Input() context: 'USER' | 'CENTER' = 'USER';
    /** If adding new enrollments are allowed in edit mode */
    @Input() canAdd: boolean = true;
    /** If remove enrollments are allowed in edit mode */
    @Input() canRemove: boolean = true;
    /** If the center of the enrollment is selectable in edit mode */
    // TODO:  ADD SUPPORT FOR CHANGING CENTERS, NEED AN INPUT TO PROVIDE AVAILABLE CENTERS OR DERIVE IT IN THE COMPONENT
    // BASED ON SYSTEM WIDE CONTEXT - IDEALLY ALLOW THE FORMER AS AN OVERRIDE BUT DEFAULT TO LATTER
    @Input() canChangeCenter: boolean = false;

    /** Output the current value of contacts */
    @Output() valueChange = new EventEmitter<Enrollment[]>();

    constructor(private fb: FormBuilder) {
        // define form structure
        this.form = this.fb.group({
            enrollments: this.fb.array([])
        });
    }

    /**
     * Adds a new empty enrollment
     * @return void
     */
    public addEnrollment(): void {
        if (this.mode === 'EDIT') {
            this.currentEnrollments.push(EmptyEnrollment);
            this.syncEnrollmentsToForm();
            this.emitChange();
        }
    }

    /**
     * Removes the enrollment at the given index
     * @param index The index at which the enrollment to remove exists
     * @return void
     */
    public removeEnrollment(index: number): void {
        if (this.mode === 'EDIT') {
            this.currentEnrollments.splice(index, 1);
            this.syncEnrollmentsToForm();
            this.emitChange();
        }
    }

    /**
     * Syncs the form to match the current contacts array
     * @return void
     */
    private syncEnrollmentsToForm(): void {
        if (this.mode === 'EDIT') {
            if (this.currentEnrollments) {
                const enrollmentsArray: FormGroup[] = [];
                this.currentEnrollments.forEach(enrollment => {
                    const enrollmentCenter = (enrollment.center) ? this.availableCenters.find(center => enrollment.center !== null && center.id === enrollment.center.id) : null;
                    const enrollmentSubject = (enrollmentCenter) ? enrollmentCenter.availableSubjects.find(subject => enrollment.level !== null && enrollment.level.subject !== null && subject.id === enrollment.subject.id) : null;
                    const enrollmentLevel = (enrollmentSubject) ? enrollmentSubject.availableLevels.find(level => level.id === enrollment.level.id) : null;

                    console.log('ADD NEW FORM ELEMENT', enrollmentCenter, enrollmentSubject, enrollmentLevel);
                    const ctrl = this.fb.group(Object.assign({}, enrollment, {
                        center: enrollmentCenter,
                        level: enrollmentLevel,
                        subject: enrollmentSubject
                    }));
                    enrollmentsArray.push(ctrl);
                });
                this.form.setControl('enrollments', this.fb.array(enrollmentsArray));
                this.form.get('enrollments').valueChanges.subscribe(val => {
                    this.currentEnrollments = val;
                    console.log('CE SET TO::::', this.currentEnrollments);
                    this.emitChange();
                });
                for (const enrollment of (this.form.get('enrollments') as FormArray).controls) {
                    enrollment.get('center').valueChanges.subscribe(center => {
                        enrollment.get('level').reset();
                        enrollment.get('subject').reset();
                    });
                    enrollment.get('subject').valueChanges.subscribe(subject => {
                        enrollment.get('level').reset();
                    });
                }
            }
        }
    }

    /**
     * Emits the current enrollments value
     * @return void
     */
    private emitChange(): void {
        this.valueChange.emit(this.currentEnrollments);
    }

    ngOnInit() {
        if (this.mode === 'EDIT') {

            /* this.form.get('enrollments').valueChanges.subscribe(val => {
                this.currentEnrollments = val;
                this.emitChange();
                console.log('enrollments change!!!');
            }); */
            console.log('INIT', this.currentEnrollments);
        }
    }

    ngOnChanges() {
        this.syncEnrollmentsToForm();
    }
}
