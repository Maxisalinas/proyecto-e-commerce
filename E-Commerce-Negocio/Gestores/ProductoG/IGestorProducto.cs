using E_Commerce_Negocio.Gestores.ProductoG.DTOs;
using E_Commerce_Negocio.Gestores.ProductoG.DTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace E_Commerce_Negocio.Gestores.ProductoG
{
    public interface IGestorProducto
    {
        Task<List<ProductoDto>> Buscador(BuscadorProductoRequestDto request);
        //Task<List<Producto>> Buscador(List<string> filtros, int pageSize = 12, int pageNumber = 1);
        Task<List<ProductoDto>> ObtenerTodos();
        Task<ProductoDto> ObtenerUnoPorId(long id);
        Task<ProductoDto> Crear(ProductoDto producto);
        //Task<List<Producto>> CrearMasivo(List<Producto> productos);
        Task<ProductoDto> Editar(ProductoDto producto);
        //Task<bool> ValidarExistenciaPorId(long id);
        //Task<bool> ValidarExistenciaPorTexto(string value);
        Task<ProductoDto> Eliminar(long id);
    }
}
