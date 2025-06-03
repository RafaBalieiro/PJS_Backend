using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PJS.Application.DTO._Nivel;
using PJS.Domain.Entities._Nivel;
using PJS.Domain.Interfaces.Services;

namespace PJS.Application.Interfaces.Services._Nivel
{
    public interface INivelService : IServiceBase<NivelEntity, NivelCreateDto, NivelUpdateDto, NivelResponseDto>
    {
    }
}