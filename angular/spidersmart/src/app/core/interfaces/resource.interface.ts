export interface Resource {
    id: number;
    dateFrom: Date;
    dateTo?: Date;
    [prop: string]: any;
}

export const EmptyResource: Resource = {
    id: null,
    dateFrom: null,
    dateTo: null
};
