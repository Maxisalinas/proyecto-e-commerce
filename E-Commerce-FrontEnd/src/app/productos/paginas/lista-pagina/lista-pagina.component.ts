import { Component, OnInit } from '@angular/core';

import { Subscription, switchMap } from 'rxjs';

import { ServicioProductos } from '../../servicios/productos.service';
import { ServicioBuscador } from '../../../compartido/servicios/buscador.service';
import { Producto } from '../../interfaces/producto.interface';

@Component({
  selector: 'app-lista-pagina',
  templateUrl: './lista-pagina.component.html',
  styleUrl: './lista-pagina.component.css'
})
export class ListaPaginaComponent implements OnInit {

    public criterioBusqueda: string = "";
    public productos: Producto[] = [];
    public suscrpcionCriterioBusqueda!: Subscription;

    constructor( 
                 private servicioProductos: ServicioProductos,
                 private servicioBuscador: ServicioBuscador,
    ) {}


    ngOnInit(): void {

      this.suscrpcionCriterioBusqueda = this.servicioBuscador.criterioBusqueda$
        .pipe(
            switchMap( criterio => {
               return this.servicioProductos.obtenerProductos(criterio);
            })
        )
        .subscribe( resultado => {
            this.productos = resultado.productos;
        });
    }

 }