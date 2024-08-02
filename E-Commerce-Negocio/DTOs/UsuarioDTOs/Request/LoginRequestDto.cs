using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.UsuarioDTOs.Request
{
    public class LoginRequestDto
    {

        [Required(ErrorMessage="El campo es requerido.")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo electrónico válido.")]
        public string CorreoElectronico { get; set; }
        [Required(ErrorMessage="El campo es requerido.")]
        public string Password { get; set; }
    }
}
