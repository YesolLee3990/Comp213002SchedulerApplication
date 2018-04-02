"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var testing_1 = require("@angular/core/testing");
var update_task_service_service_1 = require("./update-task-service.service");
describe('UpdateTaskServiceService', function () {
    beforeEach(function () {
        testing_1.TestBed.configureTestingModule({
            providers: [update_task_service_service_1.UpdateTaskService]
        });
    });
    it('should be created', testing_1.inject([update_task_service_service_1.UpdateTaskService], function (service) {
        expect(service).toBeTruthy();
    }));
});
//# sourceMappingURL=update-task-service.service.spec.js.map