using E_Commerce_Comun.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.DTOs
{
    public class ResponseHttp
    {
        public HttpStatusCode StatusCode { get; set; }
        public List<Mensaje> Mensajes { get; set; }

        public ResponseHttp()
        {
            StatusCode = 0;
            Mensajes = new List<Mensaje>();
        }
    }
}
