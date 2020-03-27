import { Component, EventEmitter, Input, OnDestroy, OnInit, Optional, TemplateRef, ViewChild, Output, ContentChild, ChangeDetectorRef } from '@angular/core';
import { MatSortHeader, SortDirection } from '@angular/material/sort';
import { MatColumnDef, MatTable } from '@angular/material/table';
import { startCase } from 'lodash';

import { DatatableCellDirective } from './datatable-cell.directive';

/**
 * Column that shows simply shows text content for the header and row
 * cells. By default, the name of this column will be assumed to be both the header
 * text and data property used to access the data value to show in cells. To override
 * the header text, provide a label text. To override the data cell values,
 * provide a dataAccessor function that provides the string to display for each row's cell.
 *
 * Note that this component sets itself as visually hidden since it will show up in the `mat-table`
 * DOM because it is an empty element with an ng-container (nothing rendered). It should not
 * interfere with screen readers.
 */
@Component({
  selector: 'sm-datatable-column',
  template: `
    <ng-container [matColumnDef]="name">
      <th mat-header-cell *matHeaderCellDef
        (click)="sort()"
        [class.datatable-header-sort]="sortable"
        [class.datatable-header-sort-asc]="sortable && sortDirection === 'asc'"
        [class.datatable-header-sort-desc]="sortable && sortDirection === 'desc'">
        {{getTitle()}}
        <mat-icon *ngIf="sortable">arrow_right_alt</mat-icon>
      </th>
      <td mat-cell *matCellDef="let data">
        <ng-container *ngIf="!template">{{getData(data)}}</ng-container>
        <ng-container *ngTemplateOutlet="template; context: {$implicit: data}"></ng-container>
      </td>
    </ng-container>
  `,
  styleUrls: ['./datatable-column.component.scss']
})
export class DatatableColumnComponent<T> implements OnDestroy, OnInit {
  /** The current direction of the sorting of the column */
  public sortDirection: SortDirection = '';

  /** Column name that should be used to reference this column. */
  @Input() name: string;
/*   get name(): string { return this._name; }
  set name(name: string) {
    this._name = name;
  }
  _name: string;
 */
  /**
   * Text label that should be used for the column header. If this property is not
   * set, the header text will default to the column name.
   */
  @Input() label: string;

  /**
   * Accessor function to retrieve the data should be provided to the cell. If this
   * property is not set, the data cells will assume that the column name is the same
   * as the data property the cells should display.
   */
  @Input() dataAccessor: ((data: T, name: string) => string);

  /** Alignment of the cell values. */
  @Input() align: 'before' | 'after' = 'before';

  /** Whether the column is sortable */
  @Input() sortable: boolean = true;

  /** Event to emit when sorting is updated */
  @Output() sortUpdate = new EventEmitter<string>();

  /** Reference to column definitions and sort headers */
  @ViewChild(MatColumnDef, {static: true}) columnDef: MatColumnDef;
  @ViewChild(MatSortHeader, {static: true}) sortHeader: MatSortHeader;

  @ContentChild(DatatableCellDirective, {static: true, read: TemplateRef}) template;

  constructor(@Optional() public table: MatTable<any>, private cdRef: ChangeDetectorRef) { }

  /**
   * Gives a formatted version of the name if label is not present
   * @return The formatted label
   */
  public getTitle(): string {
    return this.label || startCase(this.name);
  }

  public getData(data: T): any {
    return this.dataAccessor ? this.dataAccessor(data, this.name) : (data as any)[this.name];
  }

  /**
   * Triggers a sort action on this column by emitting a sort update action to the parent datatable
   */
  public sort(): void {
    this.sortUpdate.emit(this.name);
  }

  ngOnInit() {
    if (this.table) {
      this.table.addColumnDef(this.columnDef);
      this.cdRef.detectChanges();
    }
  }

  ngOnDestroy() {
    if (this.table) {
      this.table.removeColumnDef(this.columnDef);
    }
  }
}

