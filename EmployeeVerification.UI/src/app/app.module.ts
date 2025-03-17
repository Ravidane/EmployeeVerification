import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { EmployeeVerificationComponent } from '../pages/EmployeeValidatorComponent';
import { EmployeeApiService } from '../services/EmployeeApiService';
import { ReactiveFormsModule } from '@angular/forms';

@NgModule({
  declarations: [
    EmployeeVerificationComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    ReactiveFormsModule 
  ],
  providers: [EmployeeApiService],
  bootstrap: [EmployeeVerificationComponent]
})
export class AppModule { }
