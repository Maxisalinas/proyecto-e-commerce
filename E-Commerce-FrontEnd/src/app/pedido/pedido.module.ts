import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { PedidoRoutingModule } from './pedido-routing.module';
import { CompartidoModule } from '../compartido/compartido.module';
import { PedidoLayoutComponent } from './paginas/pedido-layout/pedido-layout.component';
import { PedidoPagoComponent } from './paginas/pedido-pago-pagina/pedido-pago.component';
import { PedidoPickupComponent } from './paginas/pedido-pickup-pagina/pedido-pickup.component';
import { ResumenCompraComponent } from './componentes/resumen-compra/resumen-compra.component';

@NgModule({
  declarations: [
    PedidoLayoutComponent,
    PedidoPickupComponent,
    PedidoPagoComponent,
    ResumenCompraComponent,

  ],
  imports: [
    CommonModule,
    PedidoRoutingModule,
    CompartidoModule,
  ]
})
export class PedidoModule { }
