using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.MarcaDTOs.Request
{
    public class ObtenerUnaMarcaRequestDto
    {
        [Required(ErrorMessage = "Debe ingresar una marca.")]
        public long Id { get; set; }
    }
}
