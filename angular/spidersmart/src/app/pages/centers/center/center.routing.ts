import { Routes } from '@angular/router';

import { CenterComponent } from './center.component';
import { CenterViewComponent } from './center-view.component';
import { CenterFormComponent } from './center-form.component';

export const routes: Routes = [
  {
    path: '',
    component: CenterComponent,
    pathMatch: 'full'
  },
  {
    path: 'create',
    component: CenterFormComponent,
    pathMatch: 'full'
  },
  {
    path: ':id/view',
    component: CenterViewComponent,
    pathMatch: 'full'
  },
  {
    path: ':id/edit',
    component: CenterFormComponent,
    pathMatch: 'full'
  }
];
