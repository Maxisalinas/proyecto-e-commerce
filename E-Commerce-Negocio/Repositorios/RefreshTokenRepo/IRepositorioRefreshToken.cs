using E_Commerce_Comun.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Repositorios.RefreshTokenRepo
{
    public interface IRepositorioRefreshToken
    {
        Task<RefreshToken> Crear(RefreshToken token);
        Task<RefreshToken> ObtenerUno(string token);
        Task<RefreshToken> Actualizar(RefreshToken token);
    }
}
