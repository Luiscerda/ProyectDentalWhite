import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Doctor } from '../models/doctor';
import { tap, catchError } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class DoctorService {

  constructor(private http:HttpClient, @Inject('BASE_URL') private baseUrl:string) { }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
    console.error(error);
    this.log(`${operation} failed: ${error.message}`);
    return of(result as T);
    };
  }

  private log(message: string) {
    alert(`Mensaje: ${message}`);
  }

  addDoctor (doctor: Doctor): Observable<Doctor> {
    return this.http.post<Doctor>(this.baseUrl+'api/Doctor', doctor, httpOptions).pipe(
    tap((newDoctor: Doctor) => this.log(`Registrado el doctor con numero de cedula: ${newDoctor.numeroCedula}`)),
    catchError(this.handleError<Doctor>('addDoctor'))
    );
  }

  getAll():Observable<Doctor[]>{
    return this.http.get<Doctor[]>(this.baseUrl+'api/Doctor').pipe(
        catchError(this.handleError<Doctor[]>('getAll',[]))
    );
  }

  get(id: number): Observable<Doctor>{
    const url = `${this.baseUrl + 'api/doctor'}/${id}`;
    return this.http.get<Doctor>(url).pipe(
    tap(_ => this.log(`Consultado el doctor con id ${id}`)),
      catchError(this.handleError<Doctor>(`getDoctor id: ${id}`))
    );
  }

  update (doctor: Doctor): Observable<any> {
    const url =`${this.baseUrl + 'api/doctor'}/${doctor.id}`;
      return this.http.put(url, doctor, httpOptions).pipe(
        tap(_ => this.log(`Modificado el doctor con numero de cedula: ${doctor.numeroCedula}`)),
        catchError(this.handleError<any>('doctor'))
      );
  }

  delete(doctor: Doctor | number): Observable<Doctor> {
    const id = typeof doctor === 'number' ? doctor : doctor.id;
    const url = `${this.baseUrl + 'api/doctor'}/${id}`;
    
    return this.http.delete<Doctor>(url, httpOptions).pipe(
      tap(_ => this.log(`Eliminado el doctor con id: ${id}`)),
        catchError(this.handleError<Doctor>('delete'))
    );
  }
}
