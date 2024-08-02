using E_Commerce_Comun.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Repositorios.MarcaRepo
{
    public interface IRepositorioMarca
    {
        Task<Marca> Crear(Marca marca);
        Task<Marca> Editar(Marca marca);
        Task<Marca> Eliminar(long id);
        Task<bool> ExistePorId(long id);
        Task<bool> ExistePorNombre(string value);
        Task<List<Marca>> ObtenerTodas();
        Task<Marca> ObtenerUnaPorId(long id);
    }
}
