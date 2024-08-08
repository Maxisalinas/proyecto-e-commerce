import { Component, OnInit } from '@angular/core';

import { ServicioCarrito } from '../../servicios/carrito.service';
import { ProductoTomado } from '../../interfaces/pedido.interface';
import { PickUp } from '../../interfaces/pickup.interface';



@Component({
  selector: 'app-resumen-compra',
  templateUrl: './resumen-compra.component.html',
  styleUrl: './resumen-compra.component.css'
})
export class ResumenCompraComponent implements OnInit {

    public productosTomados: ProductoTomado[] = [];
    public precioTotal: number = 0;


    constructor ( private servicioCarrito: ServicioCarrito ) {}

    ngOnInit(): void {
        this.productosTomados = this.servicioCarrito.getCarrito();
        this.precioTotal = this.servicioCarrito.obtenerPrecioTotal();
    }
    


}
