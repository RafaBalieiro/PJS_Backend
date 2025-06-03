using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PJS.Application.DTO._Conquista;
using PJS.Domain.Entities._Conquista;
using PJS.Domain.Interfaces.Services;

namespace PJS.Application.Interfaces.Services._Conquista
{
    public interface IConquistaService : IServiceBase<ConquistaEntity, ConquistaCreateDto, ConquistaUpdateDto, ConquistaResponseDto>
    {
        Task<ConquistaResponseDto> CreateAsync(ConquistaCreateDto dto);
    }
}