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
import { TextMaskModule } from 'angular2-text-mask';
import { RouterModule } from '@angular/router';

import { routes } from './center.routing';

import { SharedModule } from '@spidersmart/shared/shared.module';
import { CenterComponent } from './center.component';
import { CenterViewComponent } from './center-view.component';
import { CenterService } from './center.service';
import { CenterFormComponent } from './center-form.component';



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
    ReactiveFormsModule,
    TextMaskModule
  ],
  declarations: [CenterComponent, CenterViewComponent, CenterFormComponent],
  exports: [RouterModule],
  providers: [CenterService]
})
export class CenterModule { }
