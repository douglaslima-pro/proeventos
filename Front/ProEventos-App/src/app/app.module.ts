import { NgModule } from '@angular/core'
import { BrowserModule } from '@angular/platform-browser'
import { HttpClientModule } from '@angular/common/http'
import { FormsModule } from '@angular/forms'
import { ModalModule } from 'ngx-bootstrap/modal';

import { AppRoutingModule } from './app-routing.module'
import { AppComponent } from './app.component'
import { EventosComponent } from './components/eventos/eventos.component'
import { PalestrantesComponent } from './components/palestrantes/palestrantes.component'
import { BrowserAnimationsModule } from '@angular/platform-browser/animations'
import { NavComponent } from './shared/nav/nav.component'

import { CollapseModule } from 'ngx-bootstrap/collapse'
import { TooltipModule } from 'ngx-bootstrap/tooltip'
import { BsDropdownModule } from 'ngx-bootstrap/dropdown'
import { EventoService } from './services/evento.service'
import { DateTimeFormatterPipe } from './helpers/date-time-formatter.pipe'
import { ToastrModule } from 'ngx-toastr';
import { NgxSpinnerModule } from "ngx-spinner";
import { TituloComponent } from './shared/titulo/titulo.component';
import { PerfilComponent } from './components/perfil/perfil.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { ContatosComponent } from './components/contatos/contatos.component';

@NgModule({
  declarations: [
    AppComponent,
    EventosComponent,
    PalestrantesComponent,
    NavComponent,
    DateTimeFormatterPipe,
    TituloComponent,
    PerfilComponent,
    DashboardComponent,
    ContatosComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    CollapseModule.forRoot(),
    FormsModule,
    TooltipModule,
    BsDropdownModule,
    ModalModule.forRoot(),
    ToastrModule.forRoot({
      timeOut: 5000,
      positionClass: 'toast-bottom-right',
      preventDuplicates: true,
      progressBar: true
    }),
    NgxSpinnerModule 
  ],
  providers: [
    EventoService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
