using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Comun.Entidades
{
    public class UsuarioIdentity : IdentityUser
    {
        [Required(ErrorMessage = "Debe seleccionar un usuario.")]
        [ForeignKey(nameof(Usuario))]
        public long IdUsuario { get; set; }
        public Usuario Usuario { get; set; }
    }
}
