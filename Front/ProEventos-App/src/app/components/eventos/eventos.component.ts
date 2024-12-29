import { Component, OnInit, TemplateRef } from '@angular/core';
import { EventoService } from '../../services/evento.service';
import { Evento } from '../../models/evento';
import { BsModalRef, BsModalService } from 'ngx-bootstrap/modal';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';

@Component({
  selector: 'eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public modalRef?: BsModalRef;
  public eventos: Evento[] = [];
  public eventosFiltrados: Evento[] = [];
  public imgWidth: number = 150;
  public isImgCollapsed: boolean = false;
  private _filtroLista: string = '';

  constructor(
    private eventoService: EventoService,
    private modalService: BsModalService,
    private toastr: ToastrService,
    private spinner: NgxSpinnerService
  ) { }

  openModal(template: TemplateRef<any>): void {
    this.modalRef = this.modalService.show(template, { class: "modal-sm" });
  }

  confirm(): void {
    this.modalRef?.hide();
    this.toastr.success("Evento excluído com sucesso!", "Sucesso");
  }

  decline(): void {
    this.modalRef?.hide();
  }

  ngOnInit(): void {
    this.spinner.show();
    this.getEventos();
  }

  public get filtroLista(): string {
    return this._filtroLista;
  }

  public set filtroLista(filtroLista: string) {
    this._filtroLista = filtroLista;
    if (!this._filtroLista) {
      this.eventosFiltrados = this.eventos;
    } else {
      this.eventosFiltrados = this.filtrarEventos(filtroLista);
    }
  }

  public filtrarEventos(filtroLista: string): Evento[] {
    return this.eventos.filter(
        (evento: Evento) => evento.tema.toLocaleLowerCase().indexOf(filtroLista.toLocaleLowerCase()) !== -1
    )
  }

  public getEventos(): any {
    this.eventoService.getEventos()
      .subscribe({
        next: response => {
          this.eventos = response;
          this.eventosFiltrados = response;
        },
        error: error => {
          this.toastr.error("Erro de conexão com o servidor!", "Erro");
          this.spinner.hide();
        },
        complete: () => this.spinner.hide()
      });
  }

  public toggleIsImgCollapsed(): void {
    this.isImgCollapsed = !this.isImgCollapsed;
  }

}
