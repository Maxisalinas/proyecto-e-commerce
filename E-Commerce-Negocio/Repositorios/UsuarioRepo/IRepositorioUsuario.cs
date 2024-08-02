using E_Commerce_Comun.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Repositorios.UsuarioRepo
{
    public interface IRepositorioUsuario
    {
        Task<Usuario> Crear(Usuario user);
        Task<string> ObtenerNombrePorId(long id);
        Task<string> ObtenerPerfilCompletoParaTexto(long id);
    }
}
