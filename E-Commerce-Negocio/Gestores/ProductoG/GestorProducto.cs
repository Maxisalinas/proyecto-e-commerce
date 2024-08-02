using AutoMapper;
using E_Commerce_Comun.Entidades;
using E_Commerce_Negocio.Gestores.ProductoG.DTOs;
using E_Commerce_Negocio.Gestores.ProductoG.DTOs.Request;
using E_Commerce_Negocio.Repositorios.ProductoR;

namespace E_Commerce_Negocio.Gestores.ProductoG
{
    public class GestorProducto : IGestorProducto
    {
        private readonly RepositorioCategoria _repo;
        private readonly IMapper _mapper;

        public GestorProducto(RepositorioCategoria repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }

        public async Task<List<ProductoDto>> Buscador(BuscadorProductoRequestDto request)
        {
            var entidades = await _repo.Buscador(request.CriterioBusqueda, request.PageNumber, request.PageSize);
            var response = new List<ProductoDto>();
            entidades.ForEach(entidad =>
            {
                response.Add(_mapper.Map<ProductoDto>(entidad));
            });

            return response;
        }

        public async Task<ProductoDto> Crear(ProductoDto producto)
        {
            var entidad = _mapper.Map<Producto>(producto);
            var result = await _repo.Crear(entidad);
            var response = _mapper.Map<ProductoDto>(result);

            return response;
        }

        public async Task<ProductoDto> Editar(ProductoDto producto)
        {
            var entidad = _mapper.Map<Producto>(producto);
            var result = await _repo.Editar(entidad);
            var response = _mapper.Map<ProductoDto>(result);

            return response;
        }

        public async Task<ProductoDto> Eliminar(long id)
        { 
            var result = await _repo.Eliminar(id);
            var response = _mapper.Map<ProductoDto>(result);

            return response;
        }

        public async Task<List<ProductoDto>> ObtenerTodos()
        {
            var entidades = await _repo.ObtenerTodos();
            var response = new List<ProductoDto>();
            entidades.ForEach(entidad =>
            {
                response.Add(_mapper.Map<ProductoDto>(entidad));
            });

            return response;
        }

        public async Task<ProductoDto> ObtenerUnoPorId(long id)
        {
            var entidad = await _repo.ObtenerUnoPorId(id);
            var response = _mapper.Map<ProductoDto>(entidad);

            return response;
        }
    }
}
