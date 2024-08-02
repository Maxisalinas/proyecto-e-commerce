using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Comun.Entidades
{
    public abstract class EntidadBase
    {
        [Key]
        public long Id { get; set; }
        [DataType(DataType.DateTime)]
        [Required]
        public DateTime FechaCreacion { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime FechaPrimerModificacion { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime FechaUltimaModificacion { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime FechaEliminacion { get; set; }
        [Required]
        public bool Estado { get; set; } = true;
    }
}
