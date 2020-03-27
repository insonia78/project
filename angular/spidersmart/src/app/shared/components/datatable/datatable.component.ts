import {
  Component,
  ContentChildren,
  Input,
  QueryList,
  ViewChild,
  ViewChildren,
  OnDestroy,
  AfterViewInit,
  ChangeDetectorRef
} from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort, MatSortable } from '@angular/material/sort';
import { MatHeaderRowDef, MatRowDef, MatTable, MatTableDataSource } from '@angular/material/table';
import { Observable, Subject } from 'rxjs';
import { takeUntil } from 'rxjs/operators';
import { DatatableDataSource } from './datatable-data-source.interface';
import { DatatableColumnComponent } from './datatable-column.component';
import { AuthorService } from '@spidersmart/pages/books/authors/author.service';


@Component({
  selector: 'sm-datatable',
  templateUrl: 'datatable.component.html',
  styles: [`
    :host {
      display: block;
      width: 100%;
    }

    .mat-table {
      width: 100%;
    }
  `]
})
export class DatatableComponent<T> implements OnDestroy, AfterViewInit {
  /** The list of columns which should appear - this will default to all defined columns if not set */
  @Input() columns: string[];
  /** The datasource from which the table should populate */
  @Input() dataSource: Observable<DatatableDataSource<T>>;
  /** Toggles for pagination, sorting, and filtering */
  @Input() pagination: boolean = true;
  @Input() sortable: boolean = true;
  @Input() filterable: boolean = true;
  /** Page size options provided */
  @Input() pageSizeOptions: number[] = [10, 25, 50, 100];
  /** Default sort options */
  @Input() defaultSortColumn: string;
  @Input() defaultSortDirection: 'asc' | 'desc' = 'asc';

  /** Column definitions added via the DatatableColumn component */
  @ContentChildren(DatatableColumnComponent) datatableColumns: QueryList<DatatableColumnComponent<T>>;

  /** References to the table and row definitions in this template */
  @ViewChild(MatTable) table: MatTable<T>;
  @ViewChild(MatHeaderRowDef) headerRows: MatHeaderRowDef;
  @ViewChildren(MatRowDef) rows: QueryList<MatRowDef<T>>;

  /** Paginator */
  @ViewChild(MatPaginator) paginator: MatPaginator;
  /** Sorter */
  public sort: MatSort = new MatSort();
  /** The data resultant from the provided dataSource - this is fed directly into the table for display */
  public data: MatTableDataSource<T> = new MatTableDataSource<T>([]);
  /** Whether the data is loading from the source or not */
  public loading: boolean = true;

  /** Subject to ensure all subscriptions close when element is destroyed */
  private ngUnsubscribe: Subject<any> = new Subject();

  constructor(private cdRef: ChangeDetectorRef , public authorsService: AuthorService) {}

  /**
   * Apply filter to current data source
   * @param filterValue The value to filter against
   * @return void
   */
  public applyFilter(filterValue: string): void {
    if (this.filterable) {
      const newData = this.data;
      this.data.filter = filterValue.trim().toLowerCase();

      if (this.data.paginator) {
        this.data.paginator.firstPage();
      }
    }
  }

  ngAfterViewInit() {
    // define columns if not already set
    this.columns = this.columns || this.datatableColumns.map(column => column.name);

    // set data result and status from source
    this.dataSource.pipe(takeUntil(this.ngUnsubscribe)).subscribe((data: DatatableDataSource<T>) => {
      // if this is the first load... initialize the table
      console.log('DATASOURCE CHANGES', data);
      this.loading = data.loading;
      this.data = new MatTableDataSource<T>(data.data);

      this.data.sort = this.sort;
      this.data.paginator = (this.pagination) ? this.paginator : null;

      // if there is sorting, default sort must also be set for table interactions to work
       if (this.sortable) {
        // get a sub-set of columns which are defined as sortable
        const sortableColumns = this.datatableColumns
          .filter(column => (column.sortable && this.columns.includes(column.name)))
          .map(column => column.name);

        // only implement sorting if there are sortable columns
        if (sortableColumns.length > 0) {
          this.data.sort = this.sort;
          this.sort.sort(<MatSortable>{
            id: (this.defaultSortColumn && sortableColumns.includes(this.defaultSortColumn)) ? this.defaultSortColumn : sortableColumns[0],
            start: this.defaultSortDirection
          });
        }
      }
    });

    // register datatable-columns to the table
    this.datatableColumns.forEach(datatableColumn => {
      this.table.addColumnDef(datatableColumn.columnDef);
      // register sort header for each sortable column
      if (datatableColumn.sortable) {
        this.sort.register(<MatSortable>{
          id: datatableColumn.name,
          start: 'asc'
        });

        datatableColumn.sortUpdate.pipe(takeUntil(this.ngUnsubscribe)).subscribe((column: string) => {
          this.sort.sort(<MatSortable>{
            id: column,
            start: 'asc'
          });
        });
      }
    });

    // send updated sort direction information back to column for display update when sorting event occurs
    this.sort.sortChange.subscribe(event => {
      this.datatableColumns.find(column => column.name === event.active).sortDirection = event.direction;
    });

    // register row definitions
    // this.rows.forEach(row => this.table.addRowDef(row));

    // register header row definitions
    // this.table.setHeaderRowDef(this.headerRows);

    // force recheck changes now that things are set
    this.cdRef.detectChanges();
  }

  ngOnDestroy(): void {
    this.ngUnsubscribe.next();
    this.ngUnsubscribe.complete();
  }
}
