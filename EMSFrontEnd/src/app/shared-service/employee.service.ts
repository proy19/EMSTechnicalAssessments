import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Employee, CreatedEmployee } from './employee.model';
import { EmployeeRequest } from './employee-request.model';
import { Role } from './role.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  url : string = environment.apiBaseUrl

  constructor(private http: HttpClient) { }

  getEmployeesWithRoles(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.url + '/Employee/employees-with-roles').pipe(
      catchError((error) => {
        return throwError(() => new Error('Error retrieving employee data'));
      })
    );
  }

  getAllManagers(): Observable<Employee[]> {
    return this.http.get<Employee[]>(this.url + '/Employee/managers').pipe(
      catchError((error) => {
        return throwError(() => new Error('Error retrieving manager data'));
      })
    );
  }

  getEmployeesByManager(managerId: number): Observable<Employee[]> {
    return this.http.get<Employee[]>(`${this.url}/Employee/employees-by-manager/${managerId}`).pipe(
      catchError((error) => {
        return throwError(() => new Error('Error retrieving employee by manager data'));
      })
    );
  }

  addNewEmployee(request : EmployeeRequest) : Observable<any> {
    return this.http.post<any>(this.url + '/Employee/create-employee', request).pipe(
      catchError((error) => {
        console.log(error)
        return throwError(() => new Error('Error creating new employee'));
      })
    );;
  }

  getAllRoles() : Observable<Role[]> {
    return this.http.get<Role[]>(this.url + '/Role').pipe(
      catchError((error) => {
        return throwError(() => new Error('Error retrieving roles'));
      })
    );;
  }
}
