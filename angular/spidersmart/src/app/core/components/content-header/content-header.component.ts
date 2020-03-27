import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { PageService } from '../../services/page.service';
import { PageActionPosition } from '../../enums/page-action-position.enum';

@Component({
  selector: 'app-content-header',
  templateUrl: './content-header.component.html',
  styleUrls: ['./content-header.component.scss'],
})
export class ContentHeaderComponent {
  public PageActionPosition = PageActionPosition;

  constructor(
    public pageService: PageService,
    private router: Router
  ) {}
}
