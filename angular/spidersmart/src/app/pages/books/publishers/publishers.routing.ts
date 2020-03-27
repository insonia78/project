import { Routes } from '@angular/router';

import { PublishersComponent } from './publishers.component';
import { PublishersViewComponent } from './publishers-view.component';
import { PublishersFormComponent } from './publishers-form.component';
export const routes: Routes = [
    {
      path: '',
      component: PublishersComponent,
      pathMatch: 'full'
    },
    {
      path: 'create',
      component: PublishersFormComponent,
      pathMatch: 'full'
    },
    {
      path: ':id/view',
      component: PublishersViewComponent,
      pathMatch: 'full'
    }
];
