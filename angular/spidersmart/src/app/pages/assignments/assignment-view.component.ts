import { Component, OnInit } from '@angular/core';

import { Assignment, GraphQLResponse, PageService, PageActionPosition, PageActions } from '@spidersmart/core';
import { AssignmentService } from './assignment.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'sm-assignment-view',
  templateUrl: './assignment-view.component.html'
})
export class AssignmentViewComponent implements OnInit {
  /** The current assignment */
  public assignment: Assignment;

  constructor(
    private assignmentService: AssignmentService,
    private activatedRoute: ActivatedRoute,
    private pageService: PageService
  ) { }

  ngOnInit() {
    if (this.activatedRoute.snapshot.params.hasOwnProperty('id')) {
      this.assignmentService.get(this.activatedRoute.snapshot.params.id).subscribe((response: GraphQLResponse<Assignment>) => {
        this.assignment = response.data;
        this.pageService.setTitle(response.data.title);
      });

      this.pageService.addRoutingAction(PageActions.edit, ['/assignment', this.activatedRoute.snapshot.params.id, 'edit']);
    }
  }
}
