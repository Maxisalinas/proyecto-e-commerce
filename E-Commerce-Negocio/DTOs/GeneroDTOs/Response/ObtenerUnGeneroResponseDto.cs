using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.GeneroDTOs.Response
{
    public class ObtenerUnGeneroResponseDto : ResponseHttp
    {
        public ObtenerUnGeneroResponseDto() : base()
        {
            Genero = new GeneroDto();
        }

        public GeneroDto Genero { get; set; }
    }
}
