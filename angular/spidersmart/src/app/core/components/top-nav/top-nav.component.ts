import { Component, OnInit, OnDestroy, ViewEncapsulation, ViewChild, ElementRef } from '@angular/core';
import { MatMenu } from '@angular/material/menu';
import { Subject } from 'rxjs';
import { take, takeUntil } from 'rxjs/operators';

import { AppContextService } from '../../services/app-context.service';
import { CenterContext } from '../../enums/center-context.enum';
import { Context } from '../../enums/context.enum';
import { NavigationItem } from '../../interfaces/navigation-item.interface';
import { TopNavigationService } from '../../services/top-navigation.service';
import { Permission } from '../../enums/permission.enum';


/**
 * Displays the top navigation menu
 */
@Component({
  selector: 'app-top-nav',
  templateUrl: './top-nav.component.html',
  styleUrls: ['./top-nav.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class TopNavComponent implements OnInit, OnDestroy {
  /** The current context of the application */
  public currentContext: Context = null;
  /** Whether the mobile menu launcher is shown */
  public showMobile: boolean = false;
  /** used to destroy any subscriptions when component is destroyed */
  private ngUnsubscribe: Subject<any> = new Subject();

  /** The list of centers which is available for the user to select from when changing context */
  @ViewChild('centerList', {static: true}) centerList: MatMenu;

  /**
   * @ignore
   */
  constructor(
    public appContextService: AppContextService,
    public topNavigationService: TopNavigationService
  ) {
    this.appContextService.getContext().pipe(takeUntil(this.ngUnsubscribe)).subscribe(context => {
      this.currentContext = context;
    });
  }

  /**
   * Initialize the menu structure
   */
  ngOnInit() {
    this.topNavigationService.addSection(Context.CENTERS, 'All Centers', [Permission.VIEW_ASSIGNMENT]);
     this.topNavigationService.addSectionTrigger(Context.CENTERS, (): MatMenu => {
       return this.centerList;
    });
    this.topNavigationService.addItem(Context.CENTERS, 'Center Details', ['/center'], [Permission.VIEW_ASSIGNMENT]);
    this.topNavigationService.addItem(Context.CENTERS, 'Students', ['/student'], [Permission.VIEW_ASSIGNMENT]);

    this.topNavigationService.addSection(Context.ASSIGNMENTS, 'Assignments', [Permission.VIEW_ASSIGNMENT]);
    this.topNavigationService.addItem(Context.ASSIGNMENTS, 'Reading & Writing', ['/assignment'], [Permission.VIEW_ASSIGNMENT]);
    this.topNavigationService.addSection(Context.BOOKS, 'Books', []);
    this.topNavigationService.addItem(Context.BOOKS, 'Approved Books', [], [Permission.VIEW_ASSIGNMENT]);
    this.topNavigationService.addItem(Context.BOOKS, 'Authors', ['/authors'], [Permission.VIEW_ASSIGNMENT]);
    this.topNavigationService.addItem(Context.BOOKS, 'Genres', [], [Permission.VIEW_ASSIGNMENT]);
    this.topNavigationService.addItem(Context.BOOKS, 'Publisher', ['/publishers'], [Permission.VIEW_ASSIGNMENT]);
  }

  /**
   * Processes a selection from the context menu (top-most navigation menu)
   * @param context The context which was selected
   * @param navItem The navigation which was selected
   */
  public changeContext(context: Context, navItem?: NavigationItem): void {
    // don't do anything if this is already the current context
    if (this.currentContext === context) {
      return;
    }
    this.currentContext = context;
    this.appContextService.setContext(context);
    this.topNavigationService.routeToSectionDefault(context);
  }

  /**
   * Changes the current center context
   * @param id The id of the center to which context is changed
   * @param handle The handle of the center to which context is changed
   */
  chooseCenterContext(id: number | null, handle: string | null): void {
    // if no handle or no id, then set to all centers
    if (!handle || !id) {
      this.appContextService.setCenterContext(CenterContext.ALL_CENTERS);
      this.appContextService.setCenter(null);
      this.topNavigationService.updateSectionLabel(Context.CENTERS, 'All Centers');
    }
    // if single center, the user might need to be re-routed as well
    else {
      this.appContextService.getAccessibleCenters().pipe(take(1)).subscribe(centers => {
        const center = centers.find(ctr => ctr.id === id);
        if (center) {
          this.appContextService.setCenter(center);
          this.topNavigationService.updateSectionLabel(Context.CENTERS, center.name);
        }
        this.appContextService.setCenterContext(CenterContext.SPECIFIC_CENTER);
      });
      this.appContextService.printAppContext();
    }

    // center context just changed, so the user should route to the centers context if not already there
    if (this.currentContext !== Context.CENTERS) {
      this.changeContext(Context.CENTERS);
    }

    // TODO: emit some event that can be captured by pages in the center context so that data can be updated accordingly
    // when context changes
    // OR trigger a page data reload through pageservice? - this would have to avoid triggering a reload on pages in assignment context for example,
    // but that may not be an issue since changing center context from another context would automatically switch the context over to centers anyway
  }

  /**
   * @ignore
   */
  ngOnDestroy() {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }
}
