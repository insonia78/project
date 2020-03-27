import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { environment } from '../../environments/environment';
import { CommonModule, DatePipe } from '@angular/common';
import { MatAutocompleteModule } from '@angular/material/autocomplete';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatIconModule } from '@angular/material/icon';
import { MatInputModule } from '@angular/material/input';
import { MatMenuModule } from '@angular/material/menu';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { MatTooltipModule } from '@angular/material/tooltip';
import { ApolloBoostModule, ApolloBoost } from 'apollo-angular-boost';
import { ToastrModule } from 'ngx-toastr';


import { PageService } from './services/page.service';


import { GlobalSearchComponent } from './components/global-search/global-search.component';
import { TopNavComponent } from './components/top-nav/top-nav.component';
import { ContentHeaderComponent } from './components/content-header/content-header.component';
import { UserMenuComponent } from './components/user-menu/user-menu.component';

import { SharedModule } from '@spidersmart/shared';
import { RouterModule } from '@angular/router';
import { PageLoadingIndicatorComponent } from './components/page-loading-indicator.component';


@NgModule({
  imports: [
    CommonModule,
    SharedModule,
    MatProgressSpinnerModule,
    MatIconModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    MatMenuModule,
    MatAutocompleteModule,
    ReactiveFormsModule,
    FormsModule,
    MatTooltipModule,
    ApolloBoostModule,
    RouterModule,
    ToastrModule.forRoot()
  ],
  providers: [DatePipe],
  declarations: [GlobalSearchComponent, TopNavComponent, UserMenuComponent, ContentHeaderComponent, PageLoadingIndicatorComponent],
  exports: [GlobalSearchComponent, TopNavComponent, UserMenuComponent, PageLoadingIndicatorComponent, ContentHeaderComponent]
})
export class CoreModule {
  constructor(private apolloBoost: ApolloBoost, private pageService: PageService) {

    apolloBoost.create({
      // uri: 'http://api.staging.spidersmart.com/graphql',
      uri: environment.apiUrl, // 'http://api.spidersmart.test/graphql',
      onError: ({ graphQLErrors, networkError }) => {
        // if the gql request returned errors, register the errors with the page
        if (graphQLErrors) {
          graphQLErrors.forEach(error => {
            // if the error has a path, consider it a field-level error
            if (error.hasOwnProperty('path')) {
              this.pageService.addError({
                context: 'field',
                message: error.message,
                field: error.path.join('_')
              });
            }
            // else, consider a page level error
            else {
              this.pageService.addError({
                context: 'page',
                message: error.message
              });
            }
          });
        }
        // if there were network errors, register those with the page
        // note, it doesn't seem to work correctly with true network errors
        // and we catch these in the api.interceptor for now
        if (networkError) {
          this.pageService.addError({
            context: 'page',
            message: networkError.message
          });
        }
      }
      /* clientState: {
         defaults: {
           appContext: Object.assign(this.appContextService.getDefaultAppContext(), { __typename: 'AppContext' })
         },
         resolvers: {
           Mutation: this.appContextService.mutation
         }
         // typeDefs
       }*/
    });
  }
}
