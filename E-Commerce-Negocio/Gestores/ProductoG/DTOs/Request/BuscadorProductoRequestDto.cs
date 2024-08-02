using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Gestores.ProductoG.DTOs.Request
{
    public class BuscadorProductoRequestDto
    {
        public string CriterioBusqueda { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
