import { Component, OnInit, OnDestroy } from '@angular/core';

import { Contact, Student, GraphQLResponse, ContactType, PageService, PageActionPosition, PageActions } from '@spidersmart/core';
import { StudentService } from './student.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'sm-student-view',
  templateUrl: './student-view.component.html',
  styleUrls: ['./student-view.component.scss']
})
export class StudentViewComponent implements OnInit {
  /** The current student */
  public student: Student;
  /** Reference to the ContactType enum */
  public ContactType = ContactType;

  constructor(
    private studentService: StudentService,
    private activatedRoute: ActivatedRoute,
    private pageService: PageService
  ) { }

  ngOnInit() {
    if (this.activatedRoute.snapshot.params.hasOwnProperty('id')) {
      this.studentService.get(this.activatedRoute.snapshot.params.id).subscribe((response: GraphQLResponse<Student>) => {
        this.student = response.data;
        this.pageService.setTitle(this.student.firstName + ' ' + this.student.lastName);
      });

      this.pageService.addRoutingAction(PageActions.edit, ['/student', this.activatedRoute.snapshot.params.id, 'edit']);
      this.pageService.addRoutingAction(PageActions.contacts, ['/student', this.activatedRoute.snapshot.params.id, 'contacts']);
      this.pageService.addRoutingAction(PageActions.enrollments, ['/student', this.activatedRoute.snapshot.params.id, 'enrollments']);
      this.pageService.addFunctionAction(PageActions.delete, this.delete, [this.activatedRoute.snapshot.params.id]);
    }
  }

  public delete = (id) => {
    alert('Oh no!  This feature is not yet available.  Whew, lucky thing since you wouldn\'t want to delete this student, right... right?');
    alert('DELETE' + id);
  }

  public generateContactLink(contact: Contact): string {
    switch (contact.type) {
      case ContactType.HOME_PHONE:
      case ContactType.MOBILE_PHONE:
      case ContactType.WORK_PHONE:
        return 'tel:' + contact.value;
      case ContactType.EMAIL:
        return 'mailto:' + contact.value;
      default:
        return contact.value;
    }
  }
}

/**
 * TODO: CONTEXT SWITCHING
 * if we are in an invalid area for new context - switch:
 *    for example (switch context from GB to GT), if we are in Gaithersburg Context on center page (view/edit/etc.), switch to VIEW (always) for Germantown
 *    for example (switch context from All to GT), if we are on centers list page, switch to VIEW page for GT
 *    similarly (switch context from All to GT), if we are on students list page, switch from /students to center/1/students
 *
 * THE CONVENTION WILL BE, UPON CONTEXT SWITCH - GO TO DEFAULT PAGE FOR THE TOP ROOT YOU ARE IN
 */
