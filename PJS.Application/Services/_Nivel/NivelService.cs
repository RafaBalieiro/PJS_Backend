using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PJS.Application.DTO._Nivel;
using PJS.Application.Interfaces.Services._Nivel;
using PJS.Application.Services._Base;
using PJS.Domain.Entities._Nivel;
using PJS.Domain.Interfaces.Repository._Base;
using PJS.Domain.Interfaces.Repository._UnitWork;
using PJS.Domain.Interfaces.Services;

namespace PJS.Application.Services._Nivel
{
    public class NivelService : ServiceBase<NivelEntity, NivelCreateDto, NivelUpdateDto, NivelResponseDto>, INivelService
    {
        public NivelService(
            IRepositoryBase<NivelEntity> repository,
            IMapper mapper,
            IUnitOfWork unitOfWork
        ) : base(repository, mapper, unitOfWork)
        {
        }
    }
}