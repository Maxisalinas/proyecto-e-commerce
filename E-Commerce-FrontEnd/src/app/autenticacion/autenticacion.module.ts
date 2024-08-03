import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ReactiveFormsModule } from '@angular/forms';

import { AutenticacionRoutingModule } from './autenticacion-routing.module';
import { AutenticacionLayoutPaginaComponent } from './paginas/autenticacion-layout-pagina/autenticacion-layout-pagina.component';
import { IngresoPaginaComponent } from './paginas/ingreso-pagina/ingreso-pagina.component';
import { RegistroPaginaComponent } from './paginas/registro-pagina/registro-pagina.component';


@NgModule({
  declarations: [
    AutenticacionLayoutPaginaComponent,
    IngresoPaginaComponent,
    RegistroPaginaComponent,

  ],
  imports: [
    CommonModule,
    AutenticacionRoutingModule,
    ReactiveFormsModule,

  ]
})
export class AutenticacionModule { }
