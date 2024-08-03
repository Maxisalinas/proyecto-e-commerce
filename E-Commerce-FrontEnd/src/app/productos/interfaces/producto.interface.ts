export interface Producto {
    id:            number;
    nombre:        string;
    modelo:        string;
    idMarca:       number;
    marca:         Marca;
    idCategoria:   number;
    categoria:     Categoria;
    descripcion:   string;
    precio:        number;
    talle:         number;
    idGenero:      number;
    genero:        Genero;
    imageUrl:      string;
    fechaCreacion: Date;
    estado:        boolean;
}

export interface Marca {
    id:            number;
    nombre:        string;
    fechaCreacion: Date;
    logoImageUrl:  string;
    estado:        boolean;
}

export interface Categoria {
    id:            number;
    nombre:        string;
    fechaCreacion: Date;
    estado:        boolean;
    logoImageUrl?: string;
}

export interface Genero {
    id:            number;
    nombre:        string;
    abreviacion:   string;
    sigla:         string;
    fechaCreacion: Date;
    estado:        boolean;
}
