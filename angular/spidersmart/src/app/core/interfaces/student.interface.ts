import { User } from './user.interface';

export interface Student extends User {
    type?: 'student';
    center?: String;
    dateOfBirth: Date;
    gender: 'M' | 'F';
    school: string;
    theme: string;
}
