import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { BehaviorSubject, map, Observable, tap  } from 'rxjs';

import { environments } from '../../enviroments/environments';
import { ServicioLocalStorage } from './token.service';
import { CredencialesIngreso } from '../interfaces/credenciales-ingreso.interface';
import { LoginResponse } from '../interfaces/ingreso-response.interface';
import { Router } from '@angular/router';
import { DatosRegistro } from '../interfaces/datos-registro-interface';


@Injectable({providedIn: 'root'})
export class ServicioAutenticacion {

    private urlBase = environments.API_BASE_URL;


    private logeado = new BehaviorSubject(false);
    public logeado$ = this.logeado.asObservable();


    constructor( private httpClient: HttpClient,
                 private servicioLocalStorage: ServicioLocalStorage,
                 private router: Router,
    ) { }


    iniciarSesion( credenciales: CredencialesIngreso ):Observable<boolean> {

        return this.httpClient.post<LoginResponse>(`${ this.urlBase }/Auth/Login`, credenciales)
            .pipe(
                tap( response => {

                    if (response.authResult.statusCode === 200) {
                       this.servicioLocalStorage.guardarElementoLocalStorage('tokenAutenticacion', response.authResult.accessToken );
                     
                       this.logeado.next(true);
                       this.router.navigate(['/home']);
                    }
                }),
                map( () => true )
            );  
    } 

    cerrarSesion():void {
        this.servicioLocalStorage.limpiarLocalStorage();
        this.logeado.next(false);
    }

    verificarAutenticacion(): boolean {
        if(this.servicioLocalStorage.obtenerTokenLocalStorage('tokenAutenticacion')) {

            this.logeado.next(true);
            return true;
        }

        this.logeado.next(false);
        return false;
    }
    

    registrarse( datosRegistro: DatosRegistro ) {

        
        const body = { idRol: 4, ...datosRegistro}

    

        return this.httpClient.post( `${ this.urlBase }/Auth/Registro`, body);

    }

    
}