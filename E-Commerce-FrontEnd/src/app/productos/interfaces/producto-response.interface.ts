import { Producto } from "./producto.interface";

export interface ProductoResponse {
    producto:   Producto;
    statusCode: number;
    mensajes:   Mensaje[];
}

export interface Mensaje {
    message: string;
    class:   string;
    type:    string;
}
