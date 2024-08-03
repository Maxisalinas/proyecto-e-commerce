import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { UsuarioRoutingModule } from './usuario-routing.module';
import { UsuarioLayoutPaginaComponent } from './paginas/usuario-layout-pagina/usuario-layout-pagina.component';
import { HistorialComprasPaginasComponent } from './paginas/historial-compras-paginas/historial-compras-paginas.component';
import { ConfiguracionPaginaComponent } from './paginas/configuracion-pagina/configuracion-pagina.component';


@NgModule({
  declarations: [
    UsuarioLayoutPaginaComponent,
    HistorialComprasPaginasComponent,
    ConfiguracionPaginaComponent
  ],
  imports: [
    CommonModule,
    UsuarioRoutingModule
  ]
})
export class UsuarioModule { }
