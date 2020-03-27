import { Component, OnInit, ChangeDetectorRef } from '@angular/core';
import { Router, NavigationStart, NavigationEnd, RouterEvent } from '@angular/router';
import { take } from 'rxjs/operators';
import { ToastrService } from 'ngx-toastr';
import {
  AppContextService,
  PageService,
  Page,
  PageError
} from '@spidersmart/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  public today = new Date();
  /** Used to store current route which can be used to update the history when the route changes */
  private currentRoute: any[] = [];

  constructor(
    private router: Router,
    private cdRef: ChangeDetectorRef,
    private appContextService: AppContextService,
    public pageService: PageService,
    private toastService: ToastrService
  ) { }

  ngOnInit() {
    console.log('APP INIT!!!!!');

    // handle routing events
    this.router.events.subscribe((event: RouterEvent) => {
      // handle pre-navigation actions
      if (event instanceof NavigationStart) {
        // show page loader
        this.pageService.setLoading(true);
      }
      // handle post-navigation actions
      if (event instanceof NavigationEnd) {
        // store previous route into the navigation history
        let pageTitle = '';
        this.pageService.getTitle().pipe(take(1)).subscribe(title => pageTitle = title);
        this.appContextService.storeCurrentRouteInNavigationHistory(pageTitle);
        // update app context with newly loaded route
        this.appContextService.setCurrentRoute((event.url === '/') ? ['/'] : event.url.substring(1).split('/'));

        // clear actions and title of page if this is a different page (not a refresh)
        this.appContextService.getNavigationHistory().pipe(take(1)).subscribe(navigationHistory => {
          if (navigationHistory.length > 0 && event.urlAfterRedirects !== '/' + navigationHistory[navigationHistory.length - 1].route.join('/')) {
            this.pageService.clearActions();
            this.pageService.clearTitle();
          }
        });

        // hide page loader
        this.pageService.setLoading(false);

        // detect changes to prevent issues from title and loader changes from loaded route
        this.cdRef.detectChanges();

        // TEMPORARY: print app context to console
        this.appContextService.printAppContext();
      }
    });

    // set subscription to watch for triggered page errors and display when triggered
    this.pageService.getPageErrors().subscribe((errors: PageError[]) => {
      errors.forEach(error => {
        this.toastService.error(error.message, 'Error');
      });
    });
  }
}
