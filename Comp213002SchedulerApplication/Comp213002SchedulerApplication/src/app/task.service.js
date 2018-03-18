"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var TaskService = /** @class */ (function () {
    function TaskService() {
        this.taskUrl = 'api/task'; // URL to web api
        //constructor(
        //    private http: HttpClient,
        //) { }
        //private handleError<T>(operation = 'operation', result?: T) {
        //    return (error: any): Observable<T> => {
        //        console.error(error);
        //        return of(result as T);
        //    };
        //}
        //getTask(id: number): Observable<Task> {
        //    alert('id : ' +  id);
        //    const url = `${this.taskUrl}/${id}`;
        //    return this.http.get<Task>(url).pipe(
        //        catchError(this.handleError<Task>(`getHero id=${id}`))
        //    );
        //}
        //updateTask(hero: Task): Observable<any> {
        //    const httpOptions = {
        //        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        //    };
        //    return this.http.put(this.taskUrl, hero, httpOptions).pipe(
        //        catchError(this.handleError<any>('updateHero'))
        //    );
        //}
        //addTask(task: Task): Observable<Task> {
        //    const httpOptions = {
        //        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        //    };
        //    return this.http.post<Task>(this.taskUrl, task, httpOptions).pipe(
        //        catchError(this.handleError<Task>('addHero'))
        //    );
        //}
        //deleteHero(task: Task | number): Observable<Task> {
        //    const id = typeof task === 'number' ? task : task.id;
        //    const url = `${this.taskUrl}/${id}`;
        //    const httpOptions = {
        //        headers: new HttpHeaders({ 'Content-Type': 'application/json' })
        //    };
        //    return this.http.delete<Task>(url, httpOptions).pipe(
        //        catchError(this.handleError<Task>('deleteTask'))
        //    );
        //}
        //searchHeroes(term: string): Observable<Task[]> {
        //    if (!term.trim()) {
        //        // if not search term, return empty hero array.
        //        return of([]);
        //    }
        //    return this.http.get<Task[]>(`api/heroes/?name=${term}`).pipe(
        //        catchError(this.handleError<Task[]>('searchHeroes', []))
        //    );
        //}
    }
    TaskService = __decorate([
        core_1.Injectable()
    ], TaskService);
    return TaskService;
}());
exports.TaskService = TaskService;
//# sourceMappingURL=task.service.js.map