import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http'

@Component({
  selector: 'eventos',
  templateUrl: './eventos.component.html',
  styleUrls: ['./eventos.component.scss']
})
export class EventosComponent implements OnInit {

  public eventos: any

  constructor(private http: HttpClient) { }

  ngOnInit(): void {
    this.getEventos()
  }

  public getEventos(): any {
    this.eventos = this.http
      .get('https://localhost:5001/api/Evento')
      .subscribe(
        response => this.eventos = response,
        error => console.log(error)
      )
  }

}
