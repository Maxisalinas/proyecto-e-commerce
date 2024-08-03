import { Component, Input, OnInit } from '@angular/core';
import { Producto } from '../../interfaces/producto.interface';



@Component({
  selector: 'app-card',
  templateUrl: './card.component.html',
  styleUrl: './card.component.css'
})
export class CardComponent implements OnInit {

  
    @Input()
    public producto!: Producto
      
    ngOnInit(): void {
      if ( !this.producto ) throw Error( "La propiedad 'producto' es requerida" );
    }
}
