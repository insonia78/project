import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'age'
})
export class AgePipe implements PipeTransform {
  transform(value: Date): any {
    if (!value) {
      return null;
    }

    return Math.floor(Math.abs(Date.now() - new Date(value).getTime()) / (1000 * 3600 * 24) / 365.25);
  }
}
