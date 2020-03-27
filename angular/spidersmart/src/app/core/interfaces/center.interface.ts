import { Resource } from './resource.interface';
import { Subject } from './subject.interface';

export interface Center extends Resource {
    type: 'local' | 'online';
    name: string;
    label: string;
    streetAddress: string;
    city: string;
    state: string;
    postalCode: string;
    country: string;
    email: string;
    phone: string;
    availableSubjects?: Subject[];
}
