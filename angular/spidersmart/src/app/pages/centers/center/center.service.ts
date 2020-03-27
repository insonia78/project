import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Center, ApiService, GraphQLService, GraphQLResponse } from '@spidersmart/core';

@Injectable()
export class CenterService extends GraphQLService implements ApiService<Center> {

  /**
   * Gets basic information about all centers
   * @return An observable response with the list of centers
   */
  public getAll = (): Observable<GraphQLResponse<Center[]>> => {
    return this.query<Center[]>(`
            {centers{
                id
                label
                name
                streetAddress
                city
                state
                postalCode
                country
            }}
        `, 'centers'
    );
  }

  /**
   * Gets detailed information about a center with a given id
   * @param id The id to use when looking up the center
   * @return An observable response with the center details
   */
  public get = (id: number): Observable<GraphQLResponse<Center>> => {
    return this.query(`
      {center(id: ${id}){
        id
        label
        name
        type
        streetAddress
        city
        state
        postalCode
        country
        phone
        email
        dateFrom
      }}
    `, 'center');
  }

  /**
   * Creates a new center with the given data
   * @param data The data to save
   * @return An observable response with the request status and updated data
   */
  public create = (data): Observable<GraphQLResponse<Center>> => {
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
          email: $email
        ) {
          success
          data
        }
      }
    `, data);
  }

  /**
   * Updates existing center details with given data
   * @param data The data to save, note: must include the id of the center to save
   * @return An observable response with the request status and updated data
   */
  public modify = (data): Observable<GraphQLResponse<Center>> => {
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
          email: $email
        ) {
          success
          data {
            id
            name
          }
        }
      }
    `, data);
  }
}
