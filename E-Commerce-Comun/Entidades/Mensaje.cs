using E_Commerce_Comun.Sealed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Comun.Entidades
{
    public class Mensaje
    {
        public string Message { get; set; }
        public string Class { get; set; }
        public string Type { get; set; }

        public Mensaje()
        {
            Message = string.Empty;
            Class = MessageClass.Default;
            Type = string.Empty;
        }

        public Mensaje(string value, string clase, string type)
        {
            Message = value;
            Class = clase;
            Type = type;
        }
    }
}
