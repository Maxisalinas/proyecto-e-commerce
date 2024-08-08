import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { ServicioAutenticacion } from '../../servicios/autenticacion.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-ingreso-pagina',
  templateUrl: './ingreso-pagina.component.html',
  styleUrl: './ingreso-pagina.component.css'
})
export class IngresoPaginaComponent {

    public formularioIngreso: FormGroup = new FormGroup({
        correoElectronico: new FormControl('', [ Validators.required ] ),
        password: new FormControl('', [ Validators.required ] ),
    })


    constructor( private servicioAutenticacion: ServicioAutenticacion ) {}


    
    iniciarSesion() { 

        const credenciales = this.formularioIngreso.value;

        this.servicioAutenticacion.iniciarSesion(credenciales)
            .subscribe();

    }



}

