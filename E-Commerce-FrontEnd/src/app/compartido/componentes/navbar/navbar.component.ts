import { Component, OnChanges, OnDestroy, OnInit, SimpleChanges } from '@angular/core';

import { ServicioAutenticacion } from '../../../autenticacion/servicios/autenticacion.service';
import { Subscription } from 'rxjs';
import { ActivatedRoute, NavigationEnd, UrlSegment } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent implements OnInit, OnDestroy {

  public logeado!: boolean;
  public suscripcion!: Subscription;



  constructor ( private servicioAutenticacion: ServicioAutenticacion,
                private actiavtedRoute: ActivatedRoute,
   ) {}


  ngOnInit(): void {
      this.suscripcion = this.servicioAutenticacion.logeado$.subscribe( valor => this.logeado = valor );
  }


  
  cerrarSesion() {
      this.servicioAutenticacion.cerrarSesion()

  }

  ngOnDestroy(): void {
      this.suscripcion.unsubscribe();
  }

}
