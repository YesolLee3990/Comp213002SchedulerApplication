"use strict";
var __decorate = (this && this.__decorate) || function (decorators, target, key, desc) {
    var c = arguments.length, r = c < 3 ? target : desc === null ? desc = Object.getOwnPropertyDescriptor(target, key) : desc, d;
    if (typeof Reflect === "object" && typeof Reflect.decorate === "function") r = Reflect.decorate(decorators, target, key, desc);
    else for (var i = decorators.length - 1; i >= 0; i--) if (d = decorators[i]) r = (c < 3 ? d(r) : c > 3 ? d(target, key, r) : d(target, key)) || r;
    return c > 3 && r && Object.defineProperty(target, key, r), r;
};
var __metadata = (this && this.__metadata) || function (k, v) {
    if (typeof Reflect === "object" && typeof Reflect.metadata === "function") return Reflect.metadata(k, v);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = require("@angular/core");
var of_1 = require("rxjs/observable/of");
var http_1 = require("@angular/common/http");
var operators_1 = require("rxjs/operators");
var TaskService = /** @class */ (function () {
    function TaskService(http) {
        this.http = http;
        this.taskUrl = 'api/task'; // URL to web api
    }
    TaskService.prototype.handleError = function (operation, result) {
        if (operation === void 0) { operation = 'operation'; }
        return function (error) {
            console.error(error);
            return of_1.of(result);
        };
    };
    TaskService.prototype.getTask = function (id) {
        var url = this.taskUrl + "/" + id;
        return this.http.get(url).pipe(operators_1.catchError(this.handleError("getHero id=" + id)));
    };
    TaskService.prototype.updateTask = function (hero) {
        var httpOptions = {
            headers: new http_1.HttpHeaders({ 'Content-Type': 'application/json' })
        };
        return this.http.put(this.taskUrl, hero, httpOptions).pipe(operators_1.catchError(this.handleError('updateHero')));
    };
    TaskService.prototype.addTask = function (task) {
        var httpOptions = {
            headers: new http_1.HttpHeaders({ 'Content-Type': 'application/json' })
        };
        return this.http.post(this.taskUrl, task, httpOptions).pipe(operators_1.catchError(this.handleError('addHero')));
    };
    TaskService.prototype.deleteHero = function (task) {
        var id = typeof task === 'number' ? task : task.id;
        var url = this.taskUrl + "/" + id;
        var httpOptions = {
            headers: new http_1.HttpHeaders({ 'Content-Type': 'application/json' })
        };
        return this.http.delete(url, httpOptions).pipe(operators_1.catchError(this.handleError('deleteTask')));
    };
    TaskService.prototype.searchHeroes = function (term) {
        if (!term.trim()) {
            // if not search term, return empty hero array.
            return of_1.of([]);
        }
        return this.http.get("api/heroes/?name=" + term).pipe(operators_1.catchError(this.handleError('searchHeroes', [])));
    };
    TaskService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [http_1.HttpClient])
    ], TaskService);
    return TaskService;
}());
exports.TaskService = TaskService;
//# sourceMappingURL=task.service.js.map