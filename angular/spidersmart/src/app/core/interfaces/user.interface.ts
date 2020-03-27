import { Resource } from './resource.interface';
import { Contact } from './contact.interface';
import { Enrollment } from './enrollment.interface';

export interface User extends Resource {
    type?: 'user'|'student';
    email: string;
    prefix?: string;
    firstName: string;
    middleName?: string;
    lastName: string;
    suffix?: string;
    verified: boolean;
    active: boolean;
    enrollments: Enrollment[];
    contacts: Contact[];
    //    addresses: Address[];
}
