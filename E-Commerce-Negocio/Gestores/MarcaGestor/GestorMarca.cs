using E_Commerce_Comun.Entidades;
using E_Commerce_Comun.Sealed;
using E_Commerce_Negocio.DTOs.CategoriaDTOs.Response;
using E_Commerce_Negocio.DTOs.CategoriaDTOs;
using E_Commerce_Negocio.DTOs.MarcaDTOs.Request;
using E_Commerce_Negocio.DTOs.MarcaDTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using E_Commerce_Negocio.Repositorios.MarcaRepo;
using AutoMapper;
using E_Commerce_Negocio.DTOs.MarcaDTOs;

namespace E_Commerce_Negocio.Gestores.MarcaGestor
{
    public class GestorMarca : IGestorMarca
    {
        private readonly IRepositorioMarca _repo;
        private readonly IMapper _mapper;

        public GestorMarca(IRepositorioMarca repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CrearMarcaResponseDto> Crear(CrearMarcaRequestDto marca)
        {
            var response = new CrearMarcaResponseDto();

            try
            {
                if (marca == null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Mensajes.Add(new Mensaje("Null request.", MessageClass.Danger, "NullRequest"));
                    response.Mensajes.Add(new Mensaje("El contenido de la solicitud no puede ser nulo.", MessageClass.Danger, "NullRequest"));
                    return response;
                }

                if (await _repo.ExistePorNombre(marca.Nombre))
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Mensajes.Add(new Mensaje("Invalid request.", MessageClass.Danger, "InvalidRequest"));
                    response.Mensajes.Add(new Mensaje("Ya existe una marca con el nombre ingresado.", MessageClass.Danger, "InvalidRequest"));
                    return response;
                }

                var entidad = _mapper.Map<Marca>(marca);

                var resultado = await _repo.Crear(entidad);

                if (resultado == null)
                {
                    response.StatusCode = HttpStatusCode.UnprocessableEntity;
                    response.Mensajes.Add(new Mensaje("Null entity.", MessageClass.Danger, "NullEntity"));
                    response.Mensajes.Add(new Mensaje("El contenido de la solicitud no puede ser nula.", MessageClass.Danger, "NullRequest"));
                    return response;
                }

                response.Marca = _mapper.Map<MarcaDto>(resultado);
                response.StatusCode = HttpStatusCode.OK;
                response.Mensajes.Add(new Mensaje("¡Marca creada con éxito!", MessageClass.Success, "Success"));

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

        public async Task<EditarMarcaResponseDto> Editar(EditarMarcaRequestDto marca)
        {
            var response = new EditarMarcaResponseDto();

            try
            {
                if (marca == null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Mensajes.Add(new Mensaje("Null request.", MessageClass.Danger, "NullRequest"));
                    response.Mensajes.Add(new Mensaje("El contenido de la solicitud no puede ser nulo.", MessageClass.Danger, "NullRequest"));
                    return response;
                }

                var entidad = _mapper.Map<Marca>(marca);

                var resultado = await _repo.Editar(entidad);

                if (resultado == null)
                {
                    response.StatusCode = HttpStatusCode.UnprocessableEntity;
                    response.Mensajes.Add(new Mensaje("Null entity.", MessageClass.Danger, "NullEntity"));
                    response.Mensajes.Add(new Mensaje("No existe una marca activa con los datos ingresados.", MessageClass.Danger, "NullRequest"));
                    return response;
                }

                response.Marca = _mapper.Map<MarcaEditarDto>(resultado);
                response.StatusCode = HttpStatusCode.OK;
                response.Mensajes.Add(new Mensaje("¡Marca editada con éxito!", MessageClass.Success, "Success"));

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

        public async Task<EliminarMarcaResponseDto> Eliminar(long id)
        {
            var response = new EliminarMarcaResponseDto();

            try
            {
                if (id <= 0)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Mensajes.Add(new Mensaje("Null request.", MessageClass.Danger, "NullRequest"));
                    response.Mensajes.Add(new Mensaje("El Id de la marca no puede ser menor o igual a 0.", MessageClass.Danger, "NullRequest"));
                    return response;
                }

                var resultado = await _repo.Eliminar(id);

                if (resultado == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Mensajes.Add(new Mensaje("Not found.", MessageClass.Danger, "NotFound"));
                    response.Mensajes.Add(new Mensaje("No existe una marca activa con los valores ingresados.", MessageClass.Danger, "NotFound"));
                    return response;
                }

                response.Marca = _mapper.Map<MarcaDto>(resultado);
                response.StatusCode = HttpStatusCode.OK;
                response.Mensajes.Add(new Mensaje("¡Marca eliminada con éxito!", MessageClass.Success, "Success"));

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

        public async Task<ObtenerTodasMarcaResponseDto> ObtenerTodas()
        {
            var response = new ObtenerTodasMarcaResponseDto();

            try
            {
                var entidades = await _repo.ObtenerTodas();

                if (entidades.Count == 0)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Mensajes.Add(new Mensaje("Sin resultados.", MessageClass.Success, "Success"));
                    response.Mensajes.Add(new Mensaje("No hay nada que mostrar.", MessageClass.Success, "Success"));
                    return response;
                }

                entidades.ForEach(entidad =>
                {
                    response.Marcas.Add(_mapper.Map<MarcaDto>(entidad));
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

        public async Task<ObtenerUnaMarcaResponseDto> ObtenerUnaPorId(long id)
        {
            var response = new ObtenerUnaMarcaResponseDto();

            try
            {
                if (id <= 0)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Mensajes.Add(new Mensaje("Null request.", MessageClass.Danger, "NullRequest"));
                    response.Mensajes.Add(new Mensaje("El Id de la marca no puede ser menor o igual a 0.", MessageClass.Danger, "NullRequest"));
                    return response;
                }

                var entidad = await _repo.ObtenerUnaPorId(id);

                if (entidad == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Mensajes.Add(new Mensaje("Sin resultados.", MessageClass.Success, "Success"));
                    response.Mensajes.Add(new Mensaje("No existe una marca activa con los valores ingresados.", MessageClass.Success, "Success"));
                    return response;
                }


                response.Marca = _mapper.Map<MarcaDto>(entidad);
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
