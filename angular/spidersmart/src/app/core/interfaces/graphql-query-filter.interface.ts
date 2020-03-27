export interface GraphQLQueryFilter{
    field: string;
    value?: string;
    values?: string[];
    comparison?: '='|'<'|'in';
}
