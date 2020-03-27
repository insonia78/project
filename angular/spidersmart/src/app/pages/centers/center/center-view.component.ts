import { Component, OnInit, OnDestroy } from '@angular/core';
import { take } from 'rxjs/operators';

import { Center, GraphQLResponse, PageActions, PageService, PageActionPosition } from '@spidersmart/core';
import { CenterService } from './center.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'sm-center-view',
  templateUrl: './center-view.component.html'
})
export class CenterViewComponent implements OnInit {
  /** The current center */
  public center: Center;

  constructor(
    private centerService: CenterService,
    private activatedRoute: ActivatedRoute,
    private pageService: PageService
  ) { }

  ngOnInit() {
    if (this.activatedRoute.snapshot.params.hasOwnProperty('id')) {
      this.centerService.get(this.activatedRoute.snapshot.params.id).pipe(take(1)).subscribe((response: GraphQLResponse<Center>) => {
        this.center = response.data;
        this.pageService.setTitle(response.data.name);
      });

      this.pageService.addRoutingAction(PageActions.edit, ['/center', this.activatedRoute.snapshot.params.id, 'edit']);
    }
  }

  public edit = (route) => {
    alert('EDIT' + route);
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
