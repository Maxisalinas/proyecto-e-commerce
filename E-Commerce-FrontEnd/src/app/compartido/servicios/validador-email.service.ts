import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AbstractControl, AsyncValidator, ValidationErrors } from '@angular/forms';
import { delay, map, Observable, of, tap } from 'rxjs';

import { environments } from '../../enviroments/environments';
import { ValidarEmailResponse } from '../interfaces/validar-email-response';

@Injectable({providedIn: 'root'})
export class ValidadorEmail implements AsyncValidator {

    public urlBase = environments.API_BASE_URL;
    public validarEmailResponse?: ValidarEmailResponse;
 
    constructor( private httpClient: HttpClient ) {}


    validate( control: AbstractControl ): Observable<ValidationErrors | null > {

        const email = control.value;

        return this.httpClient.get<ValidarEmailResponse>( `${ this.urlBase }/Auth/ValidarDisponibilidadEmail?email=${ email }`)
            .pipe(
                delay(600),
                map(response => response.disponible ? null : { emailEnUso: true })
                
            )
    
    }
    
}