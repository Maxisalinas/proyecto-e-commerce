using E_Commerce_Comun.Entidades;
using E_Commerce_Comun.Sealed;
using E_Commerce_Negocio.DTOs.CategoriaDTOs.Request;
using E_Commerce_Negocio.DTOs.CategoriaDTOs.Response;
using E_Commerce_Negocio.DTOs.MarcaDTOs.Request;
using E_Commerce_Negocio.DTOs.MarcaDTOs.Response;
using E_Commerce_Negocio.Gestores.MarcaGestor;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Web_API.Controllers
{
    [Authorize]
    [Route("api/Marca")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
        private readonly IGestorMarca _gestor;

        public MarcaController(IGestorMarca gestor)
        {
            _gestor = gestor;
        }

        [HttpPost("Crear", Name = "CrearMarca")]
        public async Task<CrearMarcaResponseDto> Crear(CrearMarcaRequestDto request)
        {
            var response = new CrearMarcaResponseDto();

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

        [HttpPut("Editar", Name = "EditarMarca")]
        public async Task<EditarMarcaResponseDto> Editar(EditarMarcaRequestDto request)
        {
            var response = new EditarMarcaResponseDto();

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

        [HttpDelete("Eliminar/{id:long}", Name = "EliminarMarca")]
        public async Task<EliminarMarcaResponseDto> Eliminar(long id)
        {
            var response = new EliminarMarcaResponseDto();

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

        [HttpGet("ObtenerTodas", Name = "ObtenerTodasMarca")]
        public async Task<ObtenerTodasMarcaResponseDto> ObtenerTodas()
        {
            var response = new ObtenerTodasMarcaResponseDto();

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


        [HttpPost("ObtenerUnaPorId/{id:long}", Name = "ObtenerUnaPorIdMarca")]
        public async Task<ObtenerUnaMarcaResponseDto> ObtenerUnaPorId(long id)
        {
            var response = new ObtenerUnaMarcaResponseDto();

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
