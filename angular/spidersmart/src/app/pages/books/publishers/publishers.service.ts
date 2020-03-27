import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Publisher, ApiService, GraphQLService, GraphQLResponse } from '@spidersmart/core';

@Injectable({
  providedIn: 'root',
})
export class PublishersService extends GraphQLService implements ApiService<Publisher> {

    /**
     * Gets basic information about all assignments
     * @return An observable response with the list of assignments
     */
    public getAll = (): Observable<GraphQLResponse<Publisher[]>> => {
      return this.query<Publisher[]>(`
              {publishers{
                  id
                  name
              }}
          `, 'publishers'
      );
    }
    public get = (id: number): Observable<GraphQLResponse<Publisher>> => {

        return this.query(`
          {publisher(id: ${id}){
            id
            name

          }}
        `, 'publisher');
    }
    public create = (data): Observable<GraphQLResponse<Publisher>> => {
        console.log('SAVING WITH DATA', data, this);
        return this.mutate(`
          mutation (
            $name: String!
        ) {
           createPublisher(
             name: $name
        ) {
              success
              data{
                id
                name
                dateFrom
              }
            }
          }
        `, data);
    }
}
