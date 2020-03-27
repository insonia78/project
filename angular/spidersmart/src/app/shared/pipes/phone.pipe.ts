import { Pipe, PipeTransform } from '@angular/core';
import { parsePhoneNumberFromString } from 'libphonenumber-js';

@Pipe({
  name: 'phone'
})
export class PhonePipe implements PipeTransform {

  /**
   * Convert given string into formatted phone number string
   * @param value The string to convert
   * @param international Whether this should be formatted as an international number
   * @return The formatted string
   */
  transform(value: string, international?: string): string {
    if (!value) {
      return value;
    }

    const phone = parsePhoneNumberFromString(value, 'US');
    if (!phone || !phone.isPossible()) {
      return value;
    }

    return (international) ? phone.formatInternational() : phone.formatNational();
  }
}
