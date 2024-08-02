using E_Commerce_Comun.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Commerce_Negocio.DTOs.CategoriaDTOs;
using E_Commerce_Negocio.DTOs.MarcaDTOs;
using E_Commerce_Negocio.DTOs.GeneroDTOs;

namespace E_Commerce_Negocio.DTOs.ProductoDTOs
{
    public class ProductoDto
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Modelo { get; set; }
        public long IdMarca { get; set; }
        public MarcaDto Marca { get; set; }
        public long IdCategoria { get; set; }
        public CategoriaDto Categoria { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public int Talle { get; set; }
        public long IdGenero { get; set; }
        public GeneroDto Genero { get; set; }
        public string ImageUrl { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }

        public ProductoDto()
        {
            Id = 0;
            Nombre = string.Empty;
            Modelo = string.Empty;
            IdMarca = 0;
            Marca = new MarcaDto();
            IdCategoria = 0;
            Categoria = new CategoriaDto();
            Descripcion = string.Empty;
            Precio = 0;
            Talle = 0;
            IdGenero = 0;
            Genero = new GeneroDto();
            ImageUrl = string.Empty;
            FechaCreacion = DateTime.MinValue;
            Estado = false;
        }
    }
}
