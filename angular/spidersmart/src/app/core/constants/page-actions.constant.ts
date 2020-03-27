import { PageAction } from '../interfaces/page-action.interface';

export const PageActions = {
    create: <PageAction>{
        id: 'create',
        type: 'icon',
        text: 'Create',
        icon: 'add'
    },
    edit: <PageAction>{
        id: 'edit',
        type: 'icon',
        text: 'Edit',
        icon: 'edit'
    },
    delete: <PageAction>{
        id: 'delete',
        type: 'icon',
        text: 'Delete',
        icon: 'delete'
    },
    contacts: <PageAction>{
        id: 'contacts',
        type: 'icon',
        text: 'Contacts',
        icon: 'person'
    },
    enrollments: <PageAction>{
        id: 'enrollments',
        type: 'icon',
        text: 'Enrollments',
        icon: 'group_add'
    },
    save: <PageAction>{
        id: 'save',
        type: 'primary',
        text: 'Save',
        icon: 'save'
    },
    cancel: <PageAction>{
        id: 'cancel',
        type: 'tertiary',
        text: 'Cancel',
        icon: 'clear'
    }
};
