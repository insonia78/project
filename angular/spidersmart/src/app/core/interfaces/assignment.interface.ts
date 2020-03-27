export interface Assignment {
    id: number;
    level: string;
    book: string;
    title: string;
    description?: string;
    dateFrom: Date;
    dateTo?: Date;
    active: boolean;
}
