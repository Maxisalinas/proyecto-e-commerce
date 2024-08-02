using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.MarcaDTOs
{
    public class MarcaEditarDto : MarcaDto
    {
        public DateTime FechaPrimerModificacion { get; set; }
        public DateTime FechaUltimaModificacion { get; set; }

        public MarcaEditarDto()
        {
            FechaPrimerModificacion = DateTime.MinValue;
            FechaUltimaModificacion = DateTime.MinValue;
        }
    }
}
