import { Component, HostListener, OnInit } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css'
})

export class SidebarComponent implements OnInit {

  esResolucionGrande: boolean = false;

  constructor() {}

    ngOnInit() {
        this.comprobarResolucion();
    }

    @HostListener('window:resize')
    onReajustarSidebar() {
        this.comprobarResolucion();
    }

    comprobarResolucion() {
        this.esResolucionGrande = window.innerWidth > 768; // Por ejemplo, 768px como punto de corte
    }
}