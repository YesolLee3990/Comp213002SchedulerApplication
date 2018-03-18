import { NgModule } from "@angular/core";
import { BrowserModule } from "@angular/platform-browser";

import { TaskService } from "./task.service";
import { AppComponent } from "./app.component";

import { FormsModule } from "@angular/forms";
import { HttpModule } from "@angular/http";

@NgModule({
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule
    ],
    declarations: [AppComponent],
    bootstrap: [AppComponent],
    providers: [
        TaskService
    ]
})
export class AppModule { }
