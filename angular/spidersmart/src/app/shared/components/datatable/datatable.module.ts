import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatProgressBarModule } from '@angular/material/progress-bar';
import { MatSortModule } from '@angular/material/sort';
import { MatTableModule } from '@angular/material/table';

import { DatatableComponent } from './datatable.component';
import { DatatableColumnComponent } from './datatable-column.component';
import { DatatableCellDirective } from './datatable-cell.directive';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    MatInputModule,
    MatIconModule,
    MatFormFieldModule,
    MatTableModule,
    MatProgressBarModule,
    MatPaginatorModule,
    MatSortModule
  ],
  providers: [],
  declarations: [DatatableComponent, DatatableCellDirective, DatatableColumnComponent],
  exports: [DatatableComponent, DatatableCellDirective, DatatableColumnComponent]
})
export class DatatableModule {
  constructor() {
  }
}
