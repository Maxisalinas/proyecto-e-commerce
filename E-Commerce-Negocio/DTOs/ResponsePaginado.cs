using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs
{
    public class ResponsePaginado : ResponseHttp
    {
        public int Pagina { get; set; }
        public int ResultadosPorPagina { get; set; }
        public int TotalPaginas { get; set; }
        public int TotalResultados { get; set; }

        public ResponsePaginado() : base()
        {
            Pagina = 0;
            ResultadosPorPagina = 0;
            TotalPaginas = 0;
            TotalResultados = 0;
        }
    }
}
