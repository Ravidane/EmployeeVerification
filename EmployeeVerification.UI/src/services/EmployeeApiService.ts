import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

import { API_URLS } from '../app/app-urls';

@Injectable({
  providedIn: 'root'
})
export class EmployeeApiService {

  constructor(private http: HttpClient) { }

  verifyEmployee(employeeDetails: {
    EmployeeID: number, CompanyName: string, ValidationCode: string
  })
    : Observable<any> {
    return this.http.post<any>(API_URLS.EMPLOYEE_VERIFICATION, employeeDetails);
  }

}
