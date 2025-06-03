using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PJS.Application.DTO._Conquista;
using PJS.Application.Interfaces.Services._Conquista;
using PJS.Application.Services._Base;
using PJS.Domain.Entities._Conquista;
using PJS.Domain.Interfaces.Repository._Base;
using PJS.Domain.Interfaces.Repository._UnitWork;

namespace PJS.Application.Services._Conquista
{
    public class ConquistaService : ServiceBase<ConquistaEntity, ConquistaCreateDto, ConquistaUpdateDto, ConquistaResponseDto>, IConquistaService
    {
        public ConquistaService(
            IRepositoryBase<ConquistaEntity> repository,
            IMapper mapper,
            IUnitOfWork unitOfWork
        ) : base(repository, mapper, unitOfWork)
        {
        }
    }
}