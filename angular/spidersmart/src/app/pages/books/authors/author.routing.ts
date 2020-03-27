import { Routes } from '@angular/router';
import { AuthorComponent } from './author.component';
import { AuthorFormComponent } from './author-form.component';
import { AuthorViewComponent } from './author-view.component';
export const routes: Routes = [
    {
      path: '',
      component: AuthorComponent,
      pathMatch: 'full'
    },
    {
      path: 'create',
      component: AuthorFormComponent,
      pathMatch: 'full'
    },
    {
      path: ':id/view',
      component: AuthorViewComponent,
      pathMatch: 'full'
    },
    {
      path: ':id/edit',
      component: AuthorFormComponent,
      pathMatch: 'full'
    }
];
