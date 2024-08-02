using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.ProductoDTOs.Request
{
    public class BuscadorProductoRequestDto
    {
        public string CriterioBusqueda { get; set; } = string.Empty;
        public int PageSize { get; set; } = 0;
        public int PageNumber { get; set; } = 0;
    }
}
