import { Routes } from '@angular/router';

import { StudentComponent } from './student.component';
import { StudentViewComponent } from './student-view.component';
import { StudentFormComponent } from './student-form.component';
import { StudentFormAction } from './student-form-action.enum';

export const routes: Routes = [
  {
    path: '',
    component: StudentComponent,
    pathMatch: 'full',
  },
  {
    path: 'create',
    component: StudentFormComponent,
    pathMatch: 'full',
  },
  {
    path: ':id/view',
    component: StudentViewComponent,
    pathMatch: 'full',
  },
  {
    path: ':id/edit',
    component: StudentFormComponent,
    pathMatch: 'full',
    data: { action: StudentFormAction.DETAILS }
  },
  {
    path: ':id/contacts',
    component: StudentFormComponent,
    pathMatch: 'full',
    data: { action: StudentFormAction.CONTACTS }
  },
  {
    path: ':id/enrollments',
    component: StudentFormComponent,
    pathMatch: 'full',
    data: { action: StudentFormAction.ENROLLMENTS }
  }
];
