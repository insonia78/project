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
import { MatPasswordStrengthModule } from '@angular-material-extensions/password-strength';
import { ReactiveFormsModule } from '@angular/forms';
import { TextMaskModule } from 'angular2-text-mask';
import { RouterModule } from '@angular/router';

import { routes } from './student.routing';

import { SharedModule } from '@spidersmart/shared';
import { StudentComponent } from './student.component';
import { StudentViewComponent } from './student-view.component';
import { StudentFormComponent } from './student-form.component';
import { StudentService } from './student.service';


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
    MatPasswordStrengthModule,
    ReactiveFormsModule,
    TextMaskModule
  ],
  declarations: [StudentComponent, StudentViewComponent, StudentFormComponent],
  exports: [RouterModule],
  providers: [StudentService]
})
export class StudentModule { }
