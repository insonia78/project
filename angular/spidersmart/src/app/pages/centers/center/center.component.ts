import { Component, OnInit } from '@angular/core';

import { CenterService } from './center.service';
import { PageActions, PageService, PageActionPosition } from '@spidersmart/core';

@Component({
  selector: 'sm-center',
  templateUrl: './center.component.html',
  styleUrls: ['./center.component.scss']
})
export class CenterComponent implements OnInit {
  public centers;
  constructor(
    private centerService: CenterService,
    private pageService: PageService
  ) {

  }

  ngOnInit() {
    this.centers = this.centerService.getAll();
    console.log('ng on init!!!');
    this.pageService.setTitle('Manage Centers');
    this.pageService.addRoutingAction(PageActions.create, ['/center', 'create']);
  }
}
