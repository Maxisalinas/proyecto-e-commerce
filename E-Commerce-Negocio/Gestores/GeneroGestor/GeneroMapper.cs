using AutoMapper;
using E_Commerce_Comun.Entidades;
using E_Commerce_Negocio.DTOs.GeneroDTOs;
using E_Commerce_Negocio.DTOs.GeneroDTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Gestores.GeneroGestor
{
    public class GeneroMapper : Profile
    {
        public GeneroMapper()
        {
            CreateMap<Genero, GeneroDto>().ReverseMap();
            CreateMap<Genero, GeneroEditarDto>().ReverseMap();
            CreateMap<Genero, CrearGeneroRequestDto>().ReverseMap();
            CreateMap<Genero, EditarGeneroRequestDto>().ReverseMap();
        }
    }
}
