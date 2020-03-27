import { Resource, EmptyResource } from './resource.interface';
import { ContactType } from '../enums/contact-type.enum';

export interface Contact extends Resource {
    title: string;
    type: ContactType;
    value: string;
}

export const EmptyContact: Contact = {
    id: EmptyResource.id,
    title: '',
    type: ContactType.MOBILE_PHONE,
    value: '',
    dateFrom: EmptyResource.dateFrom
};
