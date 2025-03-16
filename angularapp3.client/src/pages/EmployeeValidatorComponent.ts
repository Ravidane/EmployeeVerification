import { Component, OnInit, TemplateRef } from '@angular/core';
import { EmployeeApiService } from '../services/EmployeeApiService';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';

@Component({
  selector: 'app-employee-verification',
  templateUrl: './EmployeValidatorComponent.html'
})
export class EmployeeVerificationComponent implements OnInit {
  employeeForm!: FormGroup;
  showDialog!: boolean;
  dialogMessage!: string;

  constructor(
    private fb: FormBuilder,
    private employeeApiService: EmployeeApiService,
    private dialog: MatDialog) { }

  ngOnInit(): void {
    this.employeeForm = this.fb.group({
      EmployeeID: ['', [Validators.required, Validators.pattern('^[0-9]+$')]],
      CompanyName: ['', Validators.required],
      ValidationCode: ['', Validators.required]
    });
}

  verifyEmployee(dialogRef: TemplateRef<any>): void {
    this.employeeApiService.verifyEmployee(this.employeeForm.value).subscribe({
      next: _ => {
        this.dialogMessage = 'Verified';
        this.dialog.open(dialogRef);
      },
        error: _ => {
        this.dialogMessage = 'Not Verified';
        this.dialog.open(dialogRef);
      }
    });
  }

  closeDialog(): void {
    this.showDialog = false;
  }
}
