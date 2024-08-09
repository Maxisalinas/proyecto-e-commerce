import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ServicioValidaciones } from '../../../compartido/servicios/validaciones.service';

@Component({
    selector: 'app-restablecer-password',
    templateUrl: './restablecer-password.component.html',
    styleUrl: './restablecer-password.component.css'
})
export class RestablecerPasswordComponent {

    public formRestablecerPassword: FormGroup = this.formBuilder.group({
        password: ['', [Validators.required, Validators.minLength(8), Validators.maxLength(20), Validators.pattern(this.servicioValidaciones.patronPassword)]],
        password2: ['', [Validators.required]]
    }, {
        validators: [this.servicioValidaciones.losCamposCoinciden('password', 'password2'),]
    });


    constructor(private formBuilder: FormBuilder,
        private servicioValidaciones: ServicioValidaciones,
    ) { }


    elCampoEsValido(campo: string) {

        return this.servicioValidaciones.elCampoEsValido(this.formRestablecerPassword, campo);
    }

    obtenerErrorDeCampo(campo: string): string | null {

        return this.servicioValidaciones.obtenerErrorDeCampo(this.formRestablecerPassword, campo)
    }


}
