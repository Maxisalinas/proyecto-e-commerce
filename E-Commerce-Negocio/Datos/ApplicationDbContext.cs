using E_Commerce_Comun.Entidades;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_Negocio.Datos
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        // Aquí establecer todos los DbSets<T>.
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<UsuarioIdentity> UsuariosIdentity { get; set; }
    }
}
