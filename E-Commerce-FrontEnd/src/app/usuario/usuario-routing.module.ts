import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { UsuarioLayoutPaginaComponent } from './paginas/usuario-layout-pagina/usuario-layout-pagina.component';
import { HistorialComprasPaginasComponent } from './paginas/historial-compras-paginas/historial-compras-paginas.component';
import { ConfiguracionPaginaComponent } from './paginas/configuracion-pagina/configuracion-pagina.component';

const routes: Routes = [ 
    {
      path: ':id',
      component: UsuarioLayoutPaginaComponent,
      children: [
          {
              path: 'configuracion',
              component: ConfiguracionPaginaComponent,
          },
          {
              path: 'historial-compras',
              component: HistorialComprasPaginasComponent,
          },

      ]

    }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class UsuarioRoutingModule { }
