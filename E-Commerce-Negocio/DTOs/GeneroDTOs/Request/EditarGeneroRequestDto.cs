using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.GeneroDTOs.Request
{
    public class EditarGeneroRequestDto
    {
        [Required(ErrorMessage = "Debe seleccionar un género.")]
        public long Id { get; set; }
        [Required(ErrorMessage = "Debe ingresar un nombre.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El nombre debe contener entre 1 y 50 caracteres.")]
        public string Nombre { get; set; } = string.Empty;
        [Required(ErrorMessage = "Debe ingresar una abreviación.")]
        [StringLength(4, MinimumLength = 1, ErrorMessage = "La abreviación no puede contener más de 4 caracteres.")]
        public string Abreviacion { get; set; } = string.Empty;
        [Required(ErrorMessage = "Debe ingresar una sigla.")]
        [StringLength(1, MinimumLength = 1, ErrorMessage = "La sigla no puede contener más de 1 caracter.")]
        public string Sigla { get; set; } = string.Empty;
    }
}
