import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'titulo',
  templateUrl: './titulo.component.html',
  styleUrls: ['./titulo.component.scss']
})
export class TituloComponent implements OnInit {

  @Input() titulo: string = "Título";

  constructor() {}

  ngOnInit(): void {
  }

}
