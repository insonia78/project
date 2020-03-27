import { Routes } from '@angular/router';

import { AssignmentComponent } from './assignment.component';
import { AssignmentViewComponent } from './assignment-view.component';
import { AssignmentFormComponent } from './assignment-form.component';

export const routes: Routes = [
  {
    path: '',
    component: AssignmentComponent,
    pathMatch: 'full'
  },
  {
    path: 'create',
    component: AssignmentFormComponent,
    pathMatch: 'full'
  },
  {
    path: ':id/view',
    component: AssignmentViewComponent,
    pathMatch: 'full'
  },
  {
    path: ':id/edit',
    component: AssignmentFormComponent,
    pathMatch: 'full'
  }
];
