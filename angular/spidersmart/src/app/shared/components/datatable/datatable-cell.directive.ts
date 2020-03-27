import { Directive, TemplateRef } from '@angular/core';

@Directive({
    selector: '[smDatatableCell]'
})
export class DatatableCellDirective {
    constructor(public template: TemplateRef<any>) { }
}
