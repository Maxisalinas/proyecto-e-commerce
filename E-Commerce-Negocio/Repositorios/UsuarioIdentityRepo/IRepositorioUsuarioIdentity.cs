using E_Commerce_Comun.Entidades;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Repositorios.UsuarioIdentityRepo
{
    public interface IRepositorioUsuarioIdentity
    {
        Task<UsuarioIdentity> CrearAsync(UsuarioIdentity user, string password);
        Task<IdentityResult> ConfirmarEmailAsync(UsuarioIdentity user, string code);
        Task<UsuarioIdentity> EncontrarPorEmailAsync(string email);
        Task<UsuarioIdentity> EncontrarPorIdAsync(string id);
        Task<bool> ValidarEmailYPasswordAsync(UsuarioIdentity user, string password);
        Task<string> GenerarTokenConfirmacionEmailAsync(UsuarioIdentity user);
    }
}
