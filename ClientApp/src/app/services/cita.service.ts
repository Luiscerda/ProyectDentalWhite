import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, tap } from 'rxjs/operators';
import { Cita } from '../models/cita';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class CitaService {

  constructor(private http:HttpClient, @Inject('BASE_URL') private baseUrl:string) { }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
    console.error(error);
    this.log(`${operation} failed: ${error.message}`);
    return of(result as T);
    };
  }

  private log(message: string) {
    alert(`CitaService: ${message}`);
  }

  addCita (cita: Cita): Observable<Cita> {
    return this.http.post<Cita>(this.baseUrl+'api/Cita', cita, httpOptions).pipe(
    tap((newCita: Cita) => this.log(`Registrada la cita del paciente con Numero Identificacion: ${newCita.paciente.numeroCedula} en la fecha ${newCita.fecha}`)),
    catchError(this.handleError<Cita>('addCita'))
    );
  }
}
