using E_Commerce_Comun.Entidades;
using E_Commerce_Comun.Sealed;
using E_Commerce_Negocio.DTOs.CategoriaDTOs.Request;
using E_Commerce_Negocio.DTOs.CategoriaDTOs.Response;
using E_Commerce_Negocio.DTOs.GeneroDTOs.Request;
using E_Commerce_Negocio.DTOs.GeneroDTOs.Response;
using E_Commerce_Negocio.Gestores.GeneroGestor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Web_API.Controllers
{
    [Authorize]
    [Route("api/Genero")]
    [ApiController]
    public class GeneroController : ControllerBase
    {
        private readonly IGestorGenero _gestor;

        public GeneroController(IGestorGenero gestor)
        {
            _gestor = gestor;
        }

        [HttpPost("Crear", Name = "CrearGenero")]
        public async Task<CrearGeneroResponseDto> Crear(CrearGeneroRequestDto request)
        {
            var response = new CrearGeneroResponseDto();

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

        [HttpPut("Editar", Name = "EditarGenero")]
        public async Task<EditarGeneroResponseDto> Editar(EditarGeneroRequestDto request)
        {
            var response = new EditarGeneroResponseDto();

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

        [HttpDelete("Eliminar/{id:long}", Name = "EliminarGenero")]
        public async Task<EliminarGeneroResponseDto> Eliminar(long id)
        {
            var response = new EliminarGeneroResponseDto();

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

        [HttpGet("ObtenerTodos", Name = "ObtenerTodosGenero")]
        public async Task<ObtenerTodosGeneroResponseDto> ObtenerTodos()
        {
            var response = new ObtenerTodosGeneroResponseDto();

            try
            {
                var resultado = await _gestor.ObtenerTodos();

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


        [HttpPost("ObtenerUnoPorId/{id:long}", Name = "ObtenerUnoPorIdGenero")]
        public async Task<ObtenerUnGeneroResponseDto> ObtenerUnoPorId(long id)
        {
            var response = new ObtenerUnGeneroResponseDto();

            try
            {
                var resultado = await _gestor.ObtenerUnoPorId(id);

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
