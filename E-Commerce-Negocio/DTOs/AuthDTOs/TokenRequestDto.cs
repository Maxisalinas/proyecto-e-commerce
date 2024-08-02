using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.AuthDTOs
{
    public class TokenRequestDto
    {
        [Required(ErrorMessage = "Debe enviar un Access Token válido.")]
        public string AccessToken { get; set; } = string.Empty;
        [Required(ErrorMessage = "Debe enviar un Refresh Token válido.")]
        public string RefreshToken { get; set; } = string.Empty;
    }
}
