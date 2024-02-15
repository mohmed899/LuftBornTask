import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { EmployeeService } from 'src/app/Services/EmployeeService/employee-service.service';
import { ToastMsgType, ToastService } from 'src/app/Services/ToastService/toast.service';
import { DynamicDialogConfig, DynamicDialogRef } from 'primeng/dynamicdialog';
import { Employee } from 'src/app/Interfaces/IEmpolyee';

@Component({
  selector: 'app-employee-form',
  templateUrl: './employee-form.component.html',
  styleUrls: ['./employee-form.component.css']
})
export class EmployeeFormComponent {
  uploadedImge: any;
  myForm: FormGroup;
  empData: any | undefined;
  FormMode: string = '';
  rr = this;
  constructor(
    private employeeService: EmployeeService,
    public ref: DynamicDialogRef,
    private fb: FormBuilder,
    private toastService: ToastService,
    public config: DynamicDialogConfig) {

    this.myForm = this.createFormGroup();
    this.empData = this.config.data.emp;
    this.FormMode = this.config.data.Mode;
  }


  ngOnInit(): void {
    if (this.FormMode == 'Edit')
      this.HandeFormEditValue();

  }



  closePopup(refresh: boolean): void {
    this.ref.close(refresh);
  }

  createFormGroup() {
    return (this.fb.group({
      id: [0],
      name: [null, Validators.required],
      email: [null, [Validators.required, Validators.email]],
      address: [null, Validators.required],
      phone: [null, [Validators.required, Validators.pattern('[- +()0-9]+')]],
    }));
  }

  save() {
    if (this.myForm.valid) {
      if (this.FormMode === 'Create')
        this.employeeService.add(this.myForm.value)
         .subscribe({next: (r)=>{this.onRequestSccess()} ,error:e=>this.onRequestFailed()}); 
      else if (this.FormMode === 'Edit')
        this.employeeService.update(this.myForm.value, this.empData?.id)
        .subscribe({next: (r)=>{this.onRequestSccess()} , error:e=>this.onRequestFailed()}); 
    }else{
      this.toastService.openToast("plz enter right Data ", ToastMsgType.Error);
    }
  }

  HandeFormEditValue() {
    this.myForm.setValue(this.empData);
  }

  onRequestSccess() {
    this.toastService.openToast("Saved Successfuly ", ToastMsgType.Success);
    this.closePopup(true); 
  }

  onRequestFailed() {
    this.toastService.openToast("Error ", ToastMsgType.Error);
    this.closePopup(false); 
  }


}
