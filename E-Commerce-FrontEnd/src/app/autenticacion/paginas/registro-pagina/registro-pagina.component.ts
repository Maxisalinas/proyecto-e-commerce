import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { ServicioValidaciones } from '../../../compartido/servicios/validadores.service';
import { ServicioAutenticacion } from '../../servicios/autenticacion.service';
import { ValidadorEmail } from '../../../compartido/servicios/validador-email.service';


@Component({
  selector: 'app-registro-pagina',
  templateUrl: './registro-pagina.component.html',
  styleUrl: './registro-pagina.component.css'
})
export class RegistroPaginaComponent  {

    public fechaDehoy = this.servicioValidaciones.obtenerFechaDeHoy();

    public formularioRegistro: FormGroup = this.formBuilder.group({
        nombre: ['',[ Validators.required]  ],
        apellido: ['', [Validators.required]  ],
        fechaNacimiento: ['', [ Validators.required, this.servicioValidaciones.validarEdad ] ],
        correoElectronico: ['', [ Validators.required, Validators.email ], [this.validadorEmail.validate.bind(this.validadorEmail)]  ],
        password: [ '',  [ Validators.required, Validators.minLength(8), Validators.maxLength(20), Validators.pattern(this.servicioValidaciones.patronPassword) ] ],
        password2: ['', [ Validators.required ] ]
    }, {
        validators: [ this.servicioValidaciones.losCamposCoinciden('password', 'password2'),]
    }); 

    constructor( 
                 private formBuilder: FormBuilder,
                 private servicioValidaciones: ServicioValidaciones,    
                 private validadorEmail: ValidadorEmail,
                 private servicioAutenticacion: ServicioAutenticacion,
                 
    ) {}
    
    elCampoEsValido ( campo: string ) {
        
        return this.servicioValidaciones.elCampoEsValido( this.formularioRegistro, campo );

    }

    obtenerErrorDeCampo( campo: string ): string | null { 
        
        return this.servicioValidaciones.obtenerErrorDeCampo( this.formularioRegistro, campo)
    }

    registrarse() {


        const datosRegistro = this.formularioRegistro.value;

        this.servicioAutenticacion.registrarse( datosRegistro )
            .subscribe( response => {

                console.log(response) });

    }

}
