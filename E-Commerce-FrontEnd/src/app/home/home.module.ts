import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { HomeRoutingModule } from './home-routing.module';
import { HomeLayoutPaginaComponent } from './paginas/home-layout-pagina/home-layout-pagina.component';
import { CompartidoModule } from '../compartido/compartido.module';


@NgModule({
  declarations: [
    HomeLayoutPaginaComponent
  ],
  imports: [
    CommonModule,

    HomeRoutingModule,
    CompartidoModule,
  ]
})
export class HomeModule { }
