using E_Commerce_Comun.Entidades;
using E_Commerce_Comun.Sealed;
using E_Commerce_Negocio.DTOs.CategoriaDTOs.Request;
using E_Commerce_Negocio.DTOs.CategoriaDTOs.Response;
using E_Commerce_Negocio.DTOs.ProductoDTOs.Request;
using E_Commerce_Negocio.DTOs.ProductoDTOs.Response;
using E_Commerce_Negocio.Gestores.ProductoGestor;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Web_API.Controllers
{
    [Route("api/Producto")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly IGestorProducto _gestor;

        public ProductoController(IGestorProducto gestor)
        {
            _gestor = gestor;
        }

        [HttpPost("Crear", Name = "CrearProducto")]
        public async Task<CrearProductoResponseDto> Crear(CrearProductoRequestDto request)
        {
            var response = new CrearProductoResponseDto();

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

        [HttpPost("CrearMasivo", Name = "CrearMasivoProducto")]
        public async Task<CrearProductoMasivoResponseDto> CrearMasivo(CrearProductoMasivoRequestDto request)
        {
            var response = new CrearProductoMasivoResponseDto();

            try
            {

                var resultado = await _gestor.CrearMasivo(request);

                response = resultado;

            }
            catch (Exception exc)
            {

                throw exc;
            }

            return response;

        }

        [HttpPut("Editar", Name = "EditarProducto")]
        public async Task<EditarProductoResponseDto> Editar(EditarProductoRequestDto request)
        {
            var response = new EditarProductoResponseDto();

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

        [HttpDelete("Eliminar/{id:long}", Name = "EliminarProducto")]
        public async Task<EliminarProductoResponseDto> Eliminar(long id)
        {
            var response = new EliminarProductoResponseDto();

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

        [HttpPost("Buscador", Name = "BuscadorProducto")]
        public async Task<BuscadorProductoResponseDto> Buscador(BuscadorProductoRequestDto request)
        {
            var response = new BuscadorProductoResponseDto();

            try
            {
                var resultado = await _gestor.Buscador(request);

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

        [HttpPost("BuscadorBody", Name = "BuscadorBodyProducto")]
        public async Task<BuscadorProductoResponseDto> BuscadorBody([FromBody] BuscadorProductoRequestDto request)
        {
            var response = new BuscadorProductoResponseDto();

            try
            {
                var resultado = await _gestor.Buscador(request);

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


        [HttpPost("ObtenerUnoPorId/{id:long}", Name = "ObtenerUnoPorIdProducto")]
        public async Task<ObtenerUnProductoResponseDto> ObtenerUnoPorId(long id)
        {
            var response = new ObtenerUnProductoResponseDto();

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
