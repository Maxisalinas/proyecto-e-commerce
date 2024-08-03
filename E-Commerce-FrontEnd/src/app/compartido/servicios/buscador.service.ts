
import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({providedIn: 'root'})
export class ServicioBuscador {
    
    private criterioBusquedaSubject = new BehaviorSubject<string>('');
    public criterioBusqueda$ = this.criterioBusquedaSubject.asObservable();

    enviarCriterio(criterioBusqueda: string) {
        this.criterioBusquedaSubject.next(criterioBusqueda);
    }

    
}