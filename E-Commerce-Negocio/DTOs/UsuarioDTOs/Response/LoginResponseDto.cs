using E_Commerce_Negocio.DTOs.AuthDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.UsuarioDTOs.Response
{
    public class LoginResponseDto
    {
        public AuthResultDto AuthResult { get; set; } = new AuthResultDto();
    }
}
