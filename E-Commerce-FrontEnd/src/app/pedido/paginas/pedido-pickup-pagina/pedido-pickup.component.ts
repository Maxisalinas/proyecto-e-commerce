import { Component, ElementRef, OnInit, ViewChild, ViewChildren } from '@angular/core';

import { environments } from '../../../enviroments/environments';
import { ServicioPickUps } from '../../servicios/pickup.service';
import { PickUp } from '../../interfaces/pickup.interface';


declare var google: any;


@Component({
  selector: 'app-pedido-pickup',
  templateUrl: './pedido-pickup.component.html',
  styleUrl: './pedido-pickup.component.css'
})
export class PedidoPickupComponent implements OnInit {

    @ViewChild('acordionCards')
    acordion!: ElementRef<HTMLDivElement>
    
    private GOOGLE_MAPS_API_KEY = environments.GOOGLE_MAPS_KEY;

    public pickups: PickUp[] = [
        { 
            id: 1,
            nombre: 'Av. Colón',
            direccion: 'Av. Colón 4551',
            horario: '9am - 8pm',
            img: 'https://adgoat-strapi-images-prod.s3.amazonaws.com/store_Logo_6143_aecbaa5dbf.png',
            position: { lat: -31.396573, lng: -64.239258 },
        },
        { 
            id: 2,
            nombre: 'Centro',
            direccion: '9 de Julio 147',
            horario: '9am - 7:30pm',
            img: 'https://adgoat-strapi-images-prod.s3.amazonaws.com/store_Logo_6143_aecbaa5dbf.png',
            position: { lat: -31.414553, lng: -64.185517 }, 
        },
        { 
            id: 3,
            nombre: 'Centro',
            direccion: 'San Martin 158',
            horario: '9am - 7:30pm',
            img: 'https://adgoat-strapi-images-prod.s3.amazonaws.com/store_Logo_6143_aecbaa5dbf.png',
            position: { lat: -31.414291, lng: -64.183191 },
        },
        { 
            id: 4,
            nombre: 'Shopping Villa Cabrera',
            direccion: 'José de Goyechea 2851',
            horario: '9am - 8pm',
            img: 'https://adgoat-strapi-images-prod.s3.amazonaws.com/store_Logo_6143_aecbaa5dbf.png',
            position: { lat: -31.380576, lng: -64.214496 },
        },
        { 
            id: 5,
            nombre: 'Paseo Libertad Sabatini',
            direccion: 'Av. Sabattini 3250',
            horario: '10am - 10pm',
            img: 'https://adgoat-strapi-images-prod.s3.amazonaws.com/store_Logo_6143_aecbaa5dbf.png',
            position: { lat: -31.433635, lng: -64.142174 },
        },
        { 
            id: 6,
            nombre: 'Patio Olmos',
            direccion: 'Av. Vélez Sarsfield 361 Local 352',
            horario: '10am - 10pm',
            img: 'https://adgoat-strapi-images-prod.s3.amazonaws.com/store_Logo_6143_aecbaa5dbf.png',
            position: { lat: -31.419638, lng: -64.188099 }, 
        },
        { 
            id: 7,
            nombre: 'Paseo del Hockey',
            direccion: 'Av. Elias Yofre 1050 Local 234',
            horario: '10am - 10pm',
            img: 'https://adgoat-strapi-images-prod.s3.amazonaws.com/store_Logo_6143_aecbaa5dbf.png',
            position: { lat: -31.450608, lng: -64.180507 },
        },  
        { 
            id: 8,
            nombre: 'Dinosaurio Mall Alto Verde',
            direccion: 'Rodríguez del Busto 4086 Local 38',
            horario: '10am - 9pm',
            img: 'https://adgoat-strapi-images-prod.s3.amazonaws.com/store_Logo_6143_aecbaa5dbf.png',
            position: { lat: -31.367265, lng: -64.218747 },
        },  
        { 
            id: 9,
            nombre: 'Dinosaurio Ruta 20',
            direccion: 'Av. Fuerza Aerea 1700 Local 11',
            horario: '10am - 10pm',
            img: 'https://adgoat-strapi-images-prod.s3.amazonaws.com/store_Logo_6143_aecbaa5dbf.png',
            position: { lat: -31.428899, lng: -64.211568 },
        },  
        { 
            id: 10,
            nombre: 'Nuevo Centro Shopping',
            direccion: 'Av. Duarte Quirós 1400 Local 1193',
            horario: '10am - 10pm',
            img: 'https://adgoat-strapi-images-prod.s3.amazonaws.com/store_Logo_6143_aecbaa5dbf.png',
            position: { lat: -31.412954, lng: -64.204535 },
        },  
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
   
        const map = new Map(document.getElementById('map') as HTMLElement, {
          center: { lat: -31.4201, lng: -64.1888 },
          zoom: 12,
          mapId:'DEMO_MAP_ID',
          minZoom: 12,
          maxZoom: 17,
          restriction: {
            latLngBounds: {
              north: -31.2,
              south: -31.6,
              east: -64,
              west: -64.4,
            }},      
         zoomControl: false,
         mapTypeControl: false,
         fullscreenControl: false,
         rotateControl: false,
          
        });      

        this.pickups.forEach(( pickup ) => {

            const marcadorContenido = document.createElement('div');
            marcadorContenido.innerHTML = `
                <style>
                    .marcador {
                        transition: transform 0.3s ease;    
                    }

                    .marcador:hover{
                        transform: scale(1.05);
                    }

                    .marcador-contenedor {
                        width: 120px;
                        border: 1px solid #212529;
                        background-color: #212529;
                        border-radius: 0.375rem;
                    }

                    .marcador-imagen {
                        object-fit: contain;
                        width: 100%;
                        padding: 4px;
                        background-color: white;
                        border-top-right-radius: 0.375rem;
                        border-top-left-radius: 0.375rem;
                    }

                    .marcador-descripcion {
                        color: white;
                        padding: 0.5rem;
                    }
                        
                    .triangulo {
                        margin: -4px 40px 0 40px;
                        border-left: 20px solid transparent;
                        border-right: 20px solid transparent;
                        border-top: 25px solid #212529;
                    }
            
                </style>

                <div class="marcador">
                    <div class="marcador-contenedor">
                        <img class="marcador-imagen" src="${ pickup.img }">
                        
                        <div class="marcador-descripcion">
                            <span>${ pickup.nombre }</span>
                        </div>
                    </div>

                    <div class="triangulo"><div/>
                </div>
                    
            `

            const marcador = new AdvancedMarkerElement({
                map,
                position: pickup.position,
                title: pickup.nombre,
                content: marcadorContenido,
                gmpClickable: true,
            });

            marcador.addListener("click", () => {

                this.seleccionarPickupConMarcador( marcador.title );

            });

        })
        
    }

    seleccionarPickupConMarcador( pickupSeleccionadoMarcador: string ) {

        const pickup = this.pickups.find( pickup => pickup.nombre === pickupSeleccionadoMarcador );

        this.pickUpSeleccionadoActualmente = pickup;

        
    }

    seleccionarPickUpCard( pickup: PickUp ) {

        this.pickUpSeleccionadoActualmente = pickup;
        
    }


}
    
 


