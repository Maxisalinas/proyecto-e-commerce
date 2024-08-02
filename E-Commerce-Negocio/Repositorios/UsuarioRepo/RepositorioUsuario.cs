using E_Commerce_Comun.Entidades;
using E_Commerce_Negocio.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Repositorios.UsuarioRepo
{
    public class RepositorioUsuario : IRepositorioUsuario
    {
        private readonly ApplicationDbContext _context;

        public RepositorioUsuario(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> Crear(Usuario user)
        {
            if (user == null)
            {
                return null;
            }

            user.FechaCreacion = DateTime.Now;

            var response = await _context.Usuarios.AddAsync(user);
            await _context.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<string> ObtenerNombrePorId(long id)
        {
            if(id <= 0)
            {
                return string.Empty;
            }

            var response = await _context.Usuarios.Where(u => u.Estado && u.Id == id).FirstOrDefaultAsync();

            if(response == null)
            {
                return string.Empty;
            }

            return response.Nombre;
        }

        public async Task<string> ObtenerPerfilCompletoParaTexto(long id)
        {
            if (id <= 0)
            {
                return string.Empty;
            }

            var response = await _context.Usuarios.Where(u => u.Estado && u.Id == id).FirstOrDefaultAsync();

            if (response == null)
            {
                return string.Empty;
            }

            var perfil = $@"
                                Perfil creado:
                                - Nombre completo: { response.Nombre } { response.Apellido },
                                - Fecha de creación: { response.FechaCreacion }";

            return perfil;
        }
    }
}
