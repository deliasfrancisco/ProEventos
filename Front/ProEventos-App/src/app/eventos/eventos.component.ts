import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

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

  filtrarEventos(filtrarpor: string): any{
    filtrarpor = filtrarpor.toLowerCase();
    return this.eventos.filter(
      (evento:any) => evento.tema.toLocaleLowerCase().indexOf(filtrarpor) !== -1 // esta filtrando os eventos
      || evento.local.toLocaleLowerCase().indexOf(filtrarpor) !== -1
    );
  }

  constructor(
    private http: HttpClient
    ) { }

  ngOnInit(): void {
    this.getEventos();
  }

  public getEventos(): void {
    this.http.get('http://localhost:5000/api/evento/GetAll')
    .subscribe(response =>{
      this.eventos = response,
      this.eventosFiltrados = this.eventos;
    },
    error => console.log(error))
  }

  mostrar(){
    this.mostrarImagem = !this.mostrarImagem;
  }
}
