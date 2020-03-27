import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { MatInputModule } from '@angular/material/input';
import { routes } from './author.routing';
import { MatButtonModule } from '@angular/material/button';
import { SharedModule } from '@spidersmart/shared/shared.module';
import { AuthorComponent } from './author.component';
import { AuthorService } from './author.service';
import { AuthorFormComponent } from './author-form.component';
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { AuthorViewComponent } from './author-view.component';

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
  declarations: [AuthorComponent, AuthorViewComponent, AuthorFormComponent],
  exports: [RouterModule],
  providers: [AuthorService]
})
export class AuthorModule { }
