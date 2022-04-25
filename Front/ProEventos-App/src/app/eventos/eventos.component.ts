import { HttpClient } from '@angular/common/http';
import { Component, OnInit, TemplateRef } from '@angular/core';
import { Evento } from '../models/Evento';
import { EventoService } from '../services/evento.service';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {
  modalRef?: BsModalRef;
  public eventos: any = [];
  public eventosFiltrados: any = [];
  mostrarImagem = true;
  private _filtroLista = '';

  public get filtroLista() : string {
    return this._filtroLista;
  }

  public set filtroLista(value) {
    this._filtroLista = value;
    this.eventosFiltrados = this.filtroLista ? this.filtrarEventos(this.filtroLista) : this.eventos;
  }

  public filtrarEventos(filtrarpor: string): any{
    filtrarpor = filtrarpor.toLowerCase();
    return this.eventos.filter(
      (evento:any) => evento.tema.toLocaleLowerCase().indexOf(filtrarpor) !== -1 // esta filtrando os eventos
      || evento.local.toLocaleLowerCase().indexOf(filtrarpor) !== -1
    );
  }

  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
    ) { }

  ngOnInit(): void {
    this.spinner.show();
    this.getEventos();
  }

  public getEventos(): void {
    // this.dataAtual = new Date().getMilliseconds().toString();
    this.eventoService.getAllEvento().subscribe(
      (_evento: Evento[]) => {
        this.eventos = _evento;
        this.eventosFiltrados = this.eventos;
        this.spinner.hide();
      },
      error => {
        console.log(error);
        this.spinner.hide();
        this.toastr.error('Erro ao carregar os eventos', 'Erro');
      }
    );
  }

  public mostrar(){
    this.mostrarImagem = !this.mostrarImagem;
  }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template, {class: 'modal-sm'});
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success('Evento deletado com sucesso', 'Sucesso!', {
      timeOut: 3000,
    });
  }

  decline(): void {
    this.modalRef?.hide();
  }
}
