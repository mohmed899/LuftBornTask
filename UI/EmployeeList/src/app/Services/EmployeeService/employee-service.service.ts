import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Employee } from '../../Interfaces/IEmpolyee';
@Injectable({
  providedIn: 'root'
})
export class EmployeeService {


  private apiUrl = 'http://localhost:3828/api/Employee';

  constructor(private http: HttpClient) { }

  getAll(): Observable<Employee[]> {
    return this.http.get<Employee[]>(`${this.apiUrl}`);
  }

  delete(Id: number): Observable<Employee> {
    return this.http.delete<Employee>(`${this.apiUrl}/${Id}`);
  }
  add(entry: any): Observable<Employee> {
    return this.http.post<Employee>(`${this.apiUrl}`, entry);
  }

  update(entry: any , id:any): Observable<Employee> {
    return this.http.put<Employee>(`${this.apiUrl}/${id}`, entry);
  }

 
}
