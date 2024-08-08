import { PickUp } from "./pickup.interface";

export interface Pedido {

    productos: ProductoTomado[],
    pickup: PickUp

}

export interface ProductoTomado {
    id: number,
    modelo: string;
    precio: number,
    img: string,
    talle: number,

}