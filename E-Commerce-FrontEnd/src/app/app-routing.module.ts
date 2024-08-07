import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';


import { Error404PaginaComponent } from './compartido/paginas/error404-pagina/error404-pagina.component';
import { GuardAutenticacion } from './autenticacion/guards/autenticacion.guard';


const routes: Routes = [
    
    {
        path: 'autenticacion',
        loadChildren: () => import('./autenticacion/autenticacion.module').then( m => m.AutenticacionModule ),
        canActivate: [ GuardAutenticacion ],
    },
    {
        path: 'home',
        loadChildren: () => import('./home/home.module').then( m => m.HomeModule ),
    },
    {
        path: 'productos',
        loadChildren: () => import('./productos/productos.module').then( m => m.ProductosModule ),
    },
    {
        path: 'pedido',
        loadChildren: () => import('./pedido/pedido.module').then( m => m.PedidoModule ),
    },
    {
        path: 'usuario',
        loadChildren: () => import('./usuario/usuario.module').then( m => m.UsuarioModule ),
    },
    {        
        path: '404',
        component: Error404PaginaComponent,
    },
    {        
        path: '',
        redirectTo: 'home',
        pathMatch: 'full',
    },
    {        
        path: '**',
        redirectTo: '404',
    }

];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule { }
