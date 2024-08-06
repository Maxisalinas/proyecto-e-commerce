import { Component, OnInit } from '@angular/core';

import { environments } from '../../../enviroments/environments';
import { ServicioPickUps } from '../../servicios/pickup.service';
import { PickUp } from '../../interfaces/pickup.interface';


declare var google: any;


@Component({
  selector: 'app-compra-pickup-pagina',
  templateUrl: './compra-pickup-pagina.component.html',
  styleUrl: './compra-pickup-pagina.component.css'
})
export class CompraPickupPaginaComponent implements OnInit {

    private GOOGLE_MAPS_API_KEY = environments.GOOGLE_MAPS_KEY;

    public pickups: PickUp[] = [
        { 
            id: 1,
            nombre: 'Adidas Patio Olmos',
            direccion: 'Av. Vélez Sarsfield 361',
            horario: '10am - 10pm',
            position: { lat: -31.4198, lng: -64.1882},
        },
        { 
            id: 2,
            nombre: 'Nike Nuevo Centro Shopping',
            direccion: 'Av. Duarte Quirós 1400',
            horario: '10am - 10pm',
            position: { lat: -31.4128, lng: -64.2045 },
        }
    ];

    public pickUpSeleccionadoActualmente?: PickUp;


    constructor( private servicioPickUps: ServicioPickUps ) {}
    
    ngOnInit() {
        // this.servicioPickUps.obtenerPickUps()
        //   .subscribe( response => {
        //       this.pickups = response;
        //   });

        this.cargarScriptGoogleMaps();
    }

    private cargarScriptGoogleMaps() {
        const script = document.createElement('script');
        script.src = `https://maps.googleapis.com/maps/api/js?key=${this.GOOGLE_MAPS_API_KEY}`;
        script.async = true;
        script.defer = true;
        script.onload = () => this.inicializarMapa();
        document.body.appendChild(script);
    }

    async inicializarMapa(): Promise<void> {

        const { Map } = await google.maps.importLibrary("maps");
        const { AdvancedMarkerElement } = await google.maps.importLibrary("marker");
        const { PinElement } = await google.maps.importLibrary("marker");

        const map = new Map(document.getElementById('map') as HTMLElement, {
          center: { lat: -31.4201, lng: -64.1888 },
          zoom: 12,
          mapId:'DEMO_MAP_ID'
        });      

        this.pickups.forEach(( pickup ) => {

            const pin = new PinElement({
                scale: 1.2,
                background: "#red",
                glyphColor: "white",
                // glyph:
            });

            const marcador = new AdvancedMarkerElement({
                map,
                position: pickup.position,
                title: pickup.nombre,
                content: pin.element,
                gmpClickable: true,
            });

            marcador.addListener("click", () => {

                this.seleccionarPickupConMarcador( marcador.title );

            });

            marcador.classList.add("marcador");
            marcador.classList.add("marcador:hover");
            marcador.style.marcador= "2px solid blue"

        })
        
    }

    seleccionarPickupConMarcador( pickupSeleccionadoMarcador: string ) {

        const pickup = this.pickups.find( pickup => pickup.nombre === pickupSeleccionadoMarcador );

        this.pickUpSeleccionadoActualmente = pickup;
        

    }

    seleccionarPickUpCard( pickup: PickUp ) {

        this.pickUpSeleccionadoActualmente = pickup;

    

    }

      // const logoTiendaNike = document.createElement("img");
      // logoTiendaNike.src = "/assets/logoTiendaNike.png";
      // logoTiendaNike.style.height = "80px";
      // logoTiendaNike.style.height = "80px";



}
    
 


