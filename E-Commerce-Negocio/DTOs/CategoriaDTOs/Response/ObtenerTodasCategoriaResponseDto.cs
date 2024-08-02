using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.CategoriaDTOs.Response
{
    public class ObtenerTodasCategoriaResponseDto : ResponsePaginado
    {
        public ObtenerTodasCategoriaResponseDto() : base()
        {
            Categorias = new List<CategoriaDto>();
        }

        public List<CategoriaDto> Categorias { get; set; }

    }
}
