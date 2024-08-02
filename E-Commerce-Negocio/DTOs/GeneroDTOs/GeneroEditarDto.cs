using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.GeneroDTOs
{
    public class GeneroEditarDto : GeneroDto
    {
        public DateTime FechaPrimerModificacion { get; set; }
        public DateTime FechaUltimaModificacion { get; set; }

        public GeneroEditarDto()
        {
            FechaPrimerModificacion = DateTime.MinValue;
            FechaUltimaModificacion = DateTime.MinValue;
        }
    }
}
