using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Comun.Entidades
{
    public class Marca : EntidadBase
    {
        [Required(ErrorMessage = "Debe ingresar un nombre.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El nombre no puede contener más de 50 caracteres.")]
        public string Nombre { get; set; } = string.Empty;
        public string LogoImageUrl { get; set; } = string.Empty;
    }
}
