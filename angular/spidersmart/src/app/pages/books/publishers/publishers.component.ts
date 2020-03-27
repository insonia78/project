import { Component, OnInit } from '@angular/core';
import { PublishersService } from './publishers.service';
import { PageService, PageActions } from '@spidersmart/core';

@Component({
  selector: 'sm-publishers',
  templateUrl: './publishers.component.html',
  styleUrls: ['./publishers.component.scss']
})
export class PublishersComponent implements OnInit {
  public publishers;
  constructor(private publishersService: PublishersService, private pageService: PageService) {
     this.publishers = this.publishersService.getAll();
  }

  ngOnInit() {
    this.pageService.setTitle( 'Publishers' );
    this.pageService.addRoutingAction(PageActions.create, ['/publishers', 'create']);
  }


}
