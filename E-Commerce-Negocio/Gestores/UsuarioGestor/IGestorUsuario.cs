using E_Commerce_Negocio.DTOs.UsuarioDTOs.Request;
using E_Commerce_Negocio.DTOs.UsuarioDTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Gestores.UsuarioGestor
{
    public interface IGestorUsuario
    {
        Task<string> ObtenerNombrePorId(long id);
        Task<string> ObtenerPerfilCompletoParaTexto(long id);
    }
}
