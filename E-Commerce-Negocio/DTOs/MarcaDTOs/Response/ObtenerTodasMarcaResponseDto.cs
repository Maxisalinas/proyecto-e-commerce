using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.MarcaDTOs.Response
{
    public class ObtenerTodasMarcaResponseDto : ResponsePaginado
    {
        public ObtenerTodasMarcaResponseDto() : base()
        {
            Marcas = new List<MarcaDto>();
        }

        public List<MarcaDto> Marcas { get; set; }
    }
}
