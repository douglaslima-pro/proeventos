import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Evento } from '../models/evento';
import { Observable } from 'rxjs';

@Injectable()
export class EventoService {

  private urlBase: string = 'https://localhost:5001/api';
  private path: string = '/evento';

  constructor(private http: HttpClient) { }

  public getEventos(): Observable<Evento[]> {
    return this.http.get<Evento[]>(`${this.urlBase}${this.path}`);
  }

  public getEventosByTema(tema: string): Observable<Evento[]> {
    return this.http.get<Evento[]>(`${this.urlBase}${this.path}/tema/${tema}`);
  }

  public getEventoById(id: number): Observable<Evento> {
    return this.http.get<Evento>(`${this.urlBase}${this.path}/${id}`);
  }

}
