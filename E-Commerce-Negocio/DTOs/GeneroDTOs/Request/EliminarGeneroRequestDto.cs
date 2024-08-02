using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.GeneroDTOs.Request
{
    public class EliminarGeneroRequestDto
    {
        [Required(ErrorMessage = "Debe ingresar un género.")]
        public long Id { get; set; }
    }
}
