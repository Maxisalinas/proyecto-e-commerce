using E_Commerce_Comun.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Repositorios.ProductoR
{
    public interface IRepositorioCategoria
    {
        Task<List<Producto>> Buscador(string filtro, int pageNumber = 1, int pageSize = 12);
        //Task<List<Producto>> Buscador(List<string> filtros, int pageSize = 12, int pageNumber = 1);
        Task<List<Producto>> ObtenerTodos();
        Task<Producto> ObtenerUnoPorId(long id);
        Task<Producto> Crear(Producto producto);
        //Task<List<Producto>> CrearMasivo(List<Producto> productos);
        Task<Producto> Editar(Producto producto);
        //Task<bool> ValidarExistenciaPorId(long id);
        //Task<bool> ValidarExistenciaPorTexto(string value);
        Task<Producto> Eliminar(long id);
    }
}
