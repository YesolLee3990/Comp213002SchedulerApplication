import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";

import { TaskService } from "./task.service";
import { TaskComponent } from "./task.component";

import { FormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule
    ],
    declarations: [TaskComponent],
    bootstrap: [TaskComponent],
    providers: [
        TaskService
    ]
})
export class TaskModule { }
