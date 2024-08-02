using E_Commerce_Comun.Entidades;
using E_Commerce_Negocio.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Repositorios.ProductoR
{
    public class RepositorioCategoria : IRepositorioCategoria
    {
        private readonly ApplicationDbContext _context;

        public RepositorioCategoria(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> Buscador(string filtro, int pageNumber = 1, int pageSize = 12)
        {
            var entidades = await _context.Productos.Where(x => 
                x.Estado &&
                x.Modelo.Contains(filtro) || 
                x.Descripcion.Contains(filtro) || 
                x.Categoria.Nombre.Contains(filtro) ||
                x.Marca.Nombre.Contains(filtro)
            )
            .Include(p => p.Marca)
            .Include(p => p.Categoria)
            .Include(p => p.Genero)
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize)
            .AsNoTracking()
            .ToListAsync();

            return entidades;
        }

        public async Task<Producto> Crear(Producto producto)
        {
            producto.Marca = _context.Marcas.Where(marca => marca.Estado && marca.Id == producto.IdMarca).FirstOrDefault();
            producto.Categoria = _context.Categorias.Where(categoria => categoria.Estado && categoria.Id == producto.IdCategoria).FirstOrDefault();
            producto.Genero = _context.Generos.Where(genero => genero.Estado && genero.Id == producto.IdGenero).FirstOrDefault();
            producto.FechaCreacion = DateTime.Now;

            var response = _context.Productos.Add(producto);
            await _context.SaveChangesAsync();

            return response.Entity;
        }

        public Task<List<Producto>> CrearMasivo(List<Producto> productos)
        {
            throw new NotImplementedException();
        }

        public Task<Producto> Editar(Producto producto)
        {
            throw new NotImplementedException();
        }

        public async Task<Producto> Eliminar(long id)
        {
            var entidad = _context.Productos.Where(x => x.Estado && x.Id == id).FirstOrDefault();
            if (entidad != null)
            {
                entidad.Estado = false;
                entidad.FechaEliminacion = DateTime.Now;
                _context.Productos.Update(entidad);
                await _context.SaveChangesAsync();
            };

            return entidad;
        }

        public async Task<List<Producto>> ObtenerTodos()
        {
            return await _context.Productos.Where(p=> p.Estado).ToListAsync();
        }

        public Task<Producto> ObtenerUnoPorId(long id)
        {
            return _context.Productos.Where(p => p.Estado && p.Id == id)
                                     .Include(p => p.Marca)
                                     .Include(p => p.Categoria)
                                     .Include(p => p.Genero)
                                     .AsNoTracking()
                                     .FirstOrDefaultAsync();
        }

        public async Task<bool> ValidarExistenciaPorId(long id)
        {
            var producto = await _context.Productos.Where(p => p.Estado && p.Id == id)
                                                   .AsNoTracking()
                                                   .FirstOrDefaultAsync();
            if(producto != null)
            {
                return true;
            }

            return false;
        }

        public async Task<bool> ValidarExistenciaPorTexto(string value)
        {
            var producto = await _context.Productos.Where(p => p.Estado && p.Modelo == value)
                                                   .AsNoTracking()
                                                   .FirstOrDefaultAsync();
            if (producto != null)
            {
                return true;
            }

            return false;
        }
    }
}
