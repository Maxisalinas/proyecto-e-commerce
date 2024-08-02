using E_Commerce_Comun.Entidades;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Gestores.UsuarioIdentityGestor
{
    public interface IGestorUsuarioIdentity
    {
        Task<string> GenerarTokenConfirmacionEmailAsync(UsuarioIdentity user);
        Task<UsuarioIdentity> EncontrarPorIdAsync(string id);
        Task<IdentityResult> ConfirmarEmailAsync(UsuarioIdentity user, string code);
    }
}
