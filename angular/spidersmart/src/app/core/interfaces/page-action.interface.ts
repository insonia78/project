export interface PageAction {
    id: string;
    type: 'icon' | 'primary' | 'secondary' | 'tertiary';
    actionType?: 'route' | 'method';
    route?: any[];
    action?: Function;
    text?: string;
    icon?: string;
    parameters?: any[];
}
