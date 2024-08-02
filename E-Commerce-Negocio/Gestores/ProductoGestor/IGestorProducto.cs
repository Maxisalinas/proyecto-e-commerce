using E_Commerce_Negocio.DTOs.ProductoDTOs.Request;
using E_Commerce_Negocio.DTOs.ProductoDTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Gestores.ProductoGestor
{
    public interface IGestorProducto
    {
        Task<CrearProductoResponseDto> Crear(CrearProductoRequestDto producto);
        Task<CrearProductoMasivoResponseDto> CrearMasivo(CrearProductoMasivoRequestDto request);
        Task<EditarProductoResponseDto> Editar(EditarProductoRequestDto producto);
        Task<EliminarProductoResponseDto> Eliminar(long id);
        //Task<bool> ExistePorId(long id);
        //Task<bool> ExistePorNombre(string value);
        Task<BuscadorProductoResponseDto> Buscador(BuscadorProductoRequestDto request);
        Task<ObtenerUnProductoResponseDto> ObtenerUnoPorId(long id);
    }
}
