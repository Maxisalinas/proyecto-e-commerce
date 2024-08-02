using E_Commerce_Comun.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Repositorios.CategoriaRepo
{
    public interface IRepositorioCategoria
    {
        Task<Categoria> Crear(Categoria categoria);
        Task<Categoria> Editar(Categoria categoria);
        Task<Categoria> Eliminar(long id);
        Task<bool> ExistePorId(long id);
        Task<bool> ExistePorNombre(string value);
        Task<List<Categoria>> ObtenerTodas();
        Task<Categoria> ObtenerUnaPorId(long id);
    }
}
