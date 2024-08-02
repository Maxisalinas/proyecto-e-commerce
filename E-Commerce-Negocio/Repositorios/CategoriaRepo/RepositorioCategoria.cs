using E_Commerce_Comun.Entidades;
using E_Commerce_Negocio.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Repositorios.CategoriaRepo
{
    public class RepositorioCategoria : IRepositorioCategoria
    {
        private readonly ApplicationDbContext _context;

        public RepositorioCategoria(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Categoria> Crear(Categoria categoria)
        {
            if(categoria == null)
            {
                return null;
            } 

            categoria.FechaCreacion = DateTime.Now;

            var response = await _context.Categorias.AddAsync(categoria);
            await _context.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<Categoria> Editar(Categoria categoria)
        {
            var entidad = await ObtenerUnaPorId(categoria.Id);

            if(entidad != null)
            {
                if(entidad.FechaPrimerModificacion != DateTime.MinValue)
                {
                    entidad.FechaUltimaModificacion = DateTime.Now;
                }
                else
                {
                    entidad.FechaPrimerModificacion = DateTime.Now;
                }

                entidad.Nombre = categoria.Nombre;

                await _context.SaveChangesAsync();

                return entidad;
            }

            return null;

        }

        public async Task<Categoria> Eliminar(long id)
        {
            if(id <= 0)
            {
                return null;
            }

            var entidad = await _context.Categorias.Where(c => c.Estado && c.Id == id).FirstOrDefaultAsync();

            if(entidad == null)
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

            var entidad = await _context.Categorias.Where(c => c.Estado && c.Id == id).FirstOrDefaultAsync();

            return entidad != null ? true : false;
        }

        public async Task<bool> ExistePorNombre(string value)
        {
            if(value == string.Empty)
            {
                return false;
            }
            
            var entidad = await _context.Categorias.Where(c => c.Estado && c.Nombre == value).FirstOrDefaultAsync();

            return entidad != null ? true : false;
        }

        public async Task<List<Categoria>> ObtenerTodas()
        {
            var response = await _context.Categorias.Where(c => c.Estado).ToListAsync();

            return response;
        }

        public async Task<Categoria> ObtenerUnaPorId(long id)
        {
            if(id <= 0)
            {
                return null;
            }
            var response = await _context.Categorias.Where(c => c.Estado && c.Id == id).FirstOrDefaultAsync();

            return response;
        }
    }
}
