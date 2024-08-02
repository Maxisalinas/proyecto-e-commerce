using AutoMapper;
using E_Commerce_Comun.Entidades;
using E_Commerce_Comun.Sealed;
using E_Commerce_Negocio.DTOs.CategoriaDTOs.Response;
using E_Commerce_Negocio.DTOs.CategoriaDTOs;
using E_Commerce_Negocio.DTOs.ProductoDTOs.Request;
using E_Commerce_Negocio.DTOs.ProductoDTOs.Response;
using E_Commerce_Negocio.Repositorios.ProductoRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using E_Commerce_Negocio.DTOs.ProductoDTOs;

namespace E_Commerce_Negocio.Gestores.ProductoGestor
{
    public class GestorProducto : IGestorProducto
    {
        private readonly IRepositorioProducto _repo;
        private readonly IMapper _mapper;

        public GestorProducto(IRepositorioProducto repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<BuscadorProductoResponseDto> Buscador(BuscadorProductoRequestDto request)
        {
            var response = new BuscadorProductoResponseDto();

            try
            {
                var entidadesAux = await _repo.Buscar(request.CriterioBusqueda, request.PageSize, request.PageNumber);
                
                var entidades = await _repo.Buscador(request.CriterioBusqueda, request.PageSize, request.PageNumber);

                if (entidades.Count == 0)
                {
                    response.StatusCode = HttpStatusCode.OK;
                    response.Mensajes.Add(new Mensaje("Sin resultados.", MessageClass.Success, "Success"));
                    response.Mensajes.Add(new Mensaje("No hay nada que mostrar.", MessageClass.Success, "Success"));
                    return response;
                }

                entidades.ForEach(entidad =>
                {
                    response.Productos.Add(_mapper.Map<ProductoDto>(entidad));
                });

                response.TotalResultados = entidadesAux.Count();
                response.Pagina = request.PageNumber;
                response.ResultadosPorPagina = request.PageSize;
                response.TotalPaginas = (entidadesAux.Count() / request.PageSize) + 1;
                response.StatusCode = HttpStatusCode.OK;
                response.Mensajes.Add(new Mensaje("¡Operación exitosa!", MessageClass.Success, "Success"));

            }
            catch (Exception exc)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Mensajes.Add(new Mensaje("¡Ups, algo salió mal! Por favor, intente nuevamente.", MessageClass.Danger, "InternalServerError"));
                response.Mensajes.Add(new Mensaje("Internal server error.", MessageClass.Danger, "InternalServerError"));
                return response;
            }

            return response;
        }

        public async Task<CrearProductoResponseDto> Crear(CrearProductoRequestDto producto)
        {
            var response = new CrearProductoResponseDto();

            try
            {
                if(producto == null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Mensajes.Add(new Mensaje("Null request.", MessageClass.Danger, "NullRequest"));
                    response.Mensajes.Add(new Mensaje("El contenido de la solicitud no puede ser nulo.", MessageClass.Danger, "NullRequest"));
                    return response;
                }

                var entidad = _mapper.Map<Producto>(producto);

                var resultado = await _repo.Crear(entidad);

                if (resultado == null)
                {
                    response.StatusCode = HttpStatusCode.UnprocessableEntity;
                    response.Mensajes.Add(new Mensaje("Null entity.", MessageClass.Danger, "NullEntity"));
                    response.Mensajes.Add(new Mensaje("El contenido de la solicitud no puede ser nula.", MessageClass.Danger, "NullRequest"));
                    return response;
                }

                response.Producto = _mapper.Map<ProductoDto>(resultado);
                response.StatusCode = HttpStatusCode.OK;
                response.Mensajes.Add(new Mensaje("¡Producto creado con éxito!", MessageClass.Success, "Success"));

            }
            catch (Exception exc)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Mensajes.Add(new Mensaje("¡Ups, algo salió mal! Por favor, intente nuevamente.", MessageClass.Danger, "InternalServerError"));
                response.Mensajes.Add(new Mensaje("Internal server error.", MessageClass.Danger, "InternalServerError"));
                return response;
            }

            return response;
        }

        public async Task<CrearProductoMasivoResponseDto> CrearMasivo(CrearProductoMasivoRequestDto request)
        {
            var response = new CrearProductoMasivoResponseDto();

            try
            {
                if (request == null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Mensajes.Add(new Mensaje("Null request.", MessageClass.Danger, "NullRequest"));
                    response.Mensajes.Add(new Mensaje("El contenido de la solicitud no puede ser nulo.", MessageClass.Danger, "NullRequest"));
                    return response;
                }

                //var entidad = _mapper.Map<Producto>(producto);
                var entidades = new List<Producto>();
                request.Productos.ForEach(producto =>
                {
                    entidades.Add(_mapper.Map<Producto>(producto));
                });

                var resultados = await _repo.CrearMasivo(entidades);

                if (resultados == null)
                {
                    response.StatusCode = HttpStatusCode.UnprocessableEntity;
                    response.Mensajes.Add(new Mensaje("Null entity.", MessageClass.Danger, "NullEntity"));
                    response.Mensajes.Add(new Mensaje("El contenido de la solicitud no puede ser nula.", MessageClass.Danger, "NullRequest"));
                    return response;
                }

                resultados.ForEach(resultado =>
                {
                    response.Productos.Add(_mapper.Map<ProductoDto>(resultado));
                });

                response.TotalResultados = resultados.Count;
                response.StatusCode = HttpStatusCode.OK;
                response.Mensajes.Add(new Mensaje("¡Productos creados con éxito!", MessageClass.Success, "Success"));

            }
            catch (Exception exc)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Mensajes.Add(new Mensaje("¡Ups, algo salió mal! Por favor, intente nuevamente.", MessageClass.Danger, "InternalServerError"));
                response.Mensajes.Add(new Mensaje("Internal server error.", MessageClass.Danger, "InternalServerError"));
                return response;
            }

