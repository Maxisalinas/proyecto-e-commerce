using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Comun.Entidades
{
    public class Producto : EntidadBase
    {
        [Required(ErrorMessage = "Debe ingresar un nombre.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El nombre debe contener entre 1 y 100 caracteres.")]
        public string Nombre { get; set; } = string.Empty;
        [Required(ErrorMessage = "Debe ingresar un modelo.")]
        [StringLength(100, MinimumLength = 1, ErrorMessage = "El modelo debe contener entre 1 y 100 caracteres.")]
        public string Modelo { get; set; } = string.Empty;
        [Required(ErrorMessage = "Debe seleccionar una marca.")]
        [ForeignKey(nameof(Marca))]
        public long IdMarca { get; set; }
        public Marca Marca { get; set; }
        [Required(ErrorMessage = "Debe seleccionar una categoría.")]
        [ForeignKey(nameof(Categoria))]
        public long IdCategoria { get; set; }
        public Categoria Categoria { get; set; }
        [Required(ErrorMessage = "Debe ingresar una descripción.")]
        [StringLength(800, MinimumLength = 1, ErrorMessage = "La descripción no puede contener más de 800 caracteres.")]
        public string Descripcion { get; set; } = string.Empty;
        [Required(ErrorMessage = "Debe ingresar un precio.")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "Debe ingresar un talle.")]
        [Range(30, 45, ErrorMessage = "El talle no puede ser menor a 30 ni mayor a 45.")]
        public int Talle { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un género.")]
        [ForeignKey(nameof(Genero))]
        public long IdGenero { get; set; }
        public Genero Genero { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
    }
}
