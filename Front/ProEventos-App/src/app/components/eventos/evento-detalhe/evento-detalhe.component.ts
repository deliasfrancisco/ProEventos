import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { BsLocaleService } from 'ngx-bootstrap/datepicker';

@Component({
  selector: 'app-evento-detalhe',
  templateUrl: './evento-detalhe.component.html',
  styleUrls: ['./evento-detalhe.component.scss']
})
export class EventoDetalheComponent implements OnInit {

  public form!: FormGroup;

  get f() : any{
    return this.form.controls
  }

  constructor(
    private formBuilder: FormBuilder,
    private localeService: BsLocaleService
    ) {
      this.localeService.use('pt-br');
    }

  ngOnInit(): void {
    this.validation();
  }

  public validation(): void{

    this.form = this.formBuilder.group({
      Tema: ['', [Validators.required, Validators.minLength(4), Validators.maxLength(50)]],
      Local: ['', Validators.required],
      DataEvento: ['', Validators.required],
      QtdPessoas: ['', [Validators.required, Validators.max(1200)]],
      Telefone: ['', Validators.required],
      Email: ['', [Validators.required, Validators.email]],
      ImagemURL: ['']
    });
  }

  resetForm(){
    this.form.reset();
  }
}
