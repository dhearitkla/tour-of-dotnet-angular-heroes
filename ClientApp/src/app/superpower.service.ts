import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { MessageService } from './message.service';
import { Superpower } from './superpower';

@Injectable({providedIn: 'root'})
export class SuperpowerService {

  /**
   * URL to web api
   * @private
   */
  private superpowersUrl = 'https://localhost:7165/Superpower';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor( private http: HttpClient, private messageService: MessageService) { }

  /** GET superpowers from the server */
  getSuperpowers(): Observable<Superpower[]> {
    return this.http.get<Superpower[]>(`${this.superpowersUrl}`)
      .pipe(
        tap(_ => this.log('fetched superpowers')),
        catchError(this.handleError<Superpower[]>('getSuperpowers', []))
      );
  }

  /** GET superpower by id. Will 404 if id not found */
  getSuperpower(id: string): Observable<Superpower> {
    const url = `${this.superpowersUrl}/${id}`;
    return this.http.get<Superpower>(url).pipe(
      tap(_ => this.log(`fetched superpower id=${id}`)),
      catchError(this.handleError<Superpower>(`getSuperpower id=${id}`))
    );
  }

  /** GET superpower by id. Return `undefined` when id not found */
  getSuperpowerNo404<Data>(id: string): Observable<Superpower> {
    const url = `${this.superpowersUrl}/?id=${id}`;
    return this.http.get<Superpower[]>(url)
      .pipe(
        map(superpowers => superpowers[0]), // returns a {0|1} element array
        tap(h => {
          const outcome = h ? 'fetched' : 'did not find';
          this.log(`${outcome} superpower id=${id}`);
        }),
        catchError(this.handleError<Superpower>(`getSuperpower id=${id}`))
      );
  }

  /** PUT: update the superpower on the server */
  updateSuperpower(superpower: Superpower): Observable<any> {
    return this.http.put(this.superpowersUrl, superpower, this.httpOptions).pipe(
      tap(_ => this.log(`updated superpower id=${superpower.superpowerId}`)),
      catchError(this.handleError<any>('updateSuperpower'))
    );
  }

  /** POST: add a new superpower to the server */
  addSuperpower(superpower: Superpower): Observable<Superpower> {
    return this.http.post<Superpower>(this.superpowersUrl, superpower, this.httpOptions).pipe(
      tap((newSuperpower: Superpower) => this.log(`added superpower w/ id=${newSuperpower.superpowerId}`)),
      catchError(this.handleError<Superpower>('addSuperpower'))
    );
  }

  /**
   * Combine the two methods to add a whole super power
   * @param fileToUpload
   */
  addSuperpowerPicture(fileToUpload: File): Observable<boolean> {
    const url = `${this.superpowersUrl}/picture`;
    const formData: FormData = new FormData();
    formData.append('fileKey', fileToUpload, fileToUpload.name);
    return this.http
      .post<boolean>(url, formData, this.httpOptions).pipe(
        tap(_ => this.log(`added Superpower picture`)),
        catchError(this.handleError<boolean>('addSuperpowerPicture'))
      );
  }

  /** DELETE: delete the superpower from the server */
  deleteSuperpower(id: string): Observable<Superpower> {
    const url = `${this.superpowersUrl}/${id}`;

    return this.http.delete<Superpower>(url, this.httpOptions).pipe(
      tap(_ => this.log(`deleted superpower id=${id}`)),
      catchError(this.handleError<Superpower>('deleteSuperpower'))
    );
  }

  /* GET superpowers whose name contains search term */
  searchSuperpowers(term: string): Observable<Superpower[]> {
    if (!term.trim()) {
      // if not search term, return empty superpower array.
      return of([]);
    }
    return this.http.get<Superpower[]>(`${this.superpowersUrl}/Search?name=${term}`).pipe(
      tap(x => x.length ?
        this.log(`found superpowers matching "${term}"`) :
        this.log(`no superpowers matching "${term}"`)),
      catchError(this.handleError<Superpower[]>('searchSuperpowers', []))
    );
  }

  /** Log a SuperpowerService message with the MessageService */
  private log(message: string) {
    this.messageService.add(`SuperpowerService: ${message}`);
  }

  /**
   * Handle Http operation that failed.
   * Let the app continue.
   *
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
