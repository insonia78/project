import { Pipe, PipeTransform } from '@angular/core';
import { SubjectAbbreviation } from '@spidersmart/core';

@Pipe({
  name: 'subject'
})
export class SubjectPipe implements PipeTransform {

  transform(value: SubjectAbbreviation): any {
    if (!value) {
      return value;
    }

    return SubjectAbbreviation[value];
  }

}
