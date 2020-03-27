import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Assignment, ApiService, GraphQLService, GraphQLResponse } from '@spidersmart/core';

@Injectable()
export class AssignmentService extends GraphQLService implements ApiService<Assignment> {

  /**
   * Gets basic information about all assignments
   * @return An observable response with the list of assignments
   */
  public getAll = (): Observable<GraphQLResponse<Assignment[]>> => {
    return this.query<Assignment[]>(`
            {assignments{
                id
                name
            }}
        `, 'assignments'
    );
  }

  /**
   * Gets detailed information about a assignment with a given id
   * @param id The id to use when looking up the assignment
   * @return An observable response with the assignment details
   */
  public get = (id: number): Observable<GraphQLResponse<Assignment>> => {
    return this.query(`
      {assignment(id: ${id}){
        id
        level
        book
        title
        description
        dateFrom
      }}
    `, 'assignment');
  }

  /**
   * Creates a new assignment with the given data
   * @param data The data to save
   * @return An observable response with the request status and updated data
   */
  public create = (data): Observable<GraphQLResponse<Assignment>> => {
    console.log('SAVING WITH DATA', data, this);
    return this.mutate(`
      mutation (
        $type: String!,
        $label: String!,
        $name: String!,
        $streetAddress: String!,
        $city: String!,
        $state: String!,
        $postalCode: String!,
        $country: String!,
        $phone: String!,
        $fax: String,
        $email: String!
      ) {
        createCenter(
          type: $type,
          label: $label,
          name: $name,
          streetAddress: $streetAddress,
          city: $city,
          state: $state,
          postalCode: $postalCode,
          country: $country,
          phone: $phone,
          fax: $fax,
          email: $email
        ) {
          success
          data
        }
      }
    `, data);
  }

  /**
   * Updates existing assignment details with given data
   * @param data The data to save, note: must include the id of the assignment to save
   * @return An observable response with the request status and updated data
   */
  public modify = (data): Observable<GraphQLResponse<Assignment>> => {
    console.log('SAVING WITH DATA', data, this);
    return this.mutate(`
      mutation (
        $id: Int!,
        $label: String,
        $name: String,
        $streetAddress: String,
        $city: String,
        $state: String,
        $postalCode: String,
        $country: String
        $phone: String,
        $fax: String,
        $email: String
      ) {
        updateCenter(
          id: $id,
          label: $label,
          name: $name,
          streetAddress: $streetAddress,
          city: $city,
          state: $state,
          postalCode: $postalCode,
          country: $country,
          phone: $phone,
          fax: $fax,
          email: $email
        ) {
          success
          data
        }
      }
    `, data);
  }
}
