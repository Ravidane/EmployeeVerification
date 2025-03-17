import { Component, OnInit, TemplateRef } from '@angular/core';
import { EmployeeApiService } from '../services/EmployeeApiService';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

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
    private employeeApiService: EmployeeApiService) { }

  ngOnInit(): void {
    this.employeeForm = this.fb.group({
      EmployeeID: ['', [Validators.required, Validators.pattern('^[0-9]+$')]],
      CompanyName: ['', Validators.required],
      ValidationCode: ['', Validators.required]
    });
  }

  verifyEmployee(): void {
    this.employeeApiService.verifyEmployee(this.employeeForm.value).subscribe({
      next: _ => {
        this.dialogMessage = 'Verified';
        this.showDialog = true;
      },
        error: _ => {
        this.dialogMessage = 'Not Verified';
        this.showDialog = true;
      }
    });
  }

  closeDialog() {
    this.showDialog = false;
  }
}
