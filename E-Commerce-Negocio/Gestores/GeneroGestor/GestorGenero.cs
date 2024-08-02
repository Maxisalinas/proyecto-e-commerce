using AutoMapper;
using E_Commerce_Comun.Entidades;
using E_Commerce_Comun.Sealed;
using E_Commerce_Negocio.DTOs.CategoriaDTOs;
using E_Commerce_Negocio.DTOs.CategoriaDTOs.Request;
using E_Commerce_Negocio.DTOs.CategoriaDTOs.Response;
using E_Commerce_Negocio.DTOs.GeneroDTOs;
using E_Commerce_Negocio.DTOs.GeneroDTOs.Request;
using E_Commerce_Negocio.DTOs.GeneroDTOs.Response;
using E_Commerce_Negocio.Repositorios.GeneroRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Gestores.GeneroGestor
{
    public class GestorGenero : IGestorGenero
    {
        private readonly IRepositorioGenero _repo;
        private readonly IMapper _mapper;

        public GestorGenero(IRepositorioGenero repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CrearGeneroResponseDto> Crear(CrearGeneroRequestDto genero)
        {
            var response = new CrearGeneroResponseDto();

            try
            {
                if (genero == null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Mensajes.Add(new Mensaje("Null request.", MessageClass.Danger, "NullRequest"));
                    response.Mensajes.Add(new Mensaje("El contenido de la solicitud no puede ser nulo.", MessageClass.Danger, "NullRequest"));
                    return response;
                }

                var entidad = _mapper.Map<Genero>(genero);

                var resultado = await _repo.Crear(entidad);

                if (resultado == null)
                {
                    response.StatusCode = HttpStatusCode.UnprocessableEntity;
                    response.Mensajes.Add(new Mensaje("Null entity.", MessageClass.Danger, "NullEntity"));
                    response.Mensajes.Add(new Mensaje("El contenido de la solicitud no puede ser nula.", MessageClass.Danger, "NullRequest"));
                    return response;
                }

                response.Genero = _mapper.Map<GeneroDto>(resultado);
                response.StatusCode = HttpStatusCode.OK;
                response.Mensajes.Add(new Mensaje("¡Género creado con éxito!", MessageClass.Success, "Success"));

            }
            catch (Exception exc)
            {
                response.StatusCode = HttpStatusCode.InternalServerError;
                response.Mensajes.Add(new Mensaje("¡Ups, algo salió mal! Por favor, intente nuevamente.", MessageClass.Danger, "InternalServerError"));
                response.Mensajes.Add(new Mensaje("Internal server error.", MessageClass.Danger, "InternalServerError"));
                response.Mensajes.Add(new Mensaje("InnerException: " + exc.InnerException?.Message, MessageClass.Danger, "InternalServerError"));
                return response;
            }

            return response;
        }

        public async Task<EditarGeneroResponseDto> Editar(EditarGeneroRequestDto genero)
        {
            var response = new EditarGeneroResponseDto();

            try
            {
                if (genero == null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Mensajes.Add(new Mensaje("Null request.", MessageClass.Danger, "NullRequest"));
                    response.Mensajes.Add(new Mensaje("El contenido de la solicitud no puede ser nulo.", MessageClass.Danger, "NullRequest"));
                    return response;
                }

                var entidad = _mapper.Map<Genero>(genero);

                var resultado = await _repo.Editar(entidad);

                if (resultado == null)
                {
                    response.StatusCode = HttpStatusCode.UnprocessableEntity;
                    response.Mensajes.Add(new Mensaje("Null entity.", MessageClass.Danger, "NullEntity"));
                    response.Mensajes.Add(new Mensaje("No existe un género activo con los datos ingresados.", MessageClass.Danger, "NullRequest"));
                    return response;
                }

                response.Genero = _mapper.Map<GeneroEditarDto>(resultado);
                response.StatusCode = HttpStatusCode.OK;
                response.Mensajes.Add(new Mensaje("¡Género editado con éxito!", MessageClass.Success, "Success"));

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

        public async Task<EliminarGeneroResponseDto> Eliminar(long id)
        {
            var response = new EliminarGeneroResponseDto();

            try
            {
                if (id <= 0)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Mensajes.Add(new Mensaje("Null request.", MessageClass.Danger, "NullRequest"));
                    response.Mensajes.Add(new Mensaje("El Id del género no puede ser menor o igual a 0.", MessageClass.Danger, "NullRequest"));
                    return response;
                }

                var resultado = await _repo.Eliminar(id);

                if (resultado == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Mensajes.Add(new Mensaje("Not found.", MessageClass.Danger, "NotFound"));
                    response.Mensajes.Add(new Mensaje("No existe un género activo con los valores ingresados.", MessageClass.Danger, "NotFound"));
                    return response;
                }

                response.Genero = _mapper.Map<GeneroDto>(resultado);
                response.StatusCode = HttpStatusCode.OK;
                response.Mensajes.Add(new Mensaje("¡Género eliminado con éxito!", MessageClass.Success, "Success"));

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

        public async Task<ObtenerTodosGeneroResponseDto> ObtenerTodos()
        {
            var response = new ObtenerTodosGeneroResponseDto();

            try
            {
                var entidades = await _repo.ObtenerTodos();

                if (entidades.Count == 0)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Mensajes.Add(new Mensaje("Sin resultados.", MessageClass.Success, "Success"));
                    response.Mensajes.Add(new Mensaje("No hay nada que mostrar.", MessageClass.Success, "Success"));
                    return response;
                }

                entidades.ForEach(entidad =>
                {
                    response.Generos.Add(_mapper.Map<GeneroDto>(entidad));
                });

                response.TotalResultados = entidades.Count();
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

        public async Task<ObtenerUnGeneroResponseDto> ObtenerUnoPorId(long id)
        {
            var response = new ObtenerUnGeneroResponseDto();

            try
            {
                if (id <= 0)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Mensajes.Add(new Mensaje("Null request.", MessageClass.Danger, "NullRequest"));
                    response.Mensajes.Add(new Mensaje("El Id del género no puede ser menor o igual a 0.", MessageClass.Danger, "NullRequest"));
                    return response;
                }

                var entidad = await _repo.ObtenerUnoPorId(id);

                if (entidad == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Mensajes.Add(new Mensaje("Sin resultados.", MessageClass.Success, "Success"));
                    response.Mensajes.Add(new Mensaje("No existe un género activo con los valores ingresados.", MessageClass.Success, "Success"));
                    return response;
                }


                response.Genero = _mapper.Map<GeneroDto>(entidad);
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
