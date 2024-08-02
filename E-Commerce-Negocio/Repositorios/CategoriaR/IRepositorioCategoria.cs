using E_Commerce_Comun.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Repositorios.CategoriaR
{
    public interface IRepositorioCategoria
    {
        Task<List<Categoria>> ObtenerTodos();
        Task<Categoria> ObtenerUnoPorId(long id);
        Task<Categoria> Crear(Categoria producto);
        Task<Categoria> Editar(Categoria producto);
        Task<Categoria> Eliminar(long id);
    }
}
