using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using PJS.Application.DTO._Tarefa;
using PJS.Domain.Entities._Evento;
using PJS.Domain.Entities._Rotina;
using PJS.Domain.Entities._Tarefas;

namespace PJS.Application.Mappings._TarefaMap
{
    public class TarefaProfile : Profile
    {
        public TarefaProfile()
        {
            CreateMap<TarefaCreateDto, TarefaEntity>()
                .ForMember(dest => dest.RotinaId, opt => opt.Ignore()) // será preenchido após salvar rotina
                .ForMember(dest => dest.Rotina, opt => opt.Ignore())   // será setado manualmente
                .ConstructUsing(dto => new TarefaEntity(
                    dto.Nome,
                    dto.CategoriaTarefa,
                    dto.NivelConhecimento,
                    dto.Status,
                    dto.Dificuldade,
                    dto.TempoEstimado,
                    dto.PerfilId,
                    Guid.Empty // rotinaId será definido após persistência
                ));

            CreateMap<RotinaCreateDto, RotinaEntity>()
                .ConstructUsing(dto => new RotinaEntity(
                    dto.DataInicial,
                    dto.DataFinal,
                    dto.Periodicidade,
                    dto.Status
                ));

            CreateMap<EventoCreateDto, EventoEntity>()
                .ConstructUsing(dto => new EventoEntity(
                    dto.DataExecucao,
                    dto.DataFinalizacao,
                    dto.Status,
                    Guid.Empty // rotinaId será atribuído pela entidade de domínio
                ));
        }
    }
}