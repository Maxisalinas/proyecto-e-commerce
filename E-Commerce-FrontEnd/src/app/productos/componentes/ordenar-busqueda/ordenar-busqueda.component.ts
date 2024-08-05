import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Producto } from '../../interfaces/producto.interface';

@Component({
  selector: 'app-ordenar-busqueda',
  templateUrl: './ordenar-busqueda.component.html',
  styleUrl: './ordenar-busqueda.component.css'
})
export class OrdenarBusquedaComponent {

    @Output()
    public ordenarPaginas = new EventEmitter();


    ordenarMenorPrecio() {
        this.ordenarPaginas.emit('menorPrecio')
    }

    ordenarMayorPrecio() {
       this.ordenarPaginas.emit('mayorPrecio')
    }

    ordenarDeAaZ() {
        this.ordenarPaginas.emit('deAaZ')
    }


    ordenarDeZaA() {
        this.ordenarPaginas.emit('deZaA')
    }

}
