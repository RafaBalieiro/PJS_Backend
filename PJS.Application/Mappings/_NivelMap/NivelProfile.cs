using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PJS.Application.DTO._Nivel;
using PJS.Domain.Entities._Nivel;

namespace PJS.Application.Mappings._NivelMap
{
    public class NivelProfile : Profile
    {
        public NivelProfile()
        {
            CreateMap<NivelCreateDto, NivelEntity>();
            CreateMap<NivelUpdateDto, NivelEntity>();
            CreateMap<NivelEntity, NivelResponseDto>();
        }
    }
}