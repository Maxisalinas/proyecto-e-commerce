using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.CategoriaDTOs.Response
{
    public class EditarCategoriaResponseDto : ResponseHttp
    {
        public EditarCategoriaResponseDto() : base()
        {
            Categoria = new CategoriaEditarDto();
        }

        public CategoriaEditarDto Categoria { get; set; }

    }
}
