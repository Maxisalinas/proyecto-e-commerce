using E_Commerce_Comun.Entidades;
using E_Commerce_Negocio.DTOs.AuthDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Gestores.JwtGestor
{
    public interface IGestorJwt
    {
        Task<AuthResultDto> GenerarTokenAsync(UsuarioIdentity user);
        Task<AuthResultDto> VerificarYGenerarTokenAsync(TokenRequestDto request);
    }
}
