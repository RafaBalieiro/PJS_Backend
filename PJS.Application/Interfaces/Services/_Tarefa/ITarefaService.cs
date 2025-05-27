using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PJS.Application.DTO._Tarefa;
using PJS.Domain.Entities._Tarefas;
using PJS.Domain.Interfaces.Services;

namespace PJS.Application.Interfaces.Services._Tarefa
{
    public interface ITarefaService : IServiceBase<TarefaEntity>
    {
        Task<TarefaEntity> CriarTarefaCompletaAsync(TarefaCompletaCreateDto dto);
    }
}