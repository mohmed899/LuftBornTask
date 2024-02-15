import { Component } from '@angular/core';
import { DialogService } from 'primeng/dynamicdialog';
import { Column } from 'src/app/Interfaces/IColumn';
import { Employee } from 'src/app/Interfaces/IEmpolyee';
import { EmployeeService } from 'src/app/Services/EmployeeService/employee-service.service';
import { ToastMsgType, ToastService } from 'src/app/Services/ToastService/toast.service';
import { EmployeeFormComponent } from '../employee-form/employee-form.component';
import { DialogData } from 'src/app/Interfaces/IdialogDataTransfer';
import { ConfirmationService } from 'primeng/api';

@Component({
  selector: 'app-employee-grid',
  templateUrl: './employee-grid.component.html',
  styleUrls: ['./employee-grid.component.css'],
  providers: [DialogService]
})
export class EmployeeGridComponent {
  employees!: Employee[];
  cols!: Column[];
  ref!: any;



  constructor(private employeeService: EmployeeService,
    private dialogService: DialogService,
    private confirmationService: ConfirmationService,
    private toastService: ToastService) { }
  ngOnInit() {
    this.cols = [
      { field: 'id', header: 'Id' },
      { field: 'name', header: 'Name' },
      { field: 'email', header: 'Email' },
      { field: 'address', header: 'Address' },
      { field: 'phone', header: 'Phone' }
    ];
    this.getEntries();
  }

  editEmployee(employee: any) {
    this.openDialog('Edit Employee', { Mode: 'Edit', emp: employee })
  }
  deleteEmployee(employee: any) {
    this.showConfirmationDialog(() => {
      this.employeeService.delete(employee.id).subscribe(
        () => {
          this.toastService.openToast("Deleted Successfuly ", ToastMsgType.Delete);
          this.getEntries();
        })
    }, () => { })
  }

  openDialog(title: string, data: DialogData) {
    {
      this.ref = this.dialogService.open(EmployeeFormComponent, {
        header: title,
        width: '33%',
        data,
        baseZIndex: 10000
      });

      this.ref.onClose.subscribe((refresh: boolean) => {
        if (refresh) {
          this.getEntries();
        }
      });
    }
  }

  addEmployee() {
    this.openDialog('New Employee', { Mode: 'Create', emp: undefined })
  }

  getEntries() {
    this.employeeService.getAll().subscribe((data) => {
      this.employees = data;
    });
  }

  showConfirmationDialog(acceptFunc: Function, rejectFunc: Function) {

    this.confirmationService.confirm({
      target: event?.target as EventTarget,
      message: 'Do you want to delete this record?',
      header: 'Delete Confirmation',
      icon: 'pi pi-info-circle',
      acceptButtonStyleClass: "p-button-danger p-button-text",
      rejectButtonStyleClass: "p-button-text p-button-text",
      acceptIcon: "none",
      rejectIcon: "none",

      accept: () => acceptFunc(),
      reject: () => rejectFunc(),

    });
  }
}
