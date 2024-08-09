import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { AutenticacionRoutingModule } from './autenticacion-routing.module';
import { AutenticacionLayoutPaginaComponent } from './paginas/autenticacion-layout-pagina/autenticacion-layout-pagina.component';
import { IngresoPaginaComponent } from './paginas/ingreso-pagina/ingreso-pagina.component';
import { RegistroPaginaComponent } from './paginas/registro-pagina/registro-pagina.component';
import { RecuperarPasswordComponent } from './paginas/recuperar-password/recuperar-password.component';
import { FeedbackRestablecerPasswordComponent } from './paginas/feedback-restablecer-password/feedback-restablecer-password.component';
import { RestablecerPasswordComponent } from './paginas/restablecer-password/restablecer-password.component';


@NgModule({
  declarations: [
    AutenticacionLayoutPaginaComponent,
    IngresoPaginaComponent,
    RegistroPaginaComponent,
    RecuperarPasswordComponent,
    FeedbackRestablecerPasswordComponent,
    RestablecerPasswordComponent,

  ],
  imports: [
    CommonModule,
    AutenticacionRoutingModule,
    ReactiveFormsModule,

  ]
})
export class AutenticacionModule { }
