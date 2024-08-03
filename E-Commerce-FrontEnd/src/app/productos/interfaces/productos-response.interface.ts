import { Producto } from "./producto.interface";

export interface ProductosResponse {
    productos:           Producto[];
    pagina:              number;
    resultadosPorPagina: number;
    totalPaginas:        number;
    totalResultados:     number;
    statusCode:          number;
    mensajes:            Mensaje[];
}

export interface Mensaje {
    message: string;
    class:   string;
    type:    string;
}
