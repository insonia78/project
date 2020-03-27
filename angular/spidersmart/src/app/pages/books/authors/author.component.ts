import { Component, OnInit } from '@angular/core';
import { PageActions, PageService } from '@spidersmart/core';
import { AuthorService } from './author.service';

@Component({
  selector: 'sm-author',
  templateUrl: './author.component.html',
  styleUrls: ['./author.component.scss']
})
export class AuthorComponent implements OnInit {
  public authors;
  constructor(private authorsService: AuthorService, private pageService: PageService) {
     console.log('author.component.ts');
     this.authors = this.authorsService.getAll();

  }

  ngOnInit() {
    this.pageService.setTitle( 'Authors' );
    this.pageService.addRoutingAction(PageActions.create, ['/authors', 'create']);

  }
}
