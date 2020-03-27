import { Component, OnInit, OnDestroy } from '@angular/core';
import { take, takeUntil, finalize } from 'rxjs/operators';
import { StudentService } from './student.service';
import { PageActions, Student, PageService, AppContextService, CenterContext, GraphQLResponse } from '@spidersmart/core';
import { Subject, combineLatest, BehaviorSubject, isObservable } from 'rxjs';

/**
 * Component to display list of all students
 */
@Component({
  selector: 'sm-student',
  templateUrl: './student.component.html'
})
export class StudentComponent implements OnInit, OnDestroy {
  /** Subject of current student data, we need this to trigger changes to the data source from this end */
  public students: Subject<GraphQLResponse<Student[]>> = new BehaviorSubject<GraphQLResponse<Student[]>>({
    loading: true,
    data: []
  });
  /** Subject to ensure all subscriptions close when element is destroyed */
  private ngUnsubscribe: Subject<any> = new Subject();

  /**
   * @ignore
   */
  constructor(
    private studentService: StudentService,
    private pageService: PageService,
    private appContextService: AppContextService
  ) { }

  /**
   * @ignore
   */
  ngOnInit() {
    this.pageService.setTitle('Manage Students');
    this.pageService.addRoutingAction(PageActions.create, ['/student', 'create']);

    // set data source to reload (and potentially change) based on changes in center context
    combineLatest([
      this.appContextService.getCenterContext(),
      this.appContextService.getCenter()
    ]).pipe(
      takeUntil(this.ngUnsubscribe)
    ).subscribe(([context, center]) => {
      // determine correct data source based on current context status
      let dataSource;
      if (context === CenterContext.SPECIFIC_CENTER && center.hasOwnProperty('id')) {
        dataSource = this.studentService.getAllFromCenter(center.id);
      }
      else if (context === CenterContext.ALL_CENTERS) {
        dataSource = this.studentService.getAll();
      }

      // update subject with result
      if (isObservable(dataSource)) {
        this.pageService.setLoading(true);
        dataSource.pipe(
          take(1),
          finalize(() => {
              this.pageService.setLoading(false);
          })
        ).subscribe((students: GraphQLResponse<Student[]>) => {
          this.students.next(students);
        });
      }
    });
  }

  /**
   * @ignore
   */
  ngOnDestroy() {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }
}
