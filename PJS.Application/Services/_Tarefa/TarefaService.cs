using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PJS.Application.DTO._Tarefa;
using PJS.Application.Interfaces.Services._Tarefa;
using PJS.Application.Services._Base;
using PJS.Domain.Entities._Evento;
using PJS.Domain.Entities._Rotina;
using PJS.Domain.Entities._Tarefas;
using PJS.Domain.Interfaces.Repository._Base;
using PJS.Domain.Interfaces.Repository._Tarefa;
using PJS.Domain.Interfaces.Repository._UnitWork;

namespace PJS.Application.Services._Tarefa
{
    public class TarefaService : ServiceBase<TarefaEntity, TarefaCreateDto, TarefaUpdateDto, TarefaResponseDto>, ITarefaService
    {
        private readonly ITarefaRepository _repository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TarefaService(ITarefaRepository repository, IUnitOfWork unitOfWork, IMapper mapper) : base(repository, mapper, unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<TarefaEntity> CriarTarefaCompletaAsync(TarefaCreateDto dto)
        {
            await _unitOfWork.BeginTransactionAsync();

            try
            {
                var rotinaDto = dto.Rotina;

                var rotina = new RotinaEntity(
                    rotinaDto.DataInicial,
                    rotinaDto.DataFinal,
                    rotinaDto.Periodicidade,
                    rotinaDto.Status
                );

                foreach (var eventoDto in rotinaDto.Eventos)
                {
                    var evento = new EventoEntity(
                        eventoDto.DataExecucao,
                        eventoDto.DataFinalizacao,
                        eventoDto.Status,
                        rotina.Id
                    );

                    rotina.Eventos.Add(evento);
                }

                var tarefa = new TarefaEntity(
                    dto.Nome,
                    dto.CategoriaTarefa,
                    dto.NivelConhecimento,
                    dto.Status,
                    dto.Dificuldade,
                    dto.TempoEstimado,
                    dto.PerfilId,
                    rotina.Id
                );

                typeof(TarefaEntity).GetProperty(nameof(TarefaEntity.Rotina))?.SetValue(tarefa, rotina);

                await _repository.AddAsync(tarefa);
                await _unitOfWork.CommitAsync();

                return tarefa;
            }
            catch
            {
                await _unitOfWork.RollbackAsync();
                throw;
            }
        }
    }
}