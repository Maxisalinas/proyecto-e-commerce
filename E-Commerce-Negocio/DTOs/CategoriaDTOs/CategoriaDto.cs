using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.CategoriaDTOs
{
    public class CategoriaDto
    {
        public long Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaCreacion { get; set; }
        public bool Estado { get; set; }

        public CategoriaDto()
        {
            Id = 0;
            Nombre = string.Empty;
            FechaCreacion = DateTime.MinValue;
            Estado = false;
        }
    }
}
