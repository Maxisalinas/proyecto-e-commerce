using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Gestores.EncoderGestor
{
    public interface IGestorEncoder
    {
        string ObtenerBytes(string code);
        string DecodificarBase64(string code);
        string GenerarStringAleatorio(int size);
    }
}
