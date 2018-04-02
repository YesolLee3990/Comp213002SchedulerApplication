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
var update_task_service_service_1 = require("./update-task-service.service");
var AppComponent = /** @class */ (function () {
    function AppComponent(updateTaskService) {
        this.updateTaskService = updateTaskService;
    }
    AppComponent.prototype.ngOnInit = function () {
        this.getInitTask();
    };
    AppComponent.prototype.getInitTask = function () {
        var _this = this;
        var taskId = this.getUrlParameter('taskId');
        if (taskId) {
            this.updateTaskService.getTask(taskId).subscribe(function (initialTask) {
                _this.task = initialTask;
                _this.getAssignorInfo();
            });
        }
        else {
            alert('Give url path is wrong. ');
            window.open('', '_self').close();
        }
    };
    AppComponent.prototype.getAssignorInfo = function () {
        var _this = this;
        this.updateTaskService.getAssignerUserInfo(this.task).subscribe(function (assignorInfo) {
            _this.assignor = assignorInfo.UserName + '(' + assignorInfo.UserId + ')';
        });
    };
    AppComponent.prototype.saveTask = function () {
        var _this = this;
        if (confirm('Do you want to save?')) {
            this.updateTaskService.saveTask(this.task).subscribe(function (result) {
                if (result.Success) {
                    alert('Saved successfully');
                    if (opener && opener.refreshPage) {
                        opener.refreshPage(_this.task.ScheduleStart);
                    }
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
    AppComponent.prototype.getUrlParameter = function (key) {
        var url = new URL(window.location.href);
        return url.searchParams.get(key);
    };
    AppComponent = __decorate([
        core_1.Component({
            selector: 'my-app',
            templateUrl: './updateTask.component.html',
            styleUrls: ['../../../css/task.component.css']
        }),
        __metadata("design:paramtypes", [update_task_service_service_1.UpdateTaskService])
    ], AppComponent);
    return AppComponent;
}());
exports.AppComponent = AppComponent;
//# sourceMappingURL=app.component.js.map