import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Author, ApiService, GraphQLService, GraphQLResponse } from '@spidersmart/core';
import { map, tap } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class AuthorService extends GraphQLService implements ApiService<Author> {
    /**
     * Gets basic information about all assignments
     * @return An observable response with the list of assignments
     */

    public getAll = (): Observable<GraphQLResponse<Author[]>> => {
      return this.query<Author[]>(`
              {authors{
                  id
                  name
              }}
          `, 'authors'
      );
    }
    public get = (id: number): Observable<GraphQLResponse<Author>> => {

        return this.query(`
          {author(id: ${id}){
            id
            name

          }}
        `, 'author');
    }
    public create = (data): Observable<GraphQLResponse<Author>> => {
        console.log('SAVING WITH DATA', data, this);
        return this.mutate(`
          mutation (
            $name: String!
        ) {
           createAuthor(
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
        `, data).pipe(
          map((response: GraphQLResponse<Author>) => response.data.createAuthor)
        );
    }
    public modify = (data): Observable<GraphQLResponse<Author>> => {
        console.log('SAVING WITH DATA', data, this);
        return this.mutate(`
          mutation (
            $id: Int!,
            $name: String,
        ) {
            updateAuthor(
              id: $id,
              name:$name
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
