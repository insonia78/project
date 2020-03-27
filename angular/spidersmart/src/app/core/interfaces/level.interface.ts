import { Resource, EmptyResource } from './resource.interface';
import { Subject, EmptySubject } from './subject.interface';

export interface Level extends Resource {
    id: number;
    name: string;
    description: string;
    subject: Subject;
}

export const EmptyLevel: Level = {
    id: EmptyResource.id,
    name: '',
    description: '',
    subject: EmptySubject,
    dateFrom: EmptyResource.dateFrom
};
