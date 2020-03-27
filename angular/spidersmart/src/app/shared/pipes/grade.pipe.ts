import { Pipe, PipeTransform } from '@angular/core';

@Pipe({
  name: 'grade'
})
export class GradePipe implements PipeTransform {
    transform(value: Date, cutoff: Date = null): any {
        if (!value) {
           return null;
        }

        // use sep 1 as default cutoff since that is the most common
        if (cutoff === null) {
            cutoff = new Date();
            cutoff.setMonth(8);
            cutoff.setDate(1);
        }
        else {
            cutoff = new Date(cutoff);
        }
        const dob = new Date(value);

        // check for pre-k student
        if (cutoff.getFullYear() - dob.getFullYear() < 5 || (cutoff.getFullYear() - dob.getFullYear() === 5 && cutoff.getDate() < dob.getDate())) {
            return 'PK';
        }
        // check for K student
        else if (cutoff.getFullYear() - dob.getFullYear() === 5 || (cutoff.getFullYear() - dob.getFullYear() === 6 && cutoff.getDate() < dob.getDate())) {
            return 'K';
        }
        // check for grade level student
        else {
            const grade = (this.isAfterCutoff(dob, cutoff)) ? cutoff.getFullYear() - dob.getFullYear() - 6  : cutoff.getFullYear() - dob.getFullYear() - 5;
            return (grade > 12) ? 'N/A' : grade;
        }
    }

    /**
     * Determines if the given date of birth occurs after the given cutoff date within a year
     * @param dob The date of birth
     * @param cutoff The cutoff date
     * @return boolean True if it occurs after the cutoff
     */
    private isAfterCutoff(dob: Date, cutoff: Date): boolean {
        return (dob.getMonth() > cutoff.getMonth() || (dob.getMonth() === cutoff.getMonth() && dob.getDate() > cutoff.getDate()));
    }

}
