using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.ProductoDTOs.Request
{
    public class ObtenerUnProductoRequestDto
    {
        [Required(ErrorMessage = "Debe ingresar un producto.")]
        public long Id { get; set; }
    }
}
