using E_Commerce_Negocio.Gestores.ProductoG;
using E_Commerce_Negocio.Gestores.ProductoG.DTOs.Request;
using E_Commerce_Negocio.Gestores.ProductoG.DTOs.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Web_API.Controllers
{
    [Route("api/Producto")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private readonly GestorProducto _gestor;

        public ProductoController(GestorProducto gestor)
        {
            _gestor = gestor;
        }

        //[HttpPost("Buscador", Name = "Buscador")]
        //public Task<BuscadorProductoResponseDto> Buscador(BuscadorProductoRequestDto request)
        //{
            
        //}

    }
}
