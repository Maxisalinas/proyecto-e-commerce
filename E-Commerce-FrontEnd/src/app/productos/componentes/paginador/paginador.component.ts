import { Component, EventEmitter, Input, Output } from '@angular/core';



@Component({
  selector: 'app-paginador',
  templateUrl: './paginador.component.html',
  styleUrl: './paginador.component.css'
})
export class PaginadorComponent {

    @Input()
    public criterioBusqueda: string = '';
    @Input()
    public arrayDePaginas: number[] = [];
    public paginaActual: number = 0;
    @Output()
    public emisorIndicePaginaActual: EventEmitter<number> = new EventEmitter();

    constructor( ) {}

    ngOnInit(): void {}

    onClickPaginadorItem( numeroPagina: number ) {
      
        if(this.paginaActual != numeroPagina) {
          this.paginaActual = numeroPagina;
          this.enviarPaginaActual();
        }
            
    }

    enviarPaginaActual() {
      this.emisorIndicePaginaActual.emit(this.paginaActual)
    }





  }
