import { Injectable } from '@angular/core';

@Injectable({providedIn: 'root'})
export class ServicioToken {

    constructor() {}

    guardarElementoLocalStorage( clave: string, valor: string) {
        localStorage.setItem( clave, valor );
    }

    obtenerElementoLocalStorage( clave: string ):boolean | undefined  {
        if(localStorage.getItem(clave)) return true;
        return
    }

    eliminarElementoLocalStorage( clave: string ){
        localStorage.removeItem( clave );
    }

    limpiarLocalStorage(){
        localStorage.clear();
    }
    
}