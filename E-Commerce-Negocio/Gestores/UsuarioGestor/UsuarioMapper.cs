using AutoMapper;
using E_Commerce_Comun.Entidades;
using E_Commerce_Negocio.DTOs.UsuarioDTOs;
using E_Commerce_Negocio.DTOs.UsuarioDTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Gestores.UsuarioGestor
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<Usuario, UsuarioDto>().ReverseMap();
            CreateMap<Usuario, CrearUsuarioRequestDto>().ReverseMap();
            CreateMap<Usuario, EditarUsuarioRequestDto>().ReverseMap();
        }
    }
}
