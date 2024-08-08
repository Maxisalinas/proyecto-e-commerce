import { Component, OnInit } from '@angular/core';
import { ServicioProductos } from '../../servicios/productos.service';
import { ActivatedRoute } from '@angular/router';
import { FormControl, FormGroup, Validators } from '@angular/forms';


import { Producto } from '../../interfaces/producto.interface';
import { ServicioPedido } from '../../../pedido/servicios/pedido.service';
import { ServicioCarrito } from '../../../pedido/servicios/carrito.service';


@Component({
  selector: 'app-detalle-producto-pagina',
  templateUrl: './detalle-producto-pagina.component.html',
  styleUrl: './detalle-producto-pagina.component.css'
})
export class DetalleProductoPaginaComponent implements OnInit {


    public producto!: Producto;
    public productoId!: number;

    public talles: number[] = [ 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45 ]

    public formTalles: FormGroup = new FormGroup( {
        talle: new FormControl( '', [ Validators.required ] )
    });

    constructor( 
                 private servicioProductos: ServicioProductos,
                 private activatedRoute: ActivatedRoute,
                 private servicioPedido: ServicioPedido,
                 private servicioCarrito: ServicioCarrito,
     ) {}

    ngOnInit(): void {

        this.obtenerIdProducto()

        this.servicioProductos.obtenerProductoPorId(this.productoId)
            .subscribe( resultado => {
                this.producto = resultado.producto;
            });
     
    }

    obtenerIdProducto() {
        this.productoId = this.activatedRoute.snapshot.params['id'];
    }


    agregarAlCarrito( talle: number) {

        const productoTomado = {
            id: this.producto.id,
            modelo: this.producto.modelo,
            precio: this.producto.precio,
            talle: talle,
            img: this.producto.imageUrl,
        }

        // console.log( productoTomado )
        this.servicioCarrito.agregarProducto( productoTomado );
    }
}
