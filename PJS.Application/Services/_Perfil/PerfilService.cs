using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PJS.Application.DTO._Usuario._Perfil;
using PJS.Application.Interfaces.Services._Perfil;
using PJS.Application.Services._Base;
using PJS.Domain.Entities._Perfil;
using PJS.Domain.Interfaces.Repository._Base;
using PJS.Domain.Interfaces.Repository._Perfil;

namespace PJS.Application.Services._Perfil
{
    public class PerfilService : ServiceBase<PerfilEntity>, IPerfilService
    {

        private readonly IPerfilRepository _repository;
        private readonly IMapper _mapper;
        public PerfilService(IPerfilRepository repository, IMapper mapper) : base(repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<PerfilResponseDto> ObterPerfilPorUsuarioIdAsync(Guid usuarioId)
        {
            var perfil = await _repository.GetByUsuarioIdAsync(usuarioId);

            if (perfil == null)
                return null;

            return _mapper.Map<PerfilResponseDto>(perfil);
        }
    }
}