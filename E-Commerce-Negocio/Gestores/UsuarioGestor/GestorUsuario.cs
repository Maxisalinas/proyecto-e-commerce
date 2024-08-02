using E_Commerce_Negocio.DTOs.UsuarioDTOs.Request;
using E_Commerce_Negocio.DTOs.UsuarioDTOs.Response;
using E_Commerce_Negocio.Repositorios.UsuarioRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Gestores.UsuarioGestor
{
    public class GestorUsuario : IGestorUsuario
    {
        private readonly IRepositorioUsuario _repo;

        public GestorUsuario(IRepositorioUsuario repo)
        {
            _repo = repo;
        }

        public async Task<string> ObtenerNombrePorId(long id)
        {
            var result = await _repo.ObtenerNombrePorId(id);

            if(result == string.Empty)
            {
                return string.Empty;
            }

            return result;
        }

        public async Task<string> ObtenerPerfilCompletoParaTexto(long id)
        {
            var result = await _repo.ObtenerPerfilCompletoParaTexto(id);

            return result;
        }
    }
}
