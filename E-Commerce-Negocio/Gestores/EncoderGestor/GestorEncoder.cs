using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Gestores.EncoderGestor
{
    public class GestorEncoder : IGestorEncoder
    {
        public string DecodificarBase64(string code)
        {
            return Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
        }

        public string GenerarStringAleatorio(int size)
        {
            var random = new Random();

            var chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ$><#.";

            var response = new string(Enumerable.Repeat(chars, size).Select(s => s[random.Next(s.Length)]).ToArray());

            return response;
        }

        public string ObtenerBytes(string code)
        {
            return WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
        }


    }
}
