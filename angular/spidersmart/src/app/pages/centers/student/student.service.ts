import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { take, map } from 'rxjs/operators';
import { Student, ApiService, CenterContext, GraphQLService, GraphQLResponse, GraphQLQueryFilter, AppContextCenter } from '@spidersmart/core';

@Injectable()
export class StudentService extends GraphQLService implements ApiService<Student> {
  protected readonly STUDENT_GET_FIELDS = `
    id
    # type
    email
    prefix
    firstName
    middleName
    lastName
    suffix
    dateOfBirth
    gender
    school
    verified
    active
    dateFrom
    contacts{
      id
      title
      type
      value
    }
    addresses{
      title
      streetAddress
      city
      state
      postalCode
      country
    }
    enrollments{
      id
      dateFrom
      center{
        id
        name
      }
      level{
        id
        name
        subject {
          id
          name
        }
      }
    }
  `;

  protected readonly STUDENT_GET_ALL_FIELDS = `
    id
    firstName
    lastName
    email
    enrollments {
      id
      center{
        id
        name
      }
    }
  `;

  /**
   * Gets basic information about all students
   * @return An observable response with the list of students
   */
  public getAll = (): Observable<GraphQLResponse<Student[]>> => {
    return this.query<Student[]>(`
            {students{
              ${this.STUDENT_GET_ALL_FIELDS}
            }}
        `, 'students'
    ).pipe(map(response => {
      response.data.forEach((student: Student) => {
        if (this.isStudentAccessible(student)) {
          // convert enrollments property to csv string for display purposes
          if (student.hasOwnProperty('enrollments') && student.enrollments) {
            student.center = student.enrollments.map(enrollment => {
              if (enrollment.hasOwnProperty('center') && enrollment.center && enrollment.center.hasOwnProperty('name') && enrollment.center.name) {
                return enrollment.center.name;
              }
            }).sort().join(', ');
            return student;
          }
        }
      });
      return response;
    }));
  }

  /**
   * Gets basic information about all students within a given center or centers
   * @param center The center id or list of center ids for centers for which students should be returned
   * @return An observable response with the list of students
   */
  public getAllFromCenter = (center: number | number[]): Observable<GraphQLResponse<Student[]>> => {
    // generate filter based on whether the given center(s) is one or multiple
    const filter: GraphQLQueryFilter = {
      field: 'center'
    };
    if (center instanceof Array) {
      filter.values = center.map(String);
    }
    else {
      filter.value = String(center);
    }

    return this.query<Student[]>(`
            query(
              $filter: [QueryFilter]
            ) {
              students(filter:$filter){
              ${this.STUDENT_GET_ALL_FIELDS}
              }
            }
        `, 'students', { filter: [filter] }
    ).pipe(map(response => {
      response.data.forEach((student: Student) => {
        if (this.isStudentAccessible(student)) {
          student = this.transformIncomingData(student);
          // convert enrollments property to csv string for display purposes
          if (student.hasOwnProperty('enrollments') && student.enrollments) {
            student.center = student.enrollments.map(enrollment => {
              if (enrollment.hasOwnProperty('center') && enrollment.center && enrollment.center.hasOwnProperty('name') && enrollment.center.name) {
                return enrollment.center.name;
              }
            }).sort().join(', ');
            return student;
          }
        }
      });
      return response;
    }));
  }

  /**
   * Gets detailed information about a student with a given id
   * @param id The id to use when looking up the student
   * @return An observable response with the student details
   */
  public get = (id: number): Observable<GraphQLResponse<Student>> => {
    return this.query(`
      query {
        student(id: ${id}){
          ${this.STUDENT_GET_FIELDS}
        }
      }
    `, 'student').pipe(map((response: GraphQLResponse<Student>) => {
      response.data = this.transformIncomingData(response.data);
      return response;
    }));
  }

