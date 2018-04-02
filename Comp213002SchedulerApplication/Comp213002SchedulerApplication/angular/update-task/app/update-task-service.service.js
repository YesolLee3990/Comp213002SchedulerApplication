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
var Observable_1 = require("rxjs/Observable");
var http_1 = require("@angular/common/http");
var of_1 = require("rxjs/observable/of");
var httpOptions = {
    headers: new http_1.HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': 'my-auth-token'
    })
};
var UpdateTaskService = /** @class */ (function () {
    function UpdateTaskService(http) {
        this.http = http;
        this.getTaskUrl = '/api/task/';
        this.postTaskUrl = '/api/task/save';
        this.assignetInfoUrl = '/api/task/getAssginerInfo';
    }
    UpdateTaskService.prototype.getTask = function (taskId) {
        if (taskId != '')
            return this.http.get(this.getTaskUrl + taskId);
        else
            return new Observable_1.Observable();
    };
    UpdateTaskService.prototype.getAssignerUserInfo = function (task) {
        return this.http.post(this.assignetInfoUrl, task, httpOptions);
    };
    UpdateTaskService.prototype.handleError = function (operation, result) {
        if (operation === void 0) { operation = 'operation'; }
        return function (error) {
            console.error(error);
            return of_1.of(result);
        };
    };
    UpdateTaskService.prototype.saveTask = function (task) {
        return this.http.post(this.postTaskUrl, task, httpOptions);
    };
    UpdateTaskService = __decorate([
        core_1.Injectable(),
        __metadata("design:paramtypes", [http_1.HttpClient])
    ], UpdateTaskService);
    return UpdateTaskService;
}());
exports.UpdateTaskService = UpdateTaskService;
//# sourceMappingURL=update-task-service.service.js.map