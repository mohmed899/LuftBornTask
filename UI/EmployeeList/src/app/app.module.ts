import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ButtonModule } from 'primeng/button';
import { TableModule } from 'primeng/table';

import { AppComponent } from './app.component';
import { EmployeeGridComponent } from './Componets/employee-grid/employee-grid.component';
import { EmployeeService } from './Services/EmployeeService/employee-service.service';
import { HttpClientModule } from '@angular/common/http';
import { ToolbarModule } from 'primeng/toolbar';
import { EmployeeFormComponent } from './Componets/employee-form/employee-form.component';

import { MessagesModule } from 'primeng/messages';
import { MessageService } from 'primeng/api';
import{ ReactiveFormsModule } from '@angular/forms';
import {DynamicDialogModule} from 'primeng/dynamicdialog';
import {InputTextModule} from 'primeng/inputtext';
import {ToastModule} from 'primeng/toast';
import { ToastService } from './Services/ToastService/toast.service';
import { ConfirmationService } from 'primeng/api';
import { ConfirmDialogModule } from 'primeng/confirmdialog';
@NgModule({
  declarations: [
    AppComponent,
    EmployeeGridComponent,
    EmployeeFormComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    ButtonModule,
    TableModule,
    HttpClientModule,
    ToolbarModule,
    ToastModule,
    InputTextModule,
    ReactiveFormsModule,
    MessagesModule,
    ConfirmDialogModule
    
   
  
  ],
  providers: [EmployeeService,ToastService,ConfirmationService,MessageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
