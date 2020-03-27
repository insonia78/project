import { Injectable } from '@angular/core';
import { Observable, BehaviorSubject } from 'rxjs';
import { map, take } from 'rxjs/operators';

import { AppContextCenter } from '../interfaces/app-context-center.interface';
import { Context } from '../enums/context.enum';
import { CenterContext } from '../enums/center-context.enum';
import { Permission } from '../enums/permission.enum';
import { Page } from '../interfaces/page.interface';

/**
 * Provides access to retrieve and manipulate details about the application status and context
 */
@Injectable({
  providedIn: 'root'
})
export class AppContextService {
  /** The current context */
  private context = new BehaviorSubject<Context>(null);

  /** The current center context */
  private centerContext = new BehaviorSubject<CenterContext>(null);

  /** The currently selected center */
  private center = new BehaviorSubject<AppContextCenter>(null);

  /** The list of centers available to be selected */
  private accessibleCenters = new BehaviorSubject<AppContextCenter[]>([]);

  /** The list of permissions of the currently logged in user */
  private permissions = new BehaviorSubject<Permission[]>([]);

  /** The history of navigation in this session */
  private navigationHistory = new BehaviorSubject<Page[]>([]);

  /** The route which is currently active */
  private currentRoute = new BehaviorSubject<any[]>(null);

  /**
   * Get the current context
   * @return Observable of the context
   */
  public getContext(): Observable<Context> {
    return this.context;
  }

  /**
   * Set the current context
   * @param context The context to set
   */
  public setContext(context: Context): void {
    this.context.next(context);
  }

  /**
   * Get the current center context
   * @return Observable of the center context
   */
  public getCenterContext(): Observable<CenterContext> {
      return this.centerContext;
  }

  /**
   * Set the center contxt
   * @param centerContext The context to set
   */
  public setCenterContext(centerContext: CenterContext): void {
      this.centerContext.next(centerContext);
  }

  /**
   * Get the currently selected center
   * @return Observable of the center
   */
  public getCenter(): Observable<AppContextCenter> {
    return this.center;
  }

  /**
   * Set the current center
   * @param center The center to set
   */
  public setCenter(center: AppContextCenter): void {
      this.center.next(center);
  }

  /**
   * Get the list of accessible centers
   * @return Observable of accessible centers
   */
  public getAccessibleCenters(): Observable<AppContextCenter[]> {
    return this.accessibleCenters;
  }

  /**
   * Set the list of accessible centers
   * @param centers The list of centers
   */
  public setAccessibleCenters(centers: AppContextCenter[]): void {
    this.accessibleCenters.next(centers);
  }

  /**
   * Add a center to the list of accessible centers
   * @param center The center to add
   */
  public addAccessibleCenter(center: AppContextCenter): void {
    this.accessibleCenters.pipe(take(1)).subscribe(centers => {
      if (!centers.includes(center)) {
        centers.push(center);
        this.accessibleCenters.next(centers);
      }
    });
  }

  /**
   * Remove a center from the list of accessible centers
   * @param center The center to remove
   */
  public removeAccessibleCenter(center: AppContextCenter): void {
    this.accessibleCenters.pipe(take(1)).subscribe(centers => {
      const index = centers.findIndex(ctr => ctr.id === center.id);
      if (index !== -1) {
        centers.splice(index, 1);
          this.accessibleCenters.next(centers);
      }
    });
  }

  /**
   * Get the list of permissions of the current user
   * @return Observable of the list of permissions
   */
  public getPermissions(): Observable<Permission[]> {
    return this.permissions;
  }

  /**
   * Determine whether the current user has the given permission(s)
   * @param permissions The permission(s) which should be checked for
   * @param compareStrategy The strategy to compare.  If `any`, then this will return true if the current user has any of the given permissions.  If `all`, the user must have all of the given permissions.
   * @return Whether the current user has given permission(s)
   */
  public hasPermission(permissions: Permission | Permission[], compareStrategy: 'any' | 'all' = 'any'): boolean {
    // ensure that given permissions are in the correct format
    permissions = (permissions instanceof Array) ? permissions : [permissions];

    // if given permissions are empty, assume the user has permission
    if (permissions.length < 1) {
      return true;
    }

    // get unique intersection of permissions with user permissions
    const intersections = permissions
      .filter(permission => (this.permissions.getValue().indexOf(permission) > -1))
      .filter((e, i, c) => (c.indexOf(e) === i));

    return (compareStrategy === 'all') ? (intersections.length === this.permissions.getValue().length) : (intersections.length > 0); 
  }

  /**
   * Set the list of permissions of the current user
   * @param permissions The list of permissions
   */
  public setPermissions(permissions: Permission[]): void {
    this.permissions.next(permissions);
  }

  /**
   * Add a permission to the current list of permissions
   * @param permission The permission to add
   */
  public addPermission(permission: Permission): void {
    this.permissions.pipe(take(1)).subscribe(permissions => {
      if (!permissions.includes(permission)) {
          permissions.push(permission);
          this.permissions.next(permissions);
      }
    });
  }

  /**
   * Remove a permission from the current list of permissions
   * @param permission The permission to remove
   */
  public removePermission(permission: Permission): void {
    this.permissions.pipe(take(1)).subscribe(permissions => {
      const index = permissions.findIndex(perm => perm === permission);
      if (index !== -1) {
        permissions.splice(index, 1);
          this.permissions.next(permissions);
      }
    });
  }

  /**
   * Get navigation history
   * @return Observable of the list of pages visited in the current session
   */
  public getNavigationHistory(): Observable<Page[]> {
    return this.navigationHistory;
  }

  /**
   * Add page to navigation history
   * @param page The new page to add to the history
   */
  public addPageToNavigationHistory(page: Page): void {
    this.navigationHistory.pipe(take(1)).subscribe(history => {
      if (history[history.length - 1] !== page) {
        history.push(page);
        this.navigationHistory.next(history);
      }
    });
  }

  /**
   * Clears navigation history
   */
  public clearNavigationHistory(): void {
    this.navigationHistory.next([]);
  }

  /**
   * Sets the currently active route
   * @param route The current route
   */
  public setCurrentRoute(route: any[]): void {
    this.currentRoute.next(route);
  }

  /**
   * Moves current route into navigation history with given title
   * @param title The title to store the route with in history
   */
  public storeCurrentRouteInNavigationHistory(title: string = ''): void {
    const currentRoute = this.currentRoute.getValue();
    if (currentRoute) {
      this.addPageToNavigationHistory(<Page>{
        route: currentRoute,
        title: title
      });
    }
  }

  /**
   * Utility method to print out current applicaiton context to the console
   */
  public printAppContext() {
    console.log('CURRENT APP CONTEXT:::', {
      context: this.context.getValue(),
      centerContext: this.centerContext.getValue(),
      center: this.center.getValue(),
      accessibleCenters: this.accessibleCenters.getValue(),
      permissions: this.permissions.getValue(),
      navigationHistory: this.navigationHistory.getValue()
    });
  }
}
