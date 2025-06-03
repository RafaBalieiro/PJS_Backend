using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PJS.Application.DTO._Perfil;
using PJS.Application.DTO._Usuario._Perfil;
using PJS.Domain.Entities._Perfil;

namespace PJS.Application.Mappings._PerfilMap
{
    public class PerfilProfile : Profile
    {
        public PerfilProfile()
        {
            CreateMap<PerfilEntity, PerfilResponseDto>();
            CreateMap<PerfilCreateDto, PerfilEntity>();
            CreateMap<PerfilEntity, PerfilCreateDto>();
        }
    }
}