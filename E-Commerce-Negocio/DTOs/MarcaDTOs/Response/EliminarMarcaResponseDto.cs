using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.MarcaDTOs.Response
{
    public class EliminarMarcaResponseDto : ResponseHttp
    {
        public EliminarMarcaResponseDto() : base()
        {
            Marca = new MarcaDto();
        }

        public MarcaDto Marca { get; set; }
    }
}
