using E_Commerce_Comun.Entidades;
using E_Commerce_Negocio.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Repositorios.MarcaRepo
{
    public class RepositorioMarca : IRepositorioMarca
    {
        private readonly ApplicationDbContext _context;

        public RepositorioMarca(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Marca> Crear(Marca marca)
        {
            if (marca == null)
            {
                return null;
            }

            marca.FechaCreacion = DateTime.Now;

            var response = await _context.Marcas.AddAsync(marca);
            await _context.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<Marca> Editar(Marca marca)
        {
            var entidad = await ObtenerUnaPorId(marca.Id);

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

                entidad.Nombre = marca.Nombre;
                entidad.LogoImageUrl = marca.LogoImageUrl;

                await _context.SaveChangesAsync();

                return entidad;
            }

            return null;
        }

        public async Task<Marca> Eliminar(long id)
        {
            if (id <= 0)
            {
                return null;
            }

            var entidad = await _context.Marcas.Where(c => c.Estado && c.Id == id).FirstOrDefaultAsync();

            if (entidad == null)
            {
                return null;
            }

            entidad.Estado = false;
            entidad.FechaEliminacion = DateTime.Now;
            await _context.SaveChangesAsync();

            return entidad;
        }

        public async Task<bool> ExistePorId(long id)
        {
            if (id <= 0)
            {
                return false;
            }

            var entidad = await _context.Marcas.Where(c => c.Estado && c.Id == id).FirstOrDefaultAsync();

            return entidad != null ? true : false;
        }

        public async Task<bool> ExistePorNombre(string value)
        {
            if (value == string.Empty)
            {
                return false;
            }

            var entidad = await _context.Marcas.Where(c => c.Estado && c.Nombre == value).FirstOrDefaultAsync();

            return entidad != null ? true : false;
        }

        public async Task<List<Marca>> ObtenerTodas()
        {
            var response = await _context.Marcas.Where(c => c.Estado).ToListAsync();

            return response;
        }

        public async Task<Marca> ObtenerUnaPorId(long id)
        {
            if (id <= 0)
            {
                return null;
            }
            var response = await _context.Marcas.Where(c => c.Estado && c.Id == id).FirstOrDefaultAsync();

            return response;
        }
    }
}
