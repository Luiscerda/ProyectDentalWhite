import { Injectable, Inject } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Tratamiento } from '../models/tratamiento';
import { catchError, tap } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class TratamientoService {

  constructor(private http:HttpClient, @Inject('BASE_URL') private baseUrl:string) { }

  private handleError<T> (operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
    console.error(error);
    this.log(`${operation} failed: ${error.message}`);
    return of(result as T);
    };
  }

  private log(message: string) {
    alert(`TratamientoService: ${message}`);
  }

  addTratamiento (tratamiento: Tratamiento): Observable<Tratamiento> {
    return this.http.post<Tratamiento>(this.baseUrl+'api/tratamiento', tratamiento, httpOptions).pipe(
    tap((newTratamiento: Tratamiento) => this.log(`Registrado el tratamiento con Codigo ${newTratamiento.codigo}`)),
    catchError(this.handleError<Tratamiento>('addTratamiento'))
    );
  }

  getAll():Observable<Tratamiento[]>{
    return this.http.get<Tratamiento[]>(this.baseUrl+'api/tratamiento').pipe(
      tap(_=>this.log('Consulta De Tratamientos')),
        catchError(this.handleError<Tratamiento[]>('getAll',[]))
    );
  }

  get(id: number): Observable<Tratamiento>{
    const url = `${this.baseUrl + 'api/tratamiento'}/${id}`;
    return this.http.get<Tratamiento>(url).pipe(
    tap(_ => this.log(`Consultado el tratamiento con id=${id}`)),
      catchError(this.handleError<Tratamiento>(`getHero id=${id}`))
    );
  }

  update (tratamiento: Tratamiento): Observable<any> {
    const url =`${this.baseUrl + 'api/tratamiento'}/${tratamiento.id}`;
      return this.http.put(url, tratamiento, httpOptions).pipe(
        tap(_ => this.log(`Modificado el tratamiento con Codigo=${tratamiento.codigo}`)),
        catchError(this.handleError<any>('tratamiento'))
      );
  }

  delete(tratamiento: Tratamiento | number): Observable<Tratamiento> {
    const id = typeof tratamiento === 'number' ? tratamiento : tratamiento.id;
    const url = `${this.baseUrl + 'api/tratamiento'}/${id}`;
    
    return this.http.delete<Tratamiento>(url, httpOptions).pipe(
      tap(_ => this.log(`Eliminado el tratamiento con id=${id}`)),
        catchError(this.handleError<Tratamiento>('delete'))
    );
  }
}
