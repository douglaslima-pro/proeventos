import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Component({
  selector: 'eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any = []
  public eventosFiltrados: any = []
  public imgWidth: number = 150
  public isImgCollapsed: boolean = false
  private _filtroLista: string = ''

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos()
  }

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(filtroLista: string) {
    this._filtroLista = filtroLista;
    this.eventosFiltrados = this._filtroLista ? this.filtrarEventos(filtroLista) : this.eventos
  }

  public filtrarEventos(filtroLista: string): any {
    return this.eventos.filter(
        (evento: {tema: string; }) => evento.tema.toLocaleLowerCase().indexOf(filtroLista.toLocaleLowerCase()) !== -1
    )
  }

  public getEventos(): any {
    this.http
      .get('https://localhost:5001/api/Evento')
      .subscribe(
        response => {
          this.eventos = response
          this.eventosFiltrados = response
        },
        error => console.log(error)
      )
  }

  public toggleIsImgCollapsed(): void {
    this.isImgCollapsed = !this.isImgCollapsed
  }

}
