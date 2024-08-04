    using E_Commerce_Comun.Entidades;
using E_Commerce_Negocio.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Repositorios.ProductoRepo
{
    public class RepositorioProducto : IRepositorioProducto
    {
        private readonly ApplicationDbContext _context;

        public RepositorioProducto(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Producto>> Buscador(string criterioBusqueda, int pageSize, int pageNumber)
        {
            //var response = await _context.Productos
            //    .Where(p => p.Estado &&
            //          (p.Nombre.Contains(criterioBusqueda) ||
            //           p.Modelo.Contains(criterioBusqueda) ||
            //           p.Marca.Nombre.Contains(criterioBusqueda) ||
            //           p.Categoria.Nombre.Contains(criterioBusqueda) ||
            //           p.Genero.Nombre.Contains(criterioBusqueda) ||
            //           p.Descripcion.Contains(criterioBusqueda)))
            //    .Include(p => p.Marca)
            //    .Include(p => p.Categoria)
            //    .Include(p => p.Genero)
            //    .Skip((pageNumber - 1) * pageSize)
            //    .Take(pageSize)
            //    .AsNoTracking()
            //    .ToListAsync();

            var resultados = await Buscar(criterioBusqueda, pageSize, pageNumber);
            var response = resultados.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToList();

            return response;
        }

        public async Task<List<Producto>> Buscar(string criterioBusqueda, int pageSize, int pageNumber)
        {
            var results = await _context.Productos
                .Where(p => p.Estado &&
                      (p.Nombre.Contains(criterioBusqueda) ||
                       p.Modelo.Contains(criterioBusqueda) ||
                       p.Marca.Nombre.Contains(criterioBusqueda) ||
                       p.Categoria.Nombre.Contains(criterioBusqueda) ||
                       p.Genero.Nombre.Contains(criterioBusqueda) ||
                       p.Descripcion.Contains(criterioBusqueda)))
                .Include(p => p.Marca)
                .Include(p => p.Categoria)
                .Include(p => p.Genero)
                .AsNoTracking()
                .ToListAsync();

            return results;
        }

        public async Task<Producto> Crear(Producto producto)
        {
            if (producto == null)
            {
                return null;
            }

            producto.FechaCreacion = DateTime.Now;

            var response = await _context.Productos.AddAsync(producto);
            await _context.SaveChangesAsync();
            return response.Entity;
        }

        public async Task<List<Producto>> CrearMasivo(List<Producto> productos)
        {
            var response = new List<Producto>();
            
            if(productos == null)
            {
                return null;
            }

            //productos.ForEach(async (producto) =>
            //{
            //    var result = await Crear(producto);

            //    response.Add(result);
            //});
            foreach (var producto in productos)
            {
                var result = await Crear(producto);

                response.Add(result);
            }


            return response;
        }

        public async Task<Producto> Editar(Producto producto)
        {
            var entidad = await ObtenerUnoPorId(producto.Id);

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

                entidad.Nombre = producto.Nombre;
                entidad.Modelo = producto.Modelo;
                var marca = await _context.Marcas.Where(m => m.Estado && m.Id == producto.IdMarca).FirstOrDefaultAsync();
                entidad.IdMarca = marca.Id;
                var categoria = await _context.Categorias.Where(c => c.Estado && c.Id == producto.IdCategoria).FirstOrDefaultAsync();
                entidad.IdCategoria = categoria.Id;
                entidad.Descripcion = producto.Descripcion;
                entidad.Precio = producto.Precio;
                entidad.Talle = producto.Talle;
                var genero = await _context.Generos.Where(g => g.Estado && g.Id == producto.IdGenero).FirstOrDefaultAsync();
                entidad.IdGenero = genero.Id;
                entidad.ImageUrl = producto.ImageUrl;
                await _context.SaveChangesAsync();

                return entidad;
            }

            return null;

        }

        public async Task<Producto> Eliminar(long id)
        {
            if (id <= 0)
            {
                return null;
            }

            var entidad = await _context.Productos.Where(p => p.Estado && p.Id == id).FirstOrDefaultAsync();

            if (entidad == null)
            {
                return null;
            }

            entidad.Estado = false;
            entidad.FechaEliminacion = DateTime.Now;
            await _context.SaveChangesAsync();

            return entidad;
        }

        public async Task<Producto> ObtenerUnoPorId(long id)
        {
            if (id <= 0)
            {
                return null;
            }
            var response = await _context.Productos.Where(c => c.Estado && c.Id == id).FirstOrDefaultAsync();

            return response;
        }
    }
}
