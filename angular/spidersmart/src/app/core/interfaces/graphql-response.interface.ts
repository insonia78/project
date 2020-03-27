export interface GraphQLResponse<T> {
    loading?: boolean;
    success?: boolean;
    errors?: any;
    data: T;
}
