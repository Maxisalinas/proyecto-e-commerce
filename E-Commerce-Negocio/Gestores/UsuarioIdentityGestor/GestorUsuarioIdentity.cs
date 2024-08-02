using E_Commerce_Comun.Entidades;
using E_Commerce_Negocio.Repositorios.UsuarioIdentityRepo;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Gestores.UsuarioIdentityGestor
{
    public class GestorUsuarioIdentity : IGestorUsuarioIdentity
    {
        private readonly IRepositorioUsuarioIdentity _repo;

        public GestorUsuarioIdentity(IRepositorioUsuarioIdentity repo)
        {
            _repo = repo;
        }

        public async Task<IdentityResult> ConfirmarEmailAsync(UsuarioIdentity user, string code)
        {
            var result = await _repo.ConfirmarEmailAsync(user, code);

            return result;
        }

        public async Task<UsuarioIdentity> EncontrarPorIdAsync(string id)
        {
            var result = await _repo.EncontrarPorIdAsync(id);

            return result;
        }

        public async Task<string> GenerarTokenConfirmacionEmailAsync(UsuarioIdentity user)
        {
            var result = await _repo.GenerarTokenConfirmacionEmailAsync(user);

            return result;
        }
    }
}
