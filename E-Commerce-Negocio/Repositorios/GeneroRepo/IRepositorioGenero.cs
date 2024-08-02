using E_Commerce_Comun.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Repositorios.GeneroRepo
{
    public interface IRepositorioGenero
    {
        Task<Genero> Crear(Genero genero);
        Task<Genero> Editar(Genero genero);
        Task<Genero> Eliminar(long id);
        Task<List<Genero>> ObtenerTodos();
        Task<Genero> ObtenerUnoPorId(long id);
    }
}
