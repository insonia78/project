import { Permission } from '../enums/permission.enum';

export interface NavigationItem {
    url?: any[];
    label: string;
    requiredPermissions: Permission[];
    icon?: string;
}
