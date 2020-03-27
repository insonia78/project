import { Component, OnInit } from '@angular/core';

import { AssignmentService } from './assignment.service';
import { PageActions, PageService } from '@spidersmart/core';

@Component({
  selector: 'sm-assignment',
  templateUrl: './assignment.component.html',
  styleUrls: ['./assignment.component.scss']
})
export class AssignmentComponent implements OnInit {
  public assignments;
  constructor(private assignmentService: AssignmentService, private pageService: PageService) {
    this.assignments = this.assignmentService.getAll();
  }

  ngOnInit() {
    this.pageService.setTitle('Manage Assignments');
    this.pageService.addRoutingAction(PageActions.create, ['/assignment', 'create']);
  }
}
