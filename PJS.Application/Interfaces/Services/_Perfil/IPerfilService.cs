using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PJS.Application.DTO._Perfil;
using PJS.Application.DTO._Usuario._Perfil;
using PJS.Domain.Entities._Perfil;
using PJS.Domain.Interfaces.Services;

namespace PJS.Application.Interfaces.Services._Perfil
{
    public interface IPerfilService : IServiceBase<PerfilEntity, PerfilCreateDto, PerfilUpdateDto, PerfilResponseDto>
    {
        Task<PerfilResponseDto> ObterPerfilPorUsuarioIdAsync(Guid usuarioId);
    }
}