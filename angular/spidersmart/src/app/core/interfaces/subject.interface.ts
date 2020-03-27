import { Resource, EmptyResource } from './resource.interface';
import { Level } from './level.interface';

export interface Subject extends Resource {
    id: number;
    name: string;
    description: string;
    active: boolean;
    availableLevels?: Level[];
}

export const EmptySubject: Subject = {
    id: EmptyResource.id,
    name: '',
    description: '',
    active: true,
    dateFrom: EmptyResource.dateFrom,
    availableLevels: []
};
