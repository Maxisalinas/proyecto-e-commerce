import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { Error404PaginaComponent } from './paginas/error404-pagina/error404-pagina.component';
import { NavbarComponent } from './componentes/navbar/navbar.component';
import { FooterComponent } from './componentes/footer/footer.component';
import { BuscadorComponent } from './componentes/buscador/buscador.component';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterLink, RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    NavbarComponent,
    BuscadorComponent,
    FooterComponent,
    Error404PaginaComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    RouterModule,

  ],
  exports: [
    NavbarComponent,
    BuscadorComponent,
    FooterComponent,
    Error404PaginaComponent,
  ],
})
export class CompartidoModule { }
