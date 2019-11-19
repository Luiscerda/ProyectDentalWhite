import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Hora } from '../models/hora';
import { catchError, tap } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class HoraService {

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

  addHora (hora: Hora): Observable<Hora> {
    return this.http.post<Hora>(this.baseUrl+'api/Hora', hora, httpOptions).pipe(
    tap((newHora: Hora) => this.log(`Registrado el horario con ID: ${newHora.id}`)),
    catchError(this.handleError<Hora>('addHora'))
    );
  }

  getAll():Observable<Hora[]>{
    return this.http.get<Hora[]>(this.baseUrl+'api/Hora').pipe(
        catchError(this.handleError<Hora[]>('getAll',[]))
    );
  }

  get(id: number): Observable<Hora>{
    const url = `${this.baseUrl + 'api/hora'}/${id}`;
    return this.http.get<Hora>(url).pipe(
    tap(_ => this.log(`Consultada la hora con id: ${id}`)),
      catchError(this.handleError<Hora>(`getHora id: ${id}`))
    );
  }

  update (hora: Hora): Observable<any> {
    const url =`${this.baseUrl + 'api/hora'}/${hora.id}`;
      return this.http.put(url, hora, httpOptions).pipe(
        tap(_ => this.log(`Modificada la hora con ID: ${hora.id}`)),
        catchError(this.handleError<any>('hora'))
      );
  }

  delete(hora: Hora | number): Observable<Hora> {
    const id = typeof hora === 'number' ? hora : hora.id;
    const url = `${this.baseUrl + 'api/hora'}/${id}`;
    
    return this.http.delete<Hora>(url, httpOptions).pipe(
      tap(_ => this.log(`Eliminada la hora con id: ${id}`)),
        catchError(this.handleError<Hora>('delete'))
    );
  }
}
