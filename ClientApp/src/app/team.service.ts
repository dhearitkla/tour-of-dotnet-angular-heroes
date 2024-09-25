import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { MessageService } from './message.service';
import { Team } from './team';

@Injectable({providedIn: 'root'})
export class TeamService {

  /**
   * URL to web api
   * @private
   */
  private teamsUrl = 'https://localhost:7165/Team';

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  constructor( private http: HttpClient, private messageService: MessageService) { }

  /** GET teams from the server */
  getTeams(): Observable<Team[]> {
    return this.http.get<Team[]>(`${this.teamsUrl}`)
      .pipe(
        tap(_ => this.log('fetched teams')),
        catchError(this.handleError<Team[]>('getTeams', []))
      );
  }

  /** GET team by id. Will 404 if id not found */
  getTeam(id: string): Observable<Team> {
    const url = `${this.teamsUrl}/${id}`;
    return this.http.get<Team>(url).pipe(
      tap(_ => this.log(`fetched team id=${id}`)),
      catchError(this.handleError<Team>(`getTeam id=${id}`))
    );
  }

  /** GET team by id. Return `undefined` when id not found */
  getTeamNo404<Data>(id: string): Observable<Team> {
    const url = `${this.teamsUrl}/?id=${id}`;
    return this.http.get<Team[]>(url)
      .pipe(
        map(teams => teams[0]), // returns a {0|1} element array
        tap(h => {
          const outcome = h ? 'fetched' : 'did not find';
          this.log(`${outcome} team id=${id}`);
        }),
        catchError(this.handleError<Team>(`getTeam id=${id}`))
      );
  }

  /** PUT: update the team on the server */
  updateTeam(team: Team): Observable<any> {
    return this.http.put(this.teamsUrl, team, this.httpOptions).pipe(
      tap(_ => this.log(`updated team id=${team.teamId}`)),
      catchError(this.handleError<any>('updateTeam'))
    );
  }

  /** POST: add a new team to the server */
  addTeam(team: Team): Observable<Team> {
    return this.http.post<Team>(this.teamsUrl, team, this.httpOptions).pipe(
      tap((newTeam: Team) => this.log(`added team w/ id=${newTeam.teamId}`)),
      catchError(this.handleError<Team>('addTeam'))
    );
  }

  /** DELETE: delete the team from the server */
  deleteTeam(id: string): Observable<Team> {
    const url = `${this.teamsUrl}/${id}`;

    return this.http.delete<Team>(url, this.httpOptions).pipe(
      tap(_ => this.log(`deleted team id=${id}`)),
      catchError(this.handleError<Team>('deleteTeam'))
    );
  }

  /* GET teams whose name contains search term */
  searchTeams(term: string): Observable<Team[]> {
    if (!term.trim()) {
      // if not search term, return empty team array.
      return of([]);
    }
    return this.http.get<Team[]>(`${this.teamsUrl}/Search?name=${term}`).pipe(
      tap(x => x.length ?
        this.log(`found teams matching "${term}"`) :
        this.log(`no teams matching "${term}"`)),
      catchError(this.handleError<Team[]>('searchTeams', []))
    );
  }

  /** Log a TeamService message with the MessageService */
  private log(message: string) {
    this.messageService.add(`TeamService: ${message}`);
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
