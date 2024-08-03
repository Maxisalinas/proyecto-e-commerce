import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeLayoutPaginaComponent } from './paginas/home-layout-pagina/home-layout-pagina.component';

const routes: Routes = [
  {
      path: '',
      component: HomeLayoutPaginaComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class HomeRoutingModule { }
