using E_Commerce_Negocio.DTOs.AuthDTOs;
using E_Commerce_Negocio.DTOs.UsuarioDTOs.Request;
using E_Commerce_Negocio.DTOs.UsuarioDTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Gestores.AuthGestor
{
    public interface IGestorAuth
    {
        Task<CrearUsuarioResponseDto> Crear(CrearUsuarioRequestDto request);
        Task<LoginResponseDto> Login(LoginRequestDto request);
        Task<AuthResultDto> RefreshToken(TokenRequestDto request);
    }
}
