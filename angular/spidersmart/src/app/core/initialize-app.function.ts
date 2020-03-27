import { HttpClient } from '@angular/common/http';
import { AppContextService } from '@spidersmart/core';
import { Permission } from './enums/permission.enum';
import { CenterContext } from './enums/center-context.enum';
import { Context } from './enums/context.enum';

export function initializeApp(http: HttpClient, appContextService: AppContextService) {
    return () => {
/*         return http.get('https://api.github.com/users/sagar-ganatra')
            .toPromise()
            .then((resp) => {
            console.log('Response 1 - ', resp);
        });
 */
        appContextService.addPermission(Permission.CREATE_ASSIGNMENT);
        appContextService.addPermission(Permission.CREATE_CENTER);
        appContextService.addPermission(Permission.EDIT_ASSIGNMENT);
        appContextService.addPermission(Permission.VIEW_ASSIGNMENT);
        appContextService.addAccessibleCenter({
            id: 1,
            handle: 'gaithersburg',
            name: 'Gaithersburg'
        });
        appContextService.addAccessibleCenter({
            id: 2,
            handle: 'germantown',
            name: 'Germantown'
        });
        appContextService.setContext(Context.CENTERS);
        appContextService.setCenterContext(CenterContext.ALL_CENTERS);
    };
}
