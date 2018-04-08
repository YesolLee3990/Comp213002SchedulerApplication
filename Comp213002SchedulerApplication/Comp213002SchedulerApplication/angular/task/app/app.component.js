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
var task_service_1 = require("./task.service");
var Subject_1 = require("rxjs/Subject");
var operators_1 = require("rxjs/operators");
var AppComponent = /** @class */ (function () {
    function AppComponent(taskService) {
        this.taskService = taskService;
        this.title = 'Assign Task';
        this.isValid = true;
        this.searchTerms = new Subject_1.Subject();
    }
    AppComponent.prototype.search = function (term) {
        this.task.UserInfo_Id = 0;
        this.isValid = false;
        if (term && term.indexOf("/") < 0) {
            this.searchTerms.next(term);
        }
    };
    AppComponent.prototype.ngOnInit = function () {
        this.getInitTask();
        this.initUserList();
    };
    AppComponent.prototype.initUserList = function () {
        var _this = this;
        this.userList$ = this.searchTerms.pipe(
        // wait 300ms after each keystroke before considering the term
        operators_1.debounceTime(300), 
        // ignore new term if same as previous term
        operators_1.distinctUntilChanged(), 
        // switch to new search observable each time the term changes
        operators_1.switchMap(function (term) { return _this.taskService.getUserList(term); }));
    };
    AppComponent.prototype.getInitTask = function () {
        var _this = this;
        this.taskId = this.getUrlParameter('id');
        this.mode = this.getUrlParameter('mode');
        this.taskService.getTask(this.taskId).subscribe(function (initialTask) {
            _this.task = initialTask;
            _this.userName = _this.task.UserName;
            _this.task.ScheduleStart = new Date(_this.task.ScheduleStart).toISOString().slice(0, 10);
            _this.task.ScheduleEnd = new Date(_this.task.ScheduleEnd).toISOString().slice(0, 10);
        });
    };
    AppComponent.prototype.getUrlParameter = function (name) {
        name = name.replace(/[\[]/, '\\[').replace(/[\]]/, '\\]');
        var regex = new RegExp('[\\?&]' + name + '=([^&#]*)');
        var results = regex.exec(location.search);
        return results === null ? '' : decodeURIComponent(results[1].replace(/\+/g, ' '));
    };
    ;
    AppComponent.prototype.setUserInfo = function (id, userName, userId) {
        this.task.UserInfo_Id = id;
        this.userName = userName + ' / ' + userId;
        this.initUserList();
        if (this.task.UserInfo_Id != 0)
            this.isValid = true;
    };
    AppComponent.prototype.saveTask = function () {
        if (confirm('Do you want to save?')) {
            this.taskService.saveTask(this.task).subscribe(function (result) {
                if (result.Success) {
                    alert('Saved successfully');
                    window.open('', '_self').close();
                }
                else {
                    alert(result.ErrMsg);
                }
            });
        }
    };
    AppComponent.prototype.deleteTask = function () {
        if (confirm('Do you want to delete?')) {
            this.task.DeleteFlag = '1';
            this.taskService.saveTask(this.task).subscribe(function (result) {
                if (result.Success) {
                    alert('Delete successfully');
                    window.open('', '_self').close();
                }
                else {
                    alert(result.ErrMsg);
                }
            });
        }
    };
    AppComponent.prototype.cancelTask = function () {
        if (confirm('Do you want to close the window without saving?')) {
            window.open('', '_self').close();
        }
    };
    AppComponent = __decorate([
        core_1.Component({
            selector: 'my-app',
            templateUrl: './task.component.html',
            styleUrls: ['../../../css/task.component.css']
        }),
        __metadata("design:paramtypes", [task_service_1.TaskService])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map