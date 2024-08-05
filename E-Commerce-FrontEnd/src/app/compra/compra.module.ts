import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { CompraRoutingModule } from './compra-routing.module';

import { CompraLayoutPaginaComponent } from './paginas/compra-layout-pagina/compra-layout-pagina.component';
import { CompraPickupPaginaComponent } from './paginas/compra-pickup-pagina/compra-pickup-pagina.component';
import { CompraPagoPaginaComponent } from './paginas/compra-pago-pagina/compra-pago-pagina.component';
import { ResumenCompraComponent } from './componentes/resumen-compra/resumen-compra.component';
import { CompartidoModule } from '../compartido/compartido.module';


@NgModule({
  declarations: [
    CompraLayoutPaginaComponent,
    CompraPickupPaginaComponent,
    CompraPagoPaginaComponent,
    ResumenCompraComponent,

  ],
  imports: [
    CommonModule,
    CompraRoutingModule,
    CompartidoModule,
  ]
})
export class CompraModule { }
