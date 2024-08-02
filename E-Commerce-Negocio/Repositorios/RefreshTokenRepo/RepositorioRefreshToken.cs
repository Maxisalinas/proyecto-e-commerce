using E_Commerce_Comun.Entidades;
using E_Commerce_Negocio.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Repositorios.RefreshTokenRepo
{
    public class RepositorioRefreshToken : IRepositorioRefreshToken
    {
        private readonly ApplicationDbContext _context;

        public RepositorioRefreshToken(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<RefreshToken> Actualizar(RefreshToken token)
        {
            if(token == null)
            {
                return null;
            }

            var entidad = _context.RefreshTokens.Update(token);
            
            if(entidad == null)
            {
                return null;
            }

            await _context.SaveChangesAsync();

            return entidad.Entity;
        }

        public async Task<RefreshToken> Crear(RefreshToken token)
        {
            if(token == null)
            {
                return null;
            }
            
            var entidad = await _context.RefreshTokens.AddAsync(token);
            await _context.SaveChangesAsync();

            return entidad.Entity;
        }

        public async Task<RefreshToken> ObtenerUno(string token)
        {
            if(token == null)
            {
                return null;
            }

            var tokenFinded = await _context.RefreshTokens.FirstOrDefaultAsync(t => t.Token == token);

            if(tokenFinded == null)
            {
                return null;
            }

            return tokenFinded;
        }
    }
}
