import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProductosRoutingModule } from './productos-routing.module';
import { CompartidoModule } from "../compartido/compartido.module";

import { ListaPaginaComponent } from './paginas/lista-pagina/lista-pagina.component';
import { ProductosLayoutPaginaComponent } from './paginas/productos-layout-pagina/productos-layout-pagina.component';
import { DetalleProductoPaginaComponent } from './paginas/detalle-producto-pagina/detalle-producto-pagina.component';
import { SidebarComponent } from './componentes/sidebar/sidebar.component';
import { CardComponent } from './componentes/card/card.component';
import { OrdenarBusquedaComponent } from './componentes/ordenar-busqueda/ordenar-busqueda.component';
import { PaginadorComponent } from './componentes/paginador/paginador.component';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    ListaPaginaComponent,
    ProductosLayoutPaginaComponent,
    DetalleProductoPaginaComponent,
    SidebarComponent,
    CardComponent,
    OrdenarBusquedaComponent,
    PaginadorComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    CompartidoModule,
    ProductosRoutingModule,
  ],
  exports: [
  ]
})
export class ProductosModule { }
