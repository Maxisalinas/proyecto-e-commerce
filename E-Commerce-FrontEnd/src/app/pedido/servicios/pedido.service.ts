import { Injectable } from '@angular/core';
import { ServicioCarrito } from './carrito.service';
import { BehaviorSubject } from 'rxjs';
import { PickUp } from '../interfaces/pickup.interface';
import { Pedido } from '../interfaces/pedido.interface';

@Injectable({providedIn: 'root'})
export class ServicioPedido {


    private pedido!: Pedido;


    constructor( private servicioCarrito: ServicioCarrito ) {}


    generarPedido( pickup: PickUp ) {

        const productos = this.servicioCarrito.getCarrito();

        this.pedido = { productos, pickup };

        console.log(this.pedido);


    }


    
}