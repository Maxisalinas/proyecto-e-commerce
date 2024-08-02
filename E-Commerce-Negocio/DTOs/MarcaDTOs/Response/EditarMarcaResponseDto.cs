using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs.MarcaDTOs.Response
{
    public class EditarMarcaResponseDto : ResponseHttp
    {
        public EditarMarcaResponseDto() : base()
        {
            Marca = new MarcaEditarDto();
        }

        public MarcaEditarDto Marca { get; set; }
    }
}
