import { ValidatorField } from './../../../helpers/ValidatorField';
import { AbstractControl, AbstractControlOptions } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrls: ['./registration.component.scss']
})
export class RegistrationComponent implements OnInit {

  public form!: FormGroup;

  get f() : any{
    return this.form.controls
  }

  constructor(
    private formBuilder: FormBuilder,
    private localeService: BsLocaleService
    ) { }

  ngOnInit(): void {
    this.validation();
  }

  private validation(): void{

    const formOptions: AbstractControlOptions = {
      validators: ValidatorField.MustMath('password', 'confirmPassword')
    }

    this.form = this.formBuilder.group({
      firstName: ['', [Validators.required]],
      lastName: ['', Validators.required],
      email: ['', Validators.required, Validators.email],
      userName: ['', [Validators.required]],
      password: ['', Validators.required, Validators.minLength(6)],
      confirmPassword: ['', [Validators.required]],
      acceptTerms: ['', [Validators.required]]
    }, formOptions);
  }

  resetForm(){
    this.form.reset();
  }
}
