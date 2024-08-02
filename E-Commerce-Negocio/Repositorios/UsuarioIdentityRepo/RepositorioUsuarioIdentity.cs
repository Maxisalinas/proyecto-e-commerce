using E_Commerce_Comun.Entidades;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebUtilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Repositorios.UsuarioIdentityRepo
{
    public class RepositorioUsuarioIdentity : IRepositorioUsuarioIdentity
    {
        private readonly UserManager<UsuarioIdentity> _userManager;

        public RepositorioUsuarioIdentity(UserManager<UsuarioIdentity> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> ConfirmarEmailAsync(UsuarioIdentity user, string code)
        {
            var result = await _userManager.ConfirmEmailAsync(user, code);

            return result;
        }

        public async Task<UsuarioIdentity> CrearAsync(UsuarioIdentity user, string password)
        {
            if(user == null)
            {
                return null;
            }
            
            var isCreated = await _userManager.CreateAsync(user, password);

            if (isCreated.Succeeded) 
            {
                return user;
            }

            return null;
        }

        public async Task<UsuarioIdentity> EncontrarPorEmailAsync(string email)
        {
            if(email == string.Empty)
            {
                return null;
            }

            var entity = await _userManager.FindByEmailAsync(email);

            if (entity == null)
            {
                return null;
            }

            return entity;
        }

        public async Task<UsuarioIdentity> EncontrarPorIdAsync(string id)
        {
            if (id == string.Empty)
            {
                return null;
            }

            var entity = await _userManager.FindByIdAsync(id);

            if (entity == null)
            {
                return null;
            }

            return entity;
        }

        public async Task<string> GenerarTokenConfirmacionEmailAsync(UsuarioIdentity user)
        {
            var verificationCode = await _userManager.GenerateEmailConfirmationTokenAsync(user);

            return verificationCode;
        }

        public async Task<bool> ValidarEmailYPasswordAsync(UsuarioIdentity user, string password)
        {
            if(user == null)
            {
                return false;
            }

            if(password == string.Empty)
            {
                return false;
            }

            var entity = await _userManager.CheckPasswordAsync(user, password);

            if(!entity)
            {
                return false;
            }

            return entity;
        }
    }
}
