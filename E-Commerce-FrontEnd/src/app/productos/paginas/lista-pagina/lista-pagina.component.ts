import { Component, OnDestroy, OnInit } from '@angular/core';

import { Subscription, switchMap, tap } from 'rxjs';

import { ServicioProductos } from '../../servicios/productos.service';
import { ServicioBuscador } from '../../../compartido/servicios/buscador.service';
import { Producto } from '../../interfaces/producto.interface';

@Component({
  selector: 'app-lista-pagina',
  templateUrl: './lista-pagina.component.html',
  styleUrl: './lista-pagina.component.css'
})
export class ListaPaginaComponent implements OnInit, OnDestroy {

    public criterioBusqueda: string = "";
    public suscrpcionCriterioBusqueda!: Subscription;

    public productos: Producto[] = [];
    public totalPaginas: number[] = []

    constructor( 
                 private servicioProductos: ServicioProductos,
                 private servicioBuscador: ServicioBuscador,
    ) {}


    ngOnInit(): void {

      this.suscrpcionCriterioBusqueda = this.servicioBuscador.criterioBusqueda$
        .pipe(
            switchMap( criterio => {        
               return this.servicioProductos.obtenerProductos(criterio);
            }),
            tap( resultado => {            
              this.totalPaginas = this.servicioProductos.crearArrayDePaginas(resultado.totalPaginas);
            })
        )
        .subscribe( resultado => {      
            this.productos = resultado.productos;
        });
    }


    obtenerProductosDesdePaginador( indice: number ) {

      const numeroPagina = indice;

      this.servicioBuscador.criterioBusqueda$
        .pipe(
            switchMap( criterio => {        
               return this.servicioProductos.obtenerProductos(criterio, numeroPagina );
            }),
            tap( resultado => {   
              this.totalPaginas = this.servicioProductos.crearArrayDePaginas(resultado.totalPaginas);
            })
        )
        .subscribe( resultado => {  
            this.productos = resultado.productos;
        });
    }
    

    ordenarListadoProductos( criterioOrdenamiento: string ) {

        if( criterioOrdenamiento == 'menorPrecio') {

        }

        if( criterioOrdenamiento == 'mayorPrecio') {
          
        }

        if( criterioOrdenamiento == 'deZaA') {
          
        }

        if( criterioOrdenamiento == 'menorPrecio') {
          
        }
    }   










    
    ngOnDestroy(): void {
        this.suscrpcionCriterioBusqueda.unsubscribe();
    }

  }