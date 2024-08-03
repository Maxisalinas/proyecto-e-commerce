import { Component, HostListener, OnInit } from '@angular/core';
import { ServicioProductos } from '../../servicios/productos.service';
import { Producto } from '../../interfaces/producto.interface';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-detalle-producto-pagina',
  templateUrl: './detalle-producto-pagina.component.html',
  styleUrl: './detalle-producto-pagina.component.css'
})
export class DetalleProductoPaginaComponent implements OnInit {


    public producto!: Producto;
    public productoId!: number;

    constructor( private servicioProductos: ServicioProductos,
                 private activatedRoute: ActivatedRoute,
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
}
