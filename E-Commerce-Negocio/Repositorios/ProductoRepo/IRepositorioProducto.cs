using E_Commerce_Comun.Entidades;
using E_Commerce_Negocio.DTOs.ProductoDTOs.Request;
using E_Commerce_Negocio.DTOs.ProductoDTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Repositorios.ProductoRepo
{
    public interface IRepositorioProducto
    {
        Task<Producto> Crear(Producto producto);
        Task<List<Producto>> CrearMasivo(List<Producto> productos);
        Task<Producto> Editar(Producto producto);
        Task<Producto> Eliminar(long id);
        //Task<bool> ExistePorId(long id);
        //Task<bool> ExistePorNombre(string value);
        Task<List<Producto>> Buscador(string criterioBusqueda, int pageSize, int pageNumber);
        Task<List<Producto>> Buscar(string criterioBusqueda, int pageSize, int pageNumber);
        Task<Producto> ObtenerUnoPorId(long id);
    }
}
