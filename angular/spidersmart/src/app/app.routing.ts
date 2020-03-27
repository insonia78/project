import { Routes } from '@angular/router';
import { DashboardComponent } from './pages/dashboard/dashboard.component';

export const routes: Routes = [
  { path: '', component: DashboardComponent, data: { noReuse: true } },
  { path: 'center', loadChildren: () => import('./pages/centers/center/center.module').then(m => m.CenterModule), data: { noReuse: true } },
  { path: 'student', loadChildren: () => import('./pages/centers/student/student.module').then(m => m.StudentModule), data: { noReuse: true } },
  { path: 'assignment', loadChildren: () => import('./pages/assignments/assignment.module').then(m => m.AssignmentModule), data: { noReuse: true } },
  { path: 'authors', loadChildren: () => import('./pages/books/authors/author.module').then(m => m.AuthorModule), data: { noReuse: true}},
  { path: 'publishers', loadChildren: () => import('./pages/books/publishers/publishers.module').then(m => m.PublishersModule), data: { noReuse: true}},

];

