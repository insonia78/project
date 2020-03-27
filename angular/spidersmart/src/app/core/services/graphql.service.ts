import { Injectable } from '@angular/core';
import { Apollo, gql } from 'apollo-angular-boost';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { GraphQLResponse } from '../interfaces/graphql-response.interface';
// import { ServiceLocator } from '../service-locator';
import { AppContextService } from './app-context.service';
import { DatePipe } from '@angular/common';

@Injectable({
  providedIn: 'root'
})
export class GraphQLService {
  // protected apollo: Apollo;
  // protected appContextService: AppContextService;
  // protected datePipe: DatePipe;
  protected readonly API_DATE_FORMAT = 'yyyy-MM-dd HH:mm:ss';

  constructor(
    protected apollo: Apollo,
    protected appContextService: AppContextService,
    protected datePipe: DatePipe
  ) {
    // this.apollo = ServiceLocator.injector.get(Apollo);
    // this.appContextService = ServiceLocator.injector.get(AppContextService);
    // this.datePipe = ServiceLocator.injector.get(DatePipe);
  }

  /**
   * Performs a query
   * @param query The GQL query to send to the API
   * @param property The data property to return (defaults to all returned)
   * @param variables The map of variables to send with the request
   * @return The observable result
   */
  protected query<T>(query: any, property: string = '', variables: {} = null): Observable<GraphQLResponse<T>> {
    return this.apollo.watchQuery<any>({
      query: gql(query),
      variables: variables
    })
    .valueChanges
    .pipe(
      map(({ data, loading }) => {
        return <GraphQLResponse<T>>{
          data: (data.hasOwnProperty(property)) ? <T>data[property] : data,
          loading: loading
        };
      })
    );
  }

  /**
   * Performs a mutation
   * @param mutation The GQL mutation to send to the API
   * @param variables The variables to send with the request
   * @return The observable result
   */
  protected mutate<T>(mutation: any, variables: any, refetchQuery: any = null): Observable<GraphQLResponse<T>> {
    return this.apollo.mutate({
      mutation: gql(mutation),
      variables: this.formatDates(variables),
      refetchQueries: (refetchQuery !== null) ? [{
        query: gql(refetchQuery)
      }] : []
    }).pipe(
      map((data: GraphQLResponse<T>) => {
        return <GraphQLResponse<T>>{
          data: data.data,
          success: data.success
        };
      })
    );
  }

  /**
   * Formats dates in given data object to match format required by the API
   * @param data The data object in which dates should be formatted
   * @return The data object with formatted dates
   */
  private formatDates(data: any): any {
    for (const d in data) {
      if (data[d] instanceof Date) {
        data[d] = this.datePipe.transform(data[d], this.API_DATE_FORMAT);
      }
    }
    return data;
  }
}
