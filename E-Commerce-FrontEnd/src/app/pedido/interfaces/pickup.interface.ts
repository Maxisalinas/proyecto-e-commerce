export interface PickUp {

        id: number,
        nombre: string,
        direccion: string,
        horario: string,
        img?: string;
        position: Position,
      
}

export interface Position {
    lat: number;
    lng: number;
}