using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.GeneroDTOs.Response
{
    public class EditarGeneroResponseDto : ResponseHttp
    {
        public EditarGeneroResponseDto() : base()
        {
            Genero = new GeneroEditarDto();
        }

        public GeneroEditarDto Genero { get; set; }

    }
}
