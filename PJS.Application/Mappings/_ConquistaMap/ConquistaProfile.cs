using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PJS.Application.DTO._Conquista;
using PJS.Domain.Entities._Conquista;

namespace PJS.Application.Mappings._ConquistaMap
{
    public class ConquistaProfile : Profile
    {
        public ConquistaProfile()
        {
            CreateMap<ConquistaEntity, ConquistaCreateDto>();
            CreateMap<ConquistaCreateDto, ConquistaEntity>();

            CreateMap<ConquistaEntity, ConquistaResponseDto>();
            CreateMap<ConquistaResponseDto, ConquistaEntity>();
        }
    }
}