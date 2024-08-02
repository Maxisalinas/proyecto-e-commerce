using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Comun.Entidades
{
    public class Rol : EntidadBase
    {
        [Required(ErrorMessage = "Debe ingresar un nombre.")]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "El nombre no puede contener más de 50 caracteres.")]
        public string Nombre { get; set; }
    }
}
