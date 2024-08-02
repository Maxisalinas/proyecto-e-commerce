using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.ProductoDTOs.Response
{
    public class CrearProductoMasivoResponseDto : ResponsePaginado
    {
        public CrearProductoMasivoResponseDto() : base()
        {
            Productos = new List<ProductoDto>();
        }

        public List<ProductoDto> Productos { get; set; }
    }
}
