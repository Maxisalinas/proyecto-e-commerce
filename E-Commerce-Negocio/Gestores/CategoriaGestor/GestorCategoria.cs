using AutoMapper;
using Azure.Core;
using E_Commerce_Comun.Entidades;
using E_Commerce_Comun.Sealed;
using E_Commerce_Negocio.DTOs.CategoriaDTOs;
using E_Commerce_Negocio.DTOs.CategoriaDTOs.Request;
using E_Commerce_Negocio.DTOs.CategoriaDTOs.Response;
using E_Commerce_Negocio.Repositorios.CategoriaRepo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Gestores.CategoriaGestor
{
    public class GestorCategoria : IGestorCategoria
    {
        private readonly IRepositorioCategoria _repo;
        private readonly IMapper _mapper;

        public GestorCategoria(IRepositorioCategoria repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<CrearCategoriaResponseDto> Crear(CrearCategoriaRequestDto categoria)
        {
            var response = new CrearCategoriaResponseDto();

            try
            {
                if (categoria == null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Mensajes.Add(new Mensaje("Null request.", MessageClass.Danger, "NullRequest"));
                    response.Mensajes.Add(new Mensaje("El contenido de la solicitud no puede ser nulo.", MessageClass.Danger, "NullRequest"));
                    return response;
                }

                if (await _repo.ExistePorNombre(categoria.Nombre))
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Mensajes.Add(new Mensaje("Invalid request.", MessageClass.Danger, "InvalidRequest"));
                    response.Mensajes.Add(new Mensaje("Ya existe una categoría con el nombre ingresado.", MessageClass.Danger, "InvalidRequest"));
                    return response;
                }

                var entidad = _mapper.Map<Categoria>(categoria);

                var resultado = await _repo.Crear(entidad);

                if (resultado == null)
                {
                    response.StatusCode = HttpStatusCode.UnprocessableEntity;
                    response.Mensajes.Add(new Mensaje("Null entity.", MessageClass.Danger, "NullEntity"));
                    response.Mensajes.Add(new Mensaje("El contenido de la solicitud no puede ser nula.", MessageClass.Danger, "NullRequest"));
                    return response;
                }

                response.Categoria = _mapper.Map<CategoriaDto>(resultado);
                response.StatusCode = HttpStatusCode.OK;
                response.Mensajes.Add(new Mensaje("¡Categoría creada con éxito!", MessageClass.Success, "Success"));

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

        public async Task<EditarCategoriaResponseDto> Editar(EditarCategoriaRequestDto categoria)
        {
            var response = new EditarCategoriaResponseDto();

            try
            {
                if (categoria == null)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Mensajes.Add(new Mensaje("Null request.", MessageClass.Danger, "NullRequest"));
                    response.Mensajes.Add(new Mensaje("El contenido de la solicitud no puede ser nulo.", MessageClass.Danger, "NullRequest"));
                    return response;
                }

                var entidad = _mapper.Map<Categoria>(categoria);

                var resultado = await _repo.Editar(entidad);

                if (resultado == null)
                {
                    response.StatusCode = HttpStatusCode.UnprocessableEntity;
                    response.Mensajes.Add(new Mensaje("Null entity.", MessageClass.Danger, "NullEntity"));
                    response.Mensajes.Add(new Mensaje("No existe una categoría activa con los datos ingresados.", MessageClass.Danger, "NullRequest"));
                    return response;
                }

                response.Categoria = _mapper.Map<CategoriaEditarDto>(resultado);
                response.StatusCode = HttpStatusCode.OK;
                response.Mensajes.Add(new Mensaje("¡Categoría editada con éxito!", MessageClass.Success, "Success"));

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

        public async Task<EliminarCategoriaResponseDto> Eliminar(long id)
        {
            var response = new EliminarCategoriaResponseDto();

            try
            {
                if (id <= 0)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Mensajes.Add(new Mensaje("Null request.", MessageClass.Danger, "NullRequest"));
                    response.Mensajes.Add(new Mensaje("El Id de la categoría no puede ser menor o igual a 0.", MessageClass.Danger, "NullRequest"));
                    return response;
                }

                var resultado = await _repo.Eliminar(id);

                if (resultado == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Mensajes.Add(new Mensaje("Not found.", MessageClass.Danger, "NotFound"));
                    response.Mensajes.Add(new Mensaje("No existe una categoría activa con los valores ingresados.", MessageClass.Danger, "NotFound"));
                    return response;
                }

                response.Categoria = _mapper.Map<CategoriaDto>(resultado);
                response.StatusCode = HttpStatusCode.OK;
                response.Mensajes.Add(new Mensaje("¡Categoría eliminada con éxito!", MessageClass.Success, "Success"));

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

        public async Task<ObtenerTodasCategoriaResponseDto> ObtenerTodas()
        {
            var response = new ObtenerTodasCategoriaResponseDto();

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
                    response.Categorias.Add(_mapper.Map<CategoriaDto>(entidad));
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

        public async Task<ObtenerUnaCategoriaResponseDto> ObtenerUnaPorId(long id)
        {
            var response = new ObtenerUnaCategoriaResponseDto();

            try
            {
                if (id <= 0)
                {
                    response.StatusCode = HttpStatusCode.BadRequest;
                    response.Mensajes.Add(new Mensaje("Null request.", MessageClass.Danger, "NullRequest"));
                    response.Mensajes.Add(new Mensaje("El Id de la categoría no puede ser menor o igual a 0.", MessageClass.Danger, "NullRequest"));
                    return response;
                }

                var entidad = await _repo.ObtenerUnaPorId(id);

                if (entidad == null)
                {
                    response.StatusCode = HttpStatusCode.NotFound;
                    response.Mensajes.Add(new Mensaje("Sin resultados.", MessageClass.Success, "Success"));
                    response.Mensajes.Add(new Mensaje("No existe una categoría activa con los valores ingresados.", MessageClass.Success, "Success"));
                    return response;
                }


                response.Categoria = _mapper.Map<CategoriaDto>(entidad);
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