  /**
   * Creates a new student with the given data
   * @param data The data to save
   * @return An observable response with the request status and updated data
   */
  public create = (data: Student): Observable<GraphQLResponse<Student>> => {
    data = this.transformOutgoingData(data);
    console.log('SAVING WITH DATA', data, this);
    return this.mutate(`
      mutation (
        $email: String!,
        $password: String!,
        $prefix: String,
        $firstName: String!,
        $middleName: String,
        $lastName: String!,
        $suffix: String,
        $dateOfBirth: DateTime,
        $gender: String,
        $school: String,
        $contacts: [CreateUserContact],
        $enrollments: [CreateEnrollment]
      ) {
        createStudent(
          email: $email
          password: $password,
          prefix: $prefix,
          firstName: $firstName,
          middleName: $middleName,
          lastName: $lastName,
          suffix: $suffix
          dateOfBirth: $dateOfBirth,
          gender: $gender,
          school: $school,
          contacts: $contacts,
          enrollments: $enrollments
        ) {
          success
          data
        }
      }
    `,
      data,
      `query { students{ ${this.STUDENT_GET_ALL_FIELDS} }}`);
  }

  /**
   * Updates existing student details with given data
   * @param data The data to save, note: must include the id of the student to save
   * @return An observable response with the request status and updated data
   */
  public modify = (data: Student): Observable<GraphQLResponse<Student>> => {
    data = this.transformOutgoingData(data);
    console.log('SAVING WITH DATA', data, this);
    return this.mutate(`
      mutation updateStudent(
        $id: Int!,
        $email: String,
        $prefix: String,
        $firstName: String,
        $middleName: String,
        $lastName: String,
        $suffix: String,
        $dateOfBirth: DateTime,
        $gender: String,
        $school: String,
        $contacts: [CreateUserContact],
        $enrollments: [CreateEnrollment]
      ) {
        updateStudent(
          id: $id,
          email: $email,
          prefix: $prefix,
          firstName: $firstName,
          middleName: $middleName,
          lastName: $lastName,
          suffix: $suffix,
          dateOfBirth: $dateOfBirth,
          gender: $gender,
          school: $school,
          contacts: $contacts,
          enrollments: $enrollments
        ) {
          success
          data
        }
      }
    `,
      data,
      `query { student(id: ${data.id}){ ${this.STUDENT_GET_FIELDS} }}`);
  }

  /**
   * Transforms incoming response data into format expected in system
   * @param response The response to transform
   * @return The formatted response
   */
  public transformIncomingData = (data: Student): Student => {
    // transform enrollments so that subject is a separate property from level
    if (data.hasOwnProperty('enrollments')) {
      for (const enrollment of data.enrollments) {
        if (enrollment.hasOwnProperty('level') && enrollment.level.hasOwnProperty('subject')) {
          enrollment.subject = enrollment.level.subject;
          delete enrollment.level.subject;
        }
      }
    }
    return data;
  }

  /**
   * Transforms outgoing data into format expected in remote system
   * @param data The data to transform
   * @return The formatted response
   */
  public transformOutgoingData = (data: Student): Student => {
    // transform enrollments so that subject is a property in level
    for (const enrollment of data.enrollments) {
      enrollment.level.subject = enrollment.subject;
      delete enrollment.subject;
    }
    return data;
  }

  /**
   * Check if student is accessible in current app context
   */
  private isStudentAccessible(student: Student): boolean {
    let context: CenterContext = null;
    this.appContextService.getCenterContext().pipe(take(1)).subscribe(centerContext => context = centerContext);
    let center: AppContextCenter = null;
    this.appContextService.getCenter().pipe(take(1)).subscribe(ctr => center = ctr);
    if (context === CenterContext.ALL_CENTERS) {
      return true;
    }
    if (context === CenterContext.SPECIFIC_CENTER) {
      if (student.hasOwnProperty('enrollments')) {
        for (const enrollment of student.enrollments) {
          if (enrollment.hasOwnProperty('center') && enrollment.center.id === center.id) {
            return true;
          }
        }
      }
    }
    return false;
  }
}
