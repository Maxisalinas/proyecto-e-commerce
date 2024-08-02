using AutoMapper;
using E_Commerce_Comun.Entidades;
using E_Commerce_Negocio.Gestores.ProductoG.DTOs;
using E_Commerce_Negocio.Gestores.ProductoG.DTOs.Request;
using E_Commerce_Negocio.Gestores.ProductoG.DTOs.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Gestores.ProductoG
{
    public class ProductoMapper : Profile
    {
        public ProductoMapper()
        {
            CreateMap<Producto, ProductoDto>().ReverseMap();
            CreateMap<Producto, CrearProductoRequestDto>().ReverseMap();
            CreateMap<Producto, CrearProductoResponseDto>().ReverseMap();
        }
    }
}
