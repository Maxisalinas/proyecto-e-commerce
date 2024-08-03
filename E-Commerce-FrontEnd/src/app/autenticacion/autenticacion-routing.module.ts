import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { AutenticacionLayoutPaginaComponent } from './paginas/autenticacion-layout-pagina/autenticacion-layout-pagina.component';

import { RegistroPaginaComponent } from './paginas/registro-pagina/registro-pagina.component';
import { IngresoPaginaComponent } from './paginas/ingreso-pagina/ingreso-pagina.component';

const routes: Routes = [
    {
        path: '',
        component: AutenticacionLayoutPaginaComponent,
        children: [
            {
                path: 'ingreso',
                component: IngresoPaginaComponent,
            },
            {
                path: 'registro',
                component: RegistroPaginaComponent,
            },
            {
                path: '**',
                redirectTo: 'ingreso',
            },

        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AutenticacionRoutingModule { }
