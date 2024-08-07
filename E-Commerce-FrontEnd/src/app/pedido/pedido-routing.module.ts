import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { PedidoLayoutComponent } from './paginas/pedido-layout/pedido-layout.component';
import { PedidoPickupComponent } from './paginas/pedido-pickup-pagina/pedido-pickup.component';
import { PedidoPagoComponent } from './paginas/pedido-pago-pagina/pedido-pago.component';

const routes: Routes = [ 
    {
        path: '',
        component: PedidoLayoutComponent,
        children: [
            {
                path: 'pickup',
                component: PedidoPickupComponent,
            },
            {
                path: 'pago',
                component: PedidoPagoComponent,
            },
   

        ]
    }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class PedidoRoutingModule { }
