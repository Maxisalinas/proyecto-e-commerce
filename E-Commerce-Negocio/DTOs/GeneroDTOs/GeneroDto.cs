using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.GeneroDTOs
{
    public class GeneroDto
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public string Abreviacion { get; set; }
        public string Sigla { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }

        public GeneroDto()
        {
            Id = 0;
            Nombre = string.Empty;
            Abreviacion = string.Empty;
            Sigla = string.Empty;
            FechaCreacion = DateTime.MinValue;
            Estado = false;
        }
    }
}
