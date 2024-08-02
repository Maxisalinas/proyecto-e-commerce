using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.CategoriaDTOs.Response
{
    public class ObtenerUnaCategoriaResponseDto : ResponseHttp
    {
        public ObtenerUnaCategoriaResponseDto() : base() 
        {
            Categoria = new CategoriaDto();
        }

        public CategoriaDto Categoria { get; set; }
    }
}
