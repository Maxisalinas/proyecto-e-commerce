using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.ProductoDTOs.Response
{
    public class ObtenerUnProductoResponseDto : ResponseHttp
    {
        public ObtenerUnProductoResponseDto() : base()
        {
            Producto = new ProductoDto();
        }

        public ProductoDto Producto { get; set; }
    }
}
