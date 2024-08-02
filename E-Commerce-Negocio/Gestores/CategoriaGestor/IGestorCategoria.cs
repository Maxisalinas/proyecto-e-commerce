using E_Commerce_Comun.Entidades;
using E_Commerce_Negocio.DTOs.CategoriaDTOs;
using E_Commerce_Negocio.DTOs.CategoriaDTOs.Request;
using E_Commerce_Negocio.DTOs.CategoriaDTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Gestores.CategoriaGestor
{
    public interface IGestorCategoria
    {
        Task<CrearCategoriaResponseDto> Crear(CrearCategoriaRequestDto categoria);
        Task<EditarCategoriaResponseDto> Editar(EditarCategoriaRequestDto categoria);
        Task<EliminarCategoriaResponseDto> Eliminar(long id);
        Task<ObtenerTodasCategoriaResponseDto> ObtenerTodas();
        Task<ObtenerUnaCategoriaResponseDto> ObtenerUnaPorId(long id);
    }
}
