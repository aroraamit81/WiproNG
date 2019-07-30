import { Component, OnInit } from '@angular/core';
import { Training } from '../classes';
import { TrainingService } from "../training.service";
import {
  FormControl, FormGroup, FormBuilder, Validators, AbstractControl, ValidationErrors
} from "@angular/forms";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent implements OnInit {

  constructor(private fb: FormBuilder, private trainingService: TrainingService) { }

  trgForm: FormGroup;
  ValidDatePater: string = "(0?[1-9]|[12][0-9]|3[01])/(0?[1-9]|1[012])/((19|20)\\d\\d)";
  public ngOnInit() {

    this.trgForm = this.fb.group(
      {
        Name: ['', Validators.required],
        StartDate: ["", [Validators.required, Validators.pattern(this.ValidDatePater)]],
        EndDate: ["", [Validators.required, Validators.pattern(this.ValidDatePater)]]
        
      });
}
InvalidDates: boolean = false;

IsEndDateGreaterThanStartDate() {

  const StartDateVal: Date = new Date(this.StartDate.value);
  const EndDateVal: Date = new Date(this.StartDate.value);


  this.InvalidDates = true;
  if (this.StartDate.value < this.EndDate.value || (this.IsStartDateInvalid && !this.IsEndDateInvalid && this.EndDate.pristine && this.EndDate.value === '')) {
    this.InvalidDates = false;
  }

}
get Name(): AbstractControl {
  return this.trgForm.controls.Name;
}
get StartDate(): AbstractControl {
  return this.trgForm.controls.StartDate;
}
get EndDate(): AbstractControl {
  return this.trgForm.controls.EndDate;
}



get IsNameBlank(): boolean {

  return (
    (this.Name.touched || this.Name.dirty) &&
    this.Name.errors != null && this.Name.errors.required
  );

}
get IsStartDateBlank(): boolean {
  return (
    (this.StartDate.touched || this.StartDate.dirty) &&
    this.StartDate.errors != null && this.StartDate.errors.required
  );

}
get IsEndDateBlank(): boolean {

  return (
    (this.EndDate.touched || this.EndDate.dirty) &&
    this.EndDate.errors != null && this.EndDate.errors.required
  );

}
get IsStartDateInvalid(): boolean {
  return (
    (this.StartDate.touched || this.StartDate.dirty) &&
    this.StartDate.errors != null && !this.StartDate.errors.required && this.StartDate.errors.pattern
  );

}
get IsEndDateInvalid(): boolean {

  return (
    (this.EndDate.touched || this.EndDate.dirty) &&
    this.EndDate.errors != null && !this.EndDate.errors.required && this.EndDate.errors.pattern
  );

}
get IsFormValid(): boolean {
  return (this.trgForm.touched && this.trgForm.valid && !this.InvalidDates);
}
message: string="";

  public OnSubmit() {

  const t: Training = { Id: 0, Name: this.Name.value, StartDate: new Date(this.StartDate.value), EndDate: new Date(this.EndDate.value) };
 

    const successMessage: string = "Data is saved successfully. Training duration is " + ((t.EndDate.getTime() - t.StartDate.getTime()) / 1000 / 60 / 60 / 24) + " days";

  this.trainingService.addTraining(t)
    .subscribe(
    () => {
      this.message = successMessage;
      this.trgForm.reset();

    },
    (error: any) => this.message = error

    );

}

}
