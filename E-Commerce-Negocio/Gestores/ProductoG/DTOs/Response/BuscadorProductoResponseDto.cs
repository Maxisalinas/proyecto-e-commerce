using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Gestores.ProductoG.DTOs.Response
{
    public class BuscadorProductoResponseDto : ResponsePaginadoDto
    {
        public List<ProductoDto> Productos { get; set; }

        public BuscadorProductoResponseDto() : base()
        {
            Productos = new List<ProductoDto>();
        }
    }
}
