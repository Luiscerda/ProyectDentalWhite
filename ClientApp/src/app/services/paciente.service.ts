import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable, of, observable } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';
import {Paciente} from '../models/paciente';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class PacienteService {

  constructor(private http:HttpClient, @Inject('BASE_URL') private baseUrl:string) { }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
    console.error(error);
    this.log(`${operation} failed: ${error.message}`);
    return of(result as T);
    };
  }

  private log(message: string) {
    alert(`PacienteService: ${message}`);
  }

  addPaciente (paciente: Paciente): Observable<Paciente> {
    return this.http.post<Paciente>(this.baseUrl+'api/Paciente', paciente, httpOptions).pipe(
    tap((newPaciente: Paciente) => this.log(`Registrado el paciente con Numero Identificacion: ${newPaciente.numeroCedula}`)),
    catchError(this.handleError<Paciente>('addPaciente'))
    );
  }

  getAll():Observable<Paciente[]>{
    return this.http.get<Paciente[]>(this.baseUrl+'api/Paciente').pipe(
        catchError(this.handleError<Paciente[]>('getAll',[]))
    );
  }

  get(id: number): Observable<Paciente>{
    const url = `${this.baseUrl + 'api/paciente'}/${id}`;
    return this.http.get<Paciente>(url).pipe(
    tap(_ => this.log(`Consultado el paciente con id:${id}`)),
      catchError(this.handleError<Paciente>(`getHero id=${id}`))
    );
  }

  update (paciente: Paciente): Observable<any> {
    const url =`${this.baseUrl + 'api/Paciente'}/${paciente.id}`;
      return this.http.put(url, paciente, httpOptions).pipe(
        tap(_ => this.log(`Modificado el paciente con numero de cedula: ${paciente.numeroCedula}`)),
        catchError(this.handleError<any>('paciente'))
      );
  }

  delete(paciente: Paciente | number): Observable<Paciente> {
    const id = typeof paciente === 'number' ? paciente : paciente.id;
    const url = `${this.baseUrl + 'api/paciente'}/${id}`;
    
    return this.http.delete<Paciente>(url, httpOptions).pipe(
      tap(_ => this.log(`Eliminado el paciente con id: ${id}`)),
        catchError(this.handleError<Paciente>('delete'))
    );
  }
  
}
