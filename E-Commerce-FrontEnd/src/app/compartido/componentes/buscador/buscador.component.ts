import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { FormControl } from '@angular/forms';

import { ServicioBuscador } from '../../servicios/buscador.service';

@Component({
  selector: 'app-buscador',
  templateUrl: './buscador.component.html',
  styleUrl: './buscador.component.css'
})
export class BuscadorComponent {

    public buscador = new FormControl('');

    constructor( 
                 private route: Router,
                 private servicioBuscador: ServicioBuscador
    ) {}

    onBuscar() {
      
        if( !this.buscador.value ) return;

        this.servicioBuscador.enviarCriterio(this.buscador.value);

        this.route.navigateByUrl('/productos/lista');
    }

  


}
