using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.CategoriaDTOs.Request
{
    public class EditarCategoriaRequestDto
    {
        [Required(ErrorMessage = "Debe seleccionar una categoría.")]
        public long Id { get; set; }
        [Required(ErrorMessage = "Debe ingresar un nombre.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El nombre debe contener entre 1 y 50 caracteres.")]
        public string Nombre { get; set; } = string.Empty;
    }
}
