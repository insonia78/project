import { Observable } from 'rxjs';
import { GraphQLResponse } from './graphql-response.interface';

export interface ApiService<T> {
    getAll?: () => Observable<GraphQLResponse<any>>;
    get?: (id: number) => Observable<GraphQLResponse<any>>;
    create?: (data: any) => Observable<GraphQLResponse<any>>;
    modify?: (data: any) => Observable<GraphQLResponse<any>>;
    delete?: (id: number) => Observable<GraphQLResponse<any>>;
    transformIncomingData?: (data: T) => T;
    transformOutgoingData?: (data: T) => T;
}
