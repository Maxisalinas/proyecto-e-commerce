using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.CategoriaDTOs
{
    public class CategoriaEditarDto : CategoriaDto
    {
        public DateTime FechaPrimerModificacion { get; set; }
        public DateTime FechaUltimaModificacion { get; set; }

        public CategoriaEditarDto()
        {
            FechaPrimerModificacion = DateTime.MinValue;
            FechaUltimaModificacion = DateTime.MinValue;
        }
    }
}