            return response;
        }

        public async Task<EditarProductoResponseDto> Editar(EditarProductoRequestDto producto)
        {
            var response = new EditarProductoResponseDto();

            try
            {
                if (producto == null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Mensajes.Add(new Mensaje("Null request.", MessageClass.Danger, "NullRequest"));
                    response.Mensajes.Add(new Mensaje("El contenido de la solicitud no puede ser nulo.", MessageClass.Danger, "NullRequest"));
                    return response;
                }

                var entidad = _mapper.Map<Producto>(producto);

                var resultado = await _repo.Editar(entidad);

                if (resultado == null)
                {
                    response.StatusCode = HttpStatusCode.UnprocessableEntity;
                    response.Mensajes.Add(new Mensaje("Null entity.", MessageClass.Danger, "NullEntity"));
                    response.Mensajes.Add(new Mensaje("No existe un producto activo con los datos ingresados.", MessageClass.Danger, "NullRequest"));
                    return response;
                }

                response.Producto = _mapper.Map<ProductoEditarDto>(resultado);
                response.StatusCode = HttpStatusCode.OK;
                response.Mensajes.Add(new Mensaje("¡Producto editado con éxito!", MessageClass.Success, "Success"));

            }
            catch (Exception exc)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Mensajes.Add(new Mensaje("¡Ups, algo salió mal! Por favor, intente nuevamente.", MessageClass.Danger, "InternalServerError"));
                response.Mensajes.Add(new Mensaje("Internal server error.", MessageClass.Danger, "InternalServerError"));
                return response;
            }

            return response;
        }

        public async Task<EliminarProductoResponseDto> Eliminar(long id)
        {
            var response = new EliminarProductoResponseDto();

            try
            {
                if (id <= 0)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Mensajes.Add(new Mensaje("Null request.", MessageClass.Danger, "NullRequest"));
                    response.Mensajes.Add(new Mensaje("El Id del producto no puede ser menor o igual a 0.", MessageClass.Danger, "NullRequest"));
                    return response;
                }

                var resultado = await _repo.Eliminar(id);

                if (resultado == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Mensajes.Add(new Mensaje("Not found.", MessageClass.Danger, "NotFound"));
                    response.Mensajes.Add(new Mensaje("No existe un producto activo con los valores ingresados.", MessageClass.Danger, "NotFound"));
                    return response;
                }

                response.Producto = _mapper.Map<ProductoDto>(resultado);
                response.StatusCode = HttpStatusCode.OK;
                response.Mensajes.Add(new Mensaje("¡Producto eliminado con éxito!", MessageClass.Success, "Success"));

            }
            catch (Exception exc)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Mensajes.Add(new Mensaje("¡Ups, algo salió mal! Por favor, intente nuevamente.", MessageClass.Danger, "InternalServerError"));
                response.Mensajes.Add(new Mensaje("Internal server error.", MessageClass.Danger, "InternalServerError"));
                return response;
            }

            return response;
        }

        public async Task<ObtenerUnProductoResponseDto> ObtenerUnoPorId(long id)
        {
            var response = new ObtenerUnProductoResponseDto();

            try
            {
                if (id <= 0)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Mensajes.Add(new Mensaje("Null request.", MessageClass.Danger, "NullRequest"));
                    response.Mensajes.Add(new Mensaje("El Id del producto no puede ser menor o igual a 0.", MessageClass.Danger, "NullRequest"));
                    return response;
                }

                var entidad = await _repo.ObtenerUnoPorId(id);

                if (entidad == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Mensajes.Add(new Mensaje("Sin resultados.", MessageClass.Success, "Success"));
                    response.Mensajes.Add(new Mensaje("No existe un producto activo con los valores ingresados.", MessageClass.Success, "Success"));
                    return response;
                }


                response.Producto = _mapper.Map<ProductoDto>(entidad);
                response.StatusCode = HttpStatusCode.OK;
                response.Mensajes.Add(new Mensaje("¡Operación exitosa!", MessageClass.Success, "Success"));

            }
            catch (Exception exc)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Mensajes.Add(new Mensaje("¡Ups, algo salió mal! Por favor, intente nuevamente.", MessageClass.Danger, "InternalServerError"));
                response.Mensajes.Add(new Mensaje("Internal server error.", MessageClass.Danger, "InternalServerError"));
                return response;
            }

            return response;
        }
    }
}
