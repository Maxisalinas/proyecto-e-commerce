import { Component, OnDestroy, OnInit } from '@angular/core';
import { Subscription } from 'rxjs';

import { ServicioCarrito } from '../../servicios/carrito.service';
import { ProductoTomado } from '../../interfaces/pedido.interface';


@Component({
  selector: 'app-carrito',
  templateUrl: './carrito.component.html',
  styleUrl: './carrito.component.css'
})
export class CarritoComponent implements OnInit, OnDestroy {

    public carrito: ProductoTomado[] = [];
    public precioTotal: number = 0;
    private subscripcion = new Subscription;


    constructor( private servicioCarrito: ServicioCarrito ) {} 

    ngOnInit(): void {

        this.subscripcion = this.servicioCarrito.carrito$.subscribe( carrito => {
            this.carrito = carrito;
            this.actualizarTotalPrecio();
        })
    
    
    }

    private actualizarTotalPrecio(): void {
        this.precioTotal = this.servicioCarrito.obtenerPrecioTotal();
    }

    eliminarProducto( indice: number ): void {
        this.servicioCarrito.eliminarProducto( indice );
    }


    ngOnDestroy(): void {
       this.subscripcion.unsubscribe();
    }

   

}
