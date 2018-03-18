import { Injectable } from '@angular/core';
import { Task } from './task';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { catchError, map, tap } from 'rxjs/operators';

@Injectable()
export class TaskService {

    private taskUrl = 'api/task'; // URL to web api

    constructor(
        private http: HttpClient,
    ) { }

    private handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {
            console.error(error);
            return of(result as T);
        };
    }

    getTask(id: number): Observable<Task> {
        const url = `${this.taskUrl}/${id}`;
        return this.http.get<Task>(url).pipe(
            catchError(this.handleError<Task>(`getHero id=${id}`))
        );
    }


    updateTask(hero: Task): Observable<any> {
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        };

        return this.http.put(this.taskUrl, hero, httpOptions).pipe(
            catchError(this.handleError<any>('updateHero'))
        );
    }

    addTask(task: Task): Observable<Task> {
        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        };

        return this.http.post<Task>(this.taskUrl, task, httpOptions).pipe(
            catchError(this.handleError<Task>('addHero'))
        );
    }

    deleteHero(task: Task | number): Observable<Task> {
        const id = typeof task === 'number' ? task : task.id;
        const url = `${this.taskUrl}/${id}`;

        const httpOptions = {
            headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        };

        return this.http.delete<Task>(url, httpOptions).pipe(
            catchError(this.handleError<Task>('deleteTask'))
        );
    }

    searchHeroes(term: string): Observable<Task[]> {
        if (!term.trim()) {
            // if not search term, return empty hero array.
            return of([]);
        }

        return this.http.get<Task[]>(`api/heroes/?name=${term}`).pipe(
            catchError(this.handleError<Task[]>('searchHeroes', []))
        );
    }
}
