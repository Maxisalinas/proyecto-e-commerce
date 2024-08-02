using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.MarcaDTOs
{
    public class MarcaDto
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public string LogoImageUrl { get; set; }
        public bool Estado { get; set; }

        public MarcaDto()
        {
            Id = 0;
            Nombre = string.Empty;
            FechaCreacion = DateTime.MinValue;
            LogoImageUrl = string.Empty;
            Estado = false;
        }
    }
}
