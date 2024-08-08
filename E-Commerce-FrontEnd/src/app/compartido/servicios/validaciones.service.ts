import { Injectable } from '@angular/core';
import { AbstractControl, FormGroup, ValidationErrors } from '@angular/forms';

import { environments } from '../../enviroments/environments';


@Injectable({providedIn: 'root'})
export class ServicioValidaciones {

    urlBase = environments.API_BASE_URL;

    public patronPassword = new RegExp(/^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[^\da-zA-Z]).*$/);

    constructor( ) { }


    elCampoEsValido ( formulario: FormGroup, campo: string ): boolean | null {
        
        return  formulario.controls[ campo ].errors  && formulario.controls[ campo ].touched
                || 
                formulario.controls[ campo ].errors && formulario.controls[ campo ].dirty ;
    
    }
    
    obtenerErrorDeCampo( formulario: FormGroup, campo: string ): string | null {
        
        if( !formulario.controls[ campo ] ) return null;

        const errores = formulario.controls[ campo ].errors || {};

        for( const clave of Object.keys( errores ) ) {
            switch( clave ) {
                case 'required':
                    return 'Este campo es requerido.'
                case 'email' :
                    return 'Inserte un correo electrónico valido.'
                case 'pattern':
                    return 'La contraseña debe contener al menos una mayúscula, una minúscula, un número y un simbolo.'
                case 'minlength':
                    const minLength = errores['minlength'].requiredLength;
                    return `El campo debe contener al menos ${minLength} caracteres.`;
                case 'maxlength':
                    const maxLength = errores['maxlength'].requiredLength;
                    return `El campo debe contener al menos ${maxLength} caracteres.`;
                case 'losCamposNoCoinciden':
                    return 'Las contraseñas deben ser iguales.'
                case 'esMenorDeEdad':
                    return 'Debes ser mayor de edad para registrarte.'
                case 'emailEnUso':
                    return 'Esta dirección de correo electrónico ya está en uso.'
                case 'usuarioNoExiste':
                    return 'El correo que proporcionó no corresponde a ningún usuario registrado.'
            }
        }

        return '';
    }

    losCamposCoinciden( campo1: string, campo2: string) {

        return ( formulario: FormGroup ): ValidationErrors | null => {
            const valorCampo1 = formulario.controls[campo1]?.value;
            const valorCampo2 = formulario.controls[campo2]?.value;

            if( valorCampo1 !== valorCampo2 ) {
                formulario.controls[campo2]?.setErrors({ losCamposNoCoinciden: true });
                return { losCamposNoCoinciden: true };
            }
            
            formulario.controls[campo2]?.setErrors(null);
            return null;
        }

    }

    obtenerFechaDeHoy(): string {

        const fechaDeHoy = new Date();
        const año = fechaDeHoy.getFullYear();
        const mes = String(fechaDeHoy.getMonth() + 1).padStart(2, '0'); 
        const día = String(fechaDeHoy.getDate()).padStart(2, '0');
        
        const fechaFormateada = `${año}-${mes}-${día}`;
        
        return fechaFormateada;
    }

    validarEdad( control: AbstractControl ): ValidationErrors | null {

        const fechaNacimiento = new Date(control.value);
        const fechaDeHoy = new Date();
        const edad = fechaDeHoy.getFullYear() - fechaNacimiento.getFullYear();

        if( edad < 18) return { esMenorDeEdad: true };

        return null;
    
    }




}


