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
    

    obtenerProductos( valor:string ): Observable<ProductosResponse> {

        const body = {
            "criterioBusqueda": valor,
            "pageSize": 12,
            "pageNumber": 1
        }

        return this.httpClient.post<ProductosResponse>( `${ this.urlBase }/Producto/Buscador`, body )
    }

    obtenerProductoPorId( id: number ) {

        const body = {};

        return this.httpClient.post<ProductoResponse>( `${ this.urlBase }/Producto/ObtenerUnoPorId/${id}`, body);
    }



}       