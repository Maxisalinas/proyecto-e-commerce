import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';


import { ProductosResponse } from '../interfaces/productos-response.interface';
import { ProductoResponse } from '../interfaces/producto-response.interface';
import { environments } from '../../enviroments/environments';


@Injectable( { providedIn: 'root' } )
export class ServicioProductos {

    private urlBase = environments.API_BASE_URL;

    constructor( private httpClient: HttpClient ) { }
    

    obtenerProductos( valor:string, numeroPagina?: number ): Observable<ProductosResponse> {

        const body = {
            "criterioBusqueda": valor,
            "pageSize": 12,
            "pageNumber": numeroPagina,
        }

        return this.httpClient.post<ProductosResponse>( `${ this.urlBase }/Producto/Buscador`, body )
    }

    obtenerProductoPorId( id: number ) {

        const body = {};

        return this.httpClient.post<ProductoResponse>( `${ this.urlBase }/Producto/ObtenerUnoPorId/${id}`, body);
    }


    crearArrayDePaginas(totalPaginas: number): number[] {
        if (totalPaginas <= 0) {
          return [];
        }
        
        const arrayDePaginas: number[] = [];
  
        for (let i = 1; i <= totalPaginas; i++) {
          arrayDePaginas.push(i);
        }
        
        return arrayDePaginas;
      }


}       