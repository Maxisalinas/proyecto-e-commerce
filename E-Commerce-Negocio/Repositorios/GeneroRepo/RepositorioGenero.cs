using E_Commerce_Comun.Entidades;
using E_Commerce_Negocio.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Repositorios.GeneroRepo
{
    public class RepositorioGenero : IRepositorioGenero
    {
        private readonly ApplicationDbContext _context;

        public RepositorioGenero(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Genero> Crear(Genero genero)
        {
            if (genero == null)
            {
                return null;
            }

            genero.FechaCreacion = DateTime.Now;
            genero.Abreviacion = genero.Nombre.Substring(0, 4).ToUpper();
            genero.Sigla = genero.Nombre.Substring(0, 1).ToUpper();

            var response = await _context.Generos.AddAsync(genero);
            await _context.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<Genero> Editar(Genero genero)
        {
            var entidad = await ObtenerUnoPorId(genero.Id);

            if (entidad != null)
            {
                if (entidad.FechaPrimerModificacion != DateTime.MinValue)
                {
                    entidad.FechaUltimaModificacion = DateTime.Now;
                }
                else
                {
                    entidad.FechaPrimerModificacion = DateTime.Now;
                }

                entidad.Nombre = genero.Nombre;
                entidad.Abreviacion = genero.Abreviacion.ToUpper();
                entidad.Sigla = genero.Sigla.ToUpper();

                await _context.SaveChangesAsync();

                return entidad;
            }

            return null;
        }

        public async Task<Genero> Eliminar(long id)
        {
            if (id <= 0)
            {
                return null;
            }

            var entidad = await _context.Generos.Where(c => c.Estado && c.Id == id).FirstOrDefaultAsync();

            if (entidad == null)
            {
                return null;
            }

            entidad.Estado = false;
            entidad.FechaEliminacion = DateTime.Now;
            await _context.SaveChangesAsync();

            return entidad;
        }

        public async Task<List<Genero>> ObtenerTodos()
        {
            var response = await _context.Generos.Where(c => c.Estado).ToListAsync();

            return response;
        }

        public async Task<Genero> ObtenerUnoPorId(long id)
        {
            if (id <= 0)
            {
                return null;
            }
            var response = await _context.Generos.Where(c => c.Estado && c.Id == id).FirstOrDefaultAsync();

            return response;
        }
    }
}
