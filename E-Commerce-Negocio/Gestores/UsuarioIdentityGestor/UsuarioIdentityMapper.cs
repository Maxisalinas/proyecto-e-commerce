using AutoMapper;
using E_Commerce_Comun.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Negocio.Gestores.UsuarioIdentityGestor
{
    public class UsuarioIdentityMapper : Profile
    {
        public UsuarioIdentityMapper()
        {
            CreateMap<UsuarioIdentity, Usuario>().ReverseMap();
        }
    }
}
