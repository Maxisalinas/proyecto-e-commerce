import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductosLayoutPaginaComponent } from './paginas/productos-layout-pagina/productos-layout-pagina.component';
import { ListaPaginaComponent } from './paginas/lista-pagina/lista-pagina.component';
import { DetalleProductoPaginaComponent } from './paginas/detalle-producto-pagina/detalle-producto-pagina.component';

const routes: Routes = [
    {
        path: '',
        component: ProductosLayoutPaginaComponent,
        children: [
            {
                path: 'lista',
                component: ListaPaginaComponent,
            },
            {
                path: ':id',
                component: DetalleProductoPaginaComponent,
            },
            {
                path: '**',
                redirectTo: 'lista',
            }
            
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class ProductosRoutingModule { }
