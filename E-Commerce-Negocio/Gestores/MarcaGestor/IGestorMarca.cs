using E_Commerce_Negocio.DTOs.CategoriaDTOs.Request;
using E_Commerce_Negocio.DTOs.CategoriaDTOs.Response;
using E_Commerce_Negocio.DTOs.MarcaDTOs.Request;
using E_Commerce_Negocio.DTOs.MarcaDTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Gestores.MarcaGestor
{
    public interface IGestorMarca
    {
        Task<CrearMarcaResponseDto> Crear(CrearMarcaRequestDto marca);
        Task<EditarMarcaResponseDto> Editar(EditarMarcaRequestDto marca);
        Task<EliminarMarcaResponseDto> Eliminar(long id);
        Task<ObtenerTodasMarcaResponseDto> ObtenerTodas();
        Task<ObtenerUnaMarcaResponseDto> ObtenerUnaPorId(long id);
    }
}
