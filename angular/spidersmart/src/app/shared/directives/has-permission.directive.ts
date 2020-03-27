import { Directive, Input, TemplateRef, ViewContainerRef, ChangeDetectorRef } from '@angular/core';
import { AppContextService, Permission } from '@spidersmart/core';

/**
 * This directive will confirm that the logged in user has the given permissions to view the element and will remove it from the viewport if not
 *
 * @input hasPermission Permission|Permission[] The permissions required to view the element.  This can either be a single permission or a list of permissions.
 * @input matchAll boolean Whether to use match all mode.  If true, all defined permissions must belong to the user, otherwise, the element will display if any permission belongs to the user.
 *
 * @example <div *hasPermission="MyPermission"></div> - Displays is MyPermission exists in the user permissions
 * @example <div *hasPermission="[MyPermission1, MyPermission2, MyPermission3]"></div> - Displays if the user has EITHER MyPermission1, MyPermission2, OR MyPermission3
 * @example <div *hasPermission="[MyPermission1, MyPermission2, MyPermission3]; matchAll: true"></div> - Displays if the user has ALL OF MyPermission1, MyPermission2, AND MyPermission3
 */
@Directive({
  selector: '[hasPermission]'
})
export class HasPermissionDirective {
  /** If set to true, the permission comparison approach will be MATCH_ALL, if false, MATCH_ANY */
  private matchAll: boolean = false;
  @Input()
  set hasPermissionMatchAll(state: boolean) {
    this.matchAll = state;
  }

  /** The permissions to compare against, accepts any number of permission parameters */
  @Input()
  set hasPermission(permissions: Permission[]) {
    const valid = this.appContextService.hasPermission(permissions, (this.matchAll ? 'all' : 'any'));
    this.updateView(valid);
    this.cd.markForCheck();
  }

  /**
   * Updates the viewport depending on the permissions validation comparison
   * @param result The result of the comparison
   * @return void
   */
  private updateView(result: boolean): void {
    if (typeof result === 'undefined' || result == null) {
      return;
    }
    this.viewContainer.clear();

    if (result) {
      this.viewContainer.createEmbeddedView(this.templateRef);
    }
  }

  /**
   * @ignore
   */
  constructor(
    private appContextService: AppContextService,
    private templateRef: TemplateRef<any>,
    private viewContainer: ViewContainerRef,
    private cd: ChangeDetectorRef
  ) { }
}
