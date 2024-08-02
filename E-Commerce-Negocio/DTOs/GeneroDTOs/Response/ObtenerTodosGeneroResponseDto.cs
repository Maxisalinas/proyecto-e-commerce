using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.GeneroDTOs.Response
{
    public class ObtenerTodosGeneroResponseDto : ResponsePaginado
    {
        public ObtenerTodosGeneroResponseDto() : base()
        {
            Generos = new List<GeneroDto>();
        }

        public List<GeneroDto> Generos { get; set; }
    }
}
