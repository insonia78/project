import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatInputModule } from '@angular/material/input';
import { routes } from './publishers.routing';
import { MatButtonModule } from '@angular/material/button';
import { SharedModule } from '@spidersmart/shared/shared.module';
import { PublishersComponent } from './publishers.component';
import { PublishersService } from './publishers.service';
import { PublishersFormComponent } from './publishers-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { PublishersViewComponent } from './publishers-view.component';

@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    RouterModule.forChild(routes),
    MatInputModule,
    MatButtonModule,
    ReactiveFormsModule,
    MatFormFieldModule


  ],
  declarations: [PublishersComponent, PublishersViewComponent, PublishersFormComponent],
  exports: [RouterModule],
  providers: [PublishersService]
})
export class PublishersModule { }
