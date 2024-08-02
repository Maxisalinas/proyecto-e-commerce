using E_Commerce_Comun.Entidades;
using E_Commerce_Comun.Sealed;
using E_Commerce_Negocio.DTOs.CategoriaDTOs.Request;
using E_Commerce_Negocio.DTOs.CategoriaDTOs.Response;
using E_Commerce_Negocio.Gestores.CategoriaGestor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Web_API.Controllers
{
    [Authorize]
    [Route("api/Categorias")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly IGestorCategoria _gestor;

        public CategoriaController(IGestorCategoria gestor)
        {
            _gestor = gestor;
        }

        [HttpPost("Crear", Name = "CrearCategoria")]
        public async Task<CrearCategoriaResponseDto> Crear(CrearCategoriaRequestDto request)
        {
            var response = new CrearCategoriaResponseDto();

            try
            {

                var resultado = await _gestor.Crear(request);

                response = resultado;

            }
            catch (Exception exc)
            {

                throw exc;
            }

            return response;

        }

        [HttpPut("Editar", Name = "EditarCategoria")]
        public async Task<EditarCategoriaResponseDto> Editar(EditarCategoriaRequestDto request)
        {
            var response = new EditarCategoriaResponseDto();

            try
            {
                var resultado = await _gestor.Editar(request);

                response = resultado;
            }
            catch (Exception exc)
            {

                response.Mensajes.Add(new Mensaje("Internal server error.", MessageClass.Danger, "InternalServerError"));
                response.Mensajes.Add(new Mensaje("Internal server error: Exception message: " + (exc.Message != string.Empty ? exc.Message : "Nada que mostrar."), MessageClass.Danger, exc.GetType().ToString()));
                response.Mensajes.Add(new Mensaje("Internal server error: Exception ToString(): " + (exc.ToString() != string.Empty ? exc.ToString() : "Nada que mostrar."), MessageClass.Danger, exc.GetType().ToString()));
                response.Mensajes.Add(new Mensaje("Internal server error: InnerException: " + (exc.InnerException?.Message != string.Empty ? exc.InnerException?.Message : "Nada que mostrar."), MessageClass.Danger, exc.GetType().ToString()));
                response.Mensajes.Add(new Mensaje("Internal server error: Data: " + (exc.Data != null ? exc.Data : "Nada que mostrar."), MessageClass.Danger, exc.GetType().ToString()));
                return response;
                //throw exc;
            }

            return response;

        }

        [HttpDelete("Eliminar/{id:long}", Name = "EliminarCategoria")]
        public async Task<EliminarCategoriaResponseDto> Eliminar(long id)
        {
            var response = new EliminarCategoriaResponseDto();

            try
            {
                var resultado = await _gestor.Eliminar(id);

                response = resultado;
            }
            catch (Exception exc)
            {

                response.Mensajes.Add(new Mensaje("Internal server error.", MessageClass.Danger, "InternalServerError"));
                response.Mensajes.Add(new Mensaje("Internal server error: Exception message: " + (exc.Message != string.Empty ? exc.Message : "Nada que mostrar."), MessageClass.Danger, exc.GetType().ToString()));
                response.Mensajes.Add(new Mensaje("Internal server error: Exception ToString(): " + (exc.ToString() != string.Empty ? exc.ToString() : "Nada que mostrar."), MessageClass.Danger, exc.GetType().ToString()));
                response.Mensajes.Add(new Mensaje("Internal server error: InnerException: " + (exc.InnerException?.Message != string.Empty ? exc.InnerException?.Message : "Nada que mostrar."), MessageClass.Danger, exc.GetType().ToString()));
                response.Mensajes.Add(new Mensaje("Internal server error: Data: " + (exc.Data != null ? exc.Data : "Nada que mostrar."), MessageClass.Danger, exc.GetType().ToString()));

                throw exc;
            }

            return response;
        }

        [HttpGet("ObtenerTodas", Name = "ObtenerTodasCategoria")]
        public async Task<ObtenerTodasCategoriaResponseDto> ObtenerTodas()
        {
            var response = new ObtenerTodasCategoriaResponseDto();
            
            try
            {
                var resultado = await _gestor.ObtenerTodas();

                response = resultado;
            }
            catch (Exception exc)
            {

                response.Mensajes.Add(new Mensaje("Internal server error.", MessageClass.Danger, "InternalServerError"));
                response.Mensajes.Add(new Mensaje("Internal server error: Exception message: " + (exc.Message != string.Empty ? exc.Message : "Nada que mostrar."), MessageClass.Danger, exc.GetType().ToString()));
                response.Mensajes.Add(new Mensaje("Internal server error: Exception ToString(): " + (exc.ToString() != string.Empty ? exc.ToString() : "Nada que mostrar."), MessageClass.Danger, exc.GetType().ToString()));
                response.Mensajes.Add(new Mensaje("Internal server error: InnerException: " + (exc.InnerException?.Message != string.Empty ? exc.InnerException?.Message : "Nada que mostrar."), MessageClass.Danger, exc.GetType().ToString()));
                response.Mensajes.Add(new Mensaje("Internal server error: Data: " + (exc.Data != null ? exc.Data : "Nada que mostrar."), MessageClass.Danger, exc.GetType().ToString()));
                return response;
                //throw exc;
            }

            return response;
        }


        [HttpPost("ObtenerUnaPorId/{id:long}", Name = "ObtenerUnaPorIdCategoria")]
        public async Task<ObtenerUnaCategoriaResponseDto> ObtenerUnaPorId(long id)
        {
            var response = new ObtenerUnaCategoriaResponseDto();

            try
            {
                var resultado = await _gestor.ObtenerUnaPorId(id);

                response = resultado;
            }
            catch (Exception exc)
            {

                response.Mensajes.Add(new Mensaje("Internal server error.", MessageClass.Danger, "InternalServerError"));
                response.Mensajes.Add(new Mensaje("Internal server error: Exception message: " + (exc.Message != string.Empty ? exc.Message : "Nada que mostrar."), MessageClass.Danger, exc.GetType().ToString()));
                response.Mensajes.Add(new Mensaje("Internal server error: Exception ToString(): " + (exc.ToString() != string.Empty ? exc.ToString() : "Nada que mostrar."), MessageClass.Danger, exc.GetType().ToString()));
                response.Mensajes.Add(new Mensaje("Internal server error: InnerException: " + (exc.InnerException?.Message != string.Empty ? exc.InnerException?.Message : "Nada que mostrar."), MessageClass.Danger, exc.GetType().ToString()));
                response.Mensajes.Add(new Mensaje("Internal server error: Data: " + (exc.Data != null ? exc.Data : "Nada que mostrar."), MessageClass.Danger, exc.GetType().ToString()));

                throw exc;
            }

            return response;
        }

    }
}
