import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { CompraLayoutPaginaComponent } from './paginas/compra-layout-pagina/compra-layout-pagina.component';
import { CompraPickupPaginaComponent } from './paginas/compra-pickup-pagina/compra-pickup-pagina.component';
import { CompraPagoPaginaComponent } from './paginas/compra-pago-pagina/compra-pago-pagina.component';

const routes: Routes = [ 
    {
        path: '',
        component: CompraLayoutPaginaComponent,
        children: [
            {
                path: 'pickup',
                component: CompraPickupPaginaComponent,
            },
            {
                path: 'pago',
                component: CompraPagoPaginaComponent,
            },

        ]
    }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CompraRoutingModule { }
