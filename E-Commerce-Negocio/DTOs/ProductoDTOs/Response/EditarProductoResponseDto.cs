using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.ProductoDTOs.Response
{
    public class EditarProductoResponseDto : ResponseHttp
    {
        public EditarProductoResponseDto() : base()
        {
            Producto = new ProductoEditarDto();
        }

        public ProductoEditarDto Producto { get; set; }
    }
}
