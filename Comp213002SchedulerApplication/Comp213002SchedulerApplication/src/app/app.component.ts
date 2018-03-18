import { Component, OnInit  } from '@angular/core';
import { Http } from '@angular/http';
import { Task } from './task';
import { TaskService } from "./task.service";

@Component({
    selector: 'my-app',
    templateUrl: './app.component.html',
    styleUrls: ['./app.component.css']
    //template: `<h1>Hello {{name}}</h1>`,
})
export class AppComponent implements OnInit {
    constructor(private taskService: TaskService) { }

    task: Task;
    ngOnInit() {
        //this.taskService.getInitTask().subscribe(initialTask => { this.task = initialTask.json() as Task })
        this.taskService.getTask(0).subscribe(initialTask => { this.task = initialTask as Task });
    }
    title = 'Assign Task';
}
