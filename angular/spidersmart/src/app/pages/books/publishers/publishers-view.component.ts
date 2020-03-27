import { Component, OnInit, OnDestroy } from '@angular/core';
import { take } from 'rxjs/operators';

import { Publisher, GraphQLResponse, PageActions, PageService, PageActionPosition } from '@spidersmart/core';
import { PublishersService } from './publishers.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'sm-publishers-view',
  templateUrl: './publishers-view.component.html'
})
export class PublishersViewComponent implements OnInit {
  /** The current center */
  public publisher: Publisher;

  constructor(
    private publishersService: PublishersService,
    private activatedRoute: ActivatedRoute,
    private pageService: PageService
  ) { }

  ngOnInit() {
    if (this.activatedRoute.snapshot.params.hasOwnProperty('id')) {
      this.publishersService.get(this.activatedRoute.snapshot.params.id).pipe(take(1)).subscribe((response: GraphQLResponse<Publisher>) => {
        console.log('data:' + response.data);
        this.publisher = response.data;
        this.pageService.setTitle(response.data.name);
      });

      this.pageService.addRoutingAction(PageActions.create, ['/publishers', 'create']);
    }
  }
  /*
  public edit = (route) => {
    alert('EDIT' + route);
  }
  */
}
