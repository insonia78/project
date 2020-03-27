import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatCheckboxModule } from '@angular/material/checkbox';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatSelectModule } from '@angular/material/select';
import { MatNativeDatetimeModule, MatDatetimepickerModule } from '@mat-datetimepicker/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';

import { routes } from './assignment.routing';

import { SharedModule } from '@spidersmart/shared/shared.module';
import { AssignmentComponent } from './assignment.component';
import { AssignmentFormComponent } from './assignment-form.component';
import { AssignmentViewComponent } from './assignment-view.component';
import { AssignmentService } from './assignment.service';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(routes),
    MatFormFieldModule,
    MatInputModule,
    MatSelectModule,
    MatCheckboxModule,
    MatListModule,
    MatIconModule,
    MatButtonModule,
    MatDatepickerModule,
    MatDatetimepickerModule,
    MatNativeDatetimeModule,
    ReactiveFormsModule
  ],
  declarations: [AssignmentComponent, AssignmentViewComponent, AssignmentFormComponent],
  exports: [RouterModule],
  providers: [AssignmentService]
})
export class AssignmentModule { }
