using E_Commerce_Negocio.DTOs.CategoriaDTOs.Request;
using E_Commerce_Negocio.DTOs.CategoriaDTOs.Response;
using E_Commerce_Negocio.DTOs.GeneroDTOs.Request;
using E_Commerce_Negocio.DTOs.GeneroDTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Gestores.GeneroGestor
{
    public interface IGestorGenero
    {
        Task<CrearGeneroResponseDto> Crear(CrearGeneroRequestDto genero);
        Task<EditarGeneroResponseDto> Editar(EditarGeneroRequestDto genero);
        Task<EliminarGeneroResponseDto> Eliminar(long id);
        //Task<bool> ExistePorId(long id);
        //Task<bool> ExistePorNombre(string value);
        Task<ObtenerTodosGeneroResponseDto> ObtenerTodos();
        Task<ObtenerUnGeneroResponseDto> ObtenerUnoPorId(long id);
    }
}
