import { Component, OnInit, OnDestroy } from '@angular/core';
import { take } from 'rxjs/operators';

import { Author, GraphQLResponse, PageActions, PageService, PageActionPosition } from '@spidersmart/core';
import { AuthorService } from './author.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'sm-author-view',
  templateUrl: './author-view.component.html'
})
export class AuthorViewComponent implements OnInit {
  /** The current center */
  public author: Author;

  constructor(
    private authorService: AuthorService,
    private activatedRoute: ActivatedRoute,
    private pageService: PageService
  ) { }

  ngOnInit() {
    if (this.activatedRoute.snapshot.params.hasOwnProperty('id')) {
      this.authorService.get(this.activatedRoute.snapshot.params.id).pipe(take(1)).subscribe((response: GraphQLResponse<Author>) => {
        console.log('data:' + response.data);
        this.author = response.data;
        this.pageService.setTitle(response.data.name);
      });

      this.pageService.addRoutingAction(PageActions.edit, ['/authors', this.activatedRoute.snapshot.params.id, 'edit']);
    }
  }

  public edit = (route) => {
    alert('EDIT' + route);
  }
}
