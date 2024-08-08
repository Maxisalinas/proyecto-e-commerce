import { Injectable } from '@angular/core';

@Injectable({providedIn: 'root'})
export class ServicioLocalStorage {

    constructor() {}

    guardarElementoLocalStorage( clave: string, valor: any) {
        localStorage.setItem( clave, valor );
    }

    obtenerTokenLocalStorage( clave: string ):boolean | undefined  {
        if(localStorage.getItem( clave )) return true;
        return
    }

    obtenerElementoLocalStorage( clave: string ): string | null {
        return localStorage.getItem( clave );
    } 

    eliminarElementoLocalStorage( clave: string ){
        localStorage.removeItem( clave );
    }

    limpiarLocalStorage(){
        localStorage.clear();
    }
    
}