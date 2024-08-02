using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Gestores.ProductoG.DTOs.Request
{
    public class EditarProductoRequestDto
    {
        [Required(ErrorMessage = "Debe ingresar un producto.")]
        public int Id { get; set; }
        [Required(ErrorMessage = "Debe seleccionar una marca.")]
        public int IdMarca { get; set; }
        [Required(ErrorMessage = "Debe ingresar un modelo.")]
        [StringLength(100, ErrorMessage = "El modelo no puede contener más de 100 caracteres.")]
        public string Modelo { get; set; }
        [Required(ErrorMessage = "Debe seleccionar una categoría.")]
        public int IdCategoria { get; set; }
        [Required(ErrorMessage = "Debe ingresar una descripción.")]
        [StringLength(500, ErrorMessage = "La descripción no puede contener más de 500 caracteres.")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Debe ingresar un precio.")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "Debe ingresar un talle.")]
        [Range(30, 45, ErrorMessage = "El talle no puede ser menor a 30 ni mayor a 45.")]
        public int Talle { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un género.")]
        public int IdGenero { get; set; }
        public string ImageUrl { get; set; }
    }
}
