using AutoMapper;
using E_Commerce_Comun.Entidades;
using E_Commerce_Negocio.DTOs.MarcaDTOs;
using E_Commerce_Negocio.DTOs.MarcaDTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Gestores.MarcaGestor
{
    public class MarcaMapper : Profile
    {
        public MarcaMapper()
        {
            CreateMap<Marca, MarcaDto>().ReverseMap();
            CreateMap<Marca, MarcaEditarDto>().ReverseMap();
            CreateMap<Marca, CrearMarcaRequestDto>().ReverseMap();
            CreateMap<Marca, EditarMarcaRequestDto>().ReverseMap();
        }
    }
}
