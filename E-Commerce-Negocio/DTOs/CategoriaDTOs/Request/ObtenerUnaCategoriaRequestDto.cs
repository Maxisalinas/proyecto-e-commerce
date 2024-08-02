using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.CategoriaDTOs.Request
{
    public class ObtenerUnaCategoriaRequestDto
    {
        [Required(ErrorMessage = "Debe ingresar una categoría.")]
        public long Id { get; set; }
    }
}
