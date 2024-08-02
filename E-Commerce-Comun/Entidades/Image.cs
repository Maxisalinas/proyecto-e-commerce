using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Comun.Entidades
{
    public class Image : EntidadBase
    {
        public string UrlLocal { get; set; } = string.Empty;
        [ForeignKey(nameof(Producto))]
        public long IdProducto { get; set; }
        public Producto Producto { get; set; }
    }
}
