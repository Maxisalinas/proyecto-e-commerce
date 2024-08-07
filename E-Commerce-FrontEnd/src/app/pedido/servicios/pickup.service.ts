import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { PickUp } from '../interfaces/pickup.interface';
import { Observable } from 'rxjs';


@Injectable({providedIn: 'root'})
export class ServicioPickUps {






    constructor( private httpClient: HttpClient ) { }


    obtenerPickUps(): Observable<PickUp[]> {
        return this.httpClient.get<PickUp[]>('')
    } 








    
}