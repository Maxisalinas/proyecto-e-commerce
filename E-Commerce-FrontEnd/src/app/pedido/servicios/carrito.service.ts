import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

import { ProductoTomado } from '../interfaces/pedido.interface';


@Injectable({providedIn: 'root'})
export class ServicioCarrito {

        private carrito: ProductoTomado[] = JSON.parse(localStorage.getItem('carrito') || '[]');
        private carritoSubject = new BehaviorSubject<ProductoTomado[]>(this.carrito);
        public carrito$ = this.carritoSubject.asObservable();

        
        constructor() {}

        getCarrito() {
            return this.carrito;
        }
    
        agregarProducto(producto: ProductoTomado) {

            this.carrito.push(producto);
            this.carritoSubject.next(this.carrito);
            this.actualizarLocalStorage();

        }
    
        eliminarProducto(indice: number) {

            this.carrito.splice(indice, 1);
            this.carritoSubject.next(this.carrito);
            this.actualizarLocalStorage();
        }
        
    
        obtenerPrecioTotal() {

           return this.carrito.reduce((acumulador, producto) => acumulador + producto.precio, 0);
        }

          
        private actualizarLocalStorage() {

            localStorage.setItem('carrito', JSON.stringify(this.carrito));

      }
  }