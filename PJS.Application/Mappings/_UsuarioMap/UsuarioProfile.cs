using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PJS.Application.DTO._Usuario;
using PJS.Domain.Entities._Usuario;

namespace PJS.Application.Mappings._UsuarioMap
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<UsuarioEntity, UsuarioResponseDto>();

            CreateMap<UsuarioCreateDto, UsuarioEntity>();
        }
    }
}