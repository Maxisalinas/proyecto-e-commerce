import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';

import { ValidadorEmail } from '../../../compartido/servicios/validador-email.service';
import { ServicioValidaciones } from '../../../compartido/servicios/validaciones.service';

@Component({
  selector: 'app-recuperar-password',
  templateUrl: './recuperar-password.component.html',
  styleUrl: './recuperar-password.component.css'
})
export class RecuperarPasswordComponent {

    public formRecuperarPassword = new FormGroup( {
      correoElectronico: new FormControl('', [ Validators.required, Validators.email ], [this.validadorEmail.usuarioExistente.bind(this.validadorEmail)] )
    })
   
    constructor( private servicioValidaciones: ServicioValidaciones,
                 private validadorEmail: ValidadorEmail ) 
    {}


    elCampoEsValido ( campo: string ) {
        
      return this.servicioValidaciones.elCampoEsValido( this.formRecuperarPassword, campo );

  }

  obtenerErrorDeCampo( campo: string ): string | null { 
      
      return this.servicioValidaciones.obtenerErrorDeCampo( this.formRecuperarPassword, campo)
  }






}
