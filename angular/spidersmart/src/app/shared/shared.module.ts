import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { MatButtonModule } from '@angular/material/button';
import { MatButtonToggleModule } from '@angular/material/button-toggle';
import { MatCardModule } from '@angular/material/card';
import { MatDividerModule } from '@angular/material/divider';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatListModule } from '@angular/material/list';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatSelectModule } from '@angular/material/select';
import { MatSidenavModule } from '@angular/material/sidenav';
import { TextMaskModule } from 'angular2-text-mask';
import { FlexLayoutModule } from '@angular/flex-layout';

import { HasPermissionDirective } from './directives/has-permission.directive';
import { InContextDirective } from './directives/in-context.directive';

import { PhonePipe } from './pipes/phone.pipe';
import { SubjectPipe } from './pipes/subject.pipe';
import { DatatableModule } from './components/datatable/datatable.module';
import { EnrollmentsModule } from './components/enrollments/enrollments.module';
import { FormActionsModule } from './components/form-actions/form-actions.module';
import { ContactsComponent } from './components/contacts/contacts.component';
import { GradePipe } from './pipes/grade.pipe';
import { AgePipe } from './pipes/age.pipe';
/*
import { MatTimePickerModule} from "./timepicker/mat-time-picker.module";
*/

@NgModule({
  imports: [
    CommonModule,
    FlexLayoutModule,
    TextMaskModule,
    MatDividerModule,
    MatSelectModule,
    MatFormFieldModule,
    MatListModule,
    ReactiveFormsModule,
    MatInputModule,
    RouterModule,
    DatatableModule,
    EnrollmentsModule,
    FormActionsModule,
    MatIconModule,
    MatCardModule,
    MatProgressSpinnerModule,
    MatSidenavModule,
    MatButtonModule,
    MatButtonToggleModule
  ],
  providers: [],
  declarations: [HasPermissionDirective, InContextDirective, PhonePipe, SubjectPipe, GradePipe, AgePipe, ContactsComponent],
  exports: [
    HasPermissionDirective,
    InContextDirective,
    PhonePipe,
    SubjectPipe,
    GradePipe,
    AgePipe,
    DatatableModule,
    ContactsComponent,
    EnrollmentsModule,
    FormActionsModule,
    FlexLayoutModule,
    MatCardModule,
    MatIconModule,
    MatProgressSpinnerModule,
    MatSidenavModule,
    MatButtonModule,
    MatButtonToggleModule
    /*, TextMaskModule, MatTimePickerModule*/
  ]
})
export class SharedModule {
  constructor() {
  }
}
