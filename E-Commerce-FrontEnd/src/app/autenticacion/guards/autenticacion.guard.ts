import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot } from '@angular/router';
import { Observable } from 'rxjs';
import { ServicioAutenticacion } from '../servicios/autenticacion.service';



@Injectable({providedIn: 'root'})
export class GuardAutenticacion implements CanActivate {


    constructor( private servicioAutenticacion: ServicioAutenticacion ) { }


    canActivate(): boolean | Observable<boolean> {
        
        if(this.servicioAutenticacion.verificarAutenticacion()) return false;
        return true;
    }
    
}