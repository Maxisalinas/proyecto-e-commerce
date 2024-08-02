using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Comun.Entidades
{
    public class Usuario : EntidadBase
    {
        [Required(ErrorMessage = "Debe ingresar un nombre.")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "El nombre no puede contener más de 20 caracteres.")]
        public string Nombre { get; set; } 
        [Required(ErrorMessage = "Debe ingresar un apellido.")]
        [StringLength(20, MinimumLength = 1, ErrorMessage = "El apellido no puede contener más de 20 caracteres.")]
        public string Apellido { get; set; } 
        [Required(ErrorMessage = "Debe ingresar un correo electrónico.")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo electrónico válido.")]
        public string CorreoElectronico { get; set; } 
        [Required(ErrorMessage = "Debe ingresar una contraseña.")]
        [StringLength(50, MinimumLength = 8, ErrorMessage = "La contraseña debe contener entre 8 y 50 caracteres.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[\W_])[A-Za-z\d\W_]{8,20}$", ErrorMessage = "La contraseña debe contener al menos una letra mayúscula y al menos un caracter no alfanumérico.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "Debe seleccionar un rol.")]
        [ForeignKey(nameof(Rol))]
        public long IdRol { get; set; }
        public Rol Rol { get; set; }
    }
}
