export interface PickUp {

        id: number,
        nombre: string,
        direccion: string,
        horario: string,
        logo?: string;
        position: Position,
      
}

export interface Position {
    lat: number;
    lng: number;
}