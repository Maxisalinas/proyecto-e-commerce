using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.CategoriaDTOs.Response
{
    public class EliminarCategoriaResponseDto : ResponseHttp
    {
        public EliminarCategoriaResponseDto() : base()
        {
            Categoria = new CategoriaDto();
        }

        public CategoriaDto Categoria { get; set; }
    }
}
