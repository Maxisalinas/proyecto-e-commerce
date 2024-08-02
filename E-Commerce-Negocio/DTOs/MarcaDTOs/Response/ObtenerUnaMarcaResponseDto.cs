using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.MarcaDTOs.Response
{
    public class ObtenerUnaMarcaResponseDto : ResponseHttp
    {
        public ObtenerUnaMarcaResponseDto() : base()
        {
            Marca = new MarcaDto();
        }

        public MarcaDto Marca { get; set; }
    }
}
