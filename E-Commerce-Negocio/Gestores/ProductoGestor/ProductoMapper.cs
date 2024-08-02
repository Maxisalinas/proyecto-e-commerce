using AutoMapper;
using E_Commerce_Comun.Entidades;
using E_Commerce_Negocio.DTOs.ProductoDTOs;
using E_Commerce_Negocio.DTOs.ProductoDTOs.Request;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Gestores.ProductoGestor
{
    public class ProductoMapper : Profile
    {
        public ProductoMapper()
        {
            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<Producto, ProductoEditarDto>().ReverseMap();
            CreateMap<Producto, CrearProductoRequestDto>().ReverseMap();
            CreateMap<Producto, EditarProductoRequestDto>().ReverseMap();
        }
    }
}
