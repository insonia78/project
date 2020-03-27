import { Resource, EmptyResource } from './resource.interface';
import { User } from './user.interface';
import { Center } from './center.interface';
import { Level, EmptyLevel } from './level.interface';
import { Subject } from './subject.interface';

export interface Enrollment extends Resource {
    id: number;
    type: 'center' | 'online';
    user: User;
    center?: Center;
    level: Level;
    subject?: Subject;
    tuitionRate: any;
    dateFrom: Date;
    dateTo?: Date;
}

export const EmptyEnrollment: Enrollment = {
    id: EmptyResource.id,
    type: 'center',
    user: null,
    center: null,
    level: EmptyLevel,
    tuitionRate: null,
    dateFrom: EmptyResource.dateFrom
};
