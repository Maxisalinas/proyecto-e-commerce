using AutoMapper;
using E_Commerce_Comun.Entidades;
using E_Commerce_Negocio.DTOs.CategoriaDTOs;
using E_Commerce_Negocio.DTOs.CategoriaDTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Gestores.CategoriaGestor
{
    public class CategoriaMapper : Profile
    {
        public CategoriaMapper()
        {
            CreateMap<Categoria, CategoriaDto>().ReverseMap();
            CreateMap<Categoria, CategoriaEditarDto>().ReverseMap();
            CreateMap<Categoria, CrearCategoriaRequestDto>().ReverseMap();
            CreateMap<Categoria, EditarCategoriaRequestDto>().ReverseMap();
        }
    }
}
