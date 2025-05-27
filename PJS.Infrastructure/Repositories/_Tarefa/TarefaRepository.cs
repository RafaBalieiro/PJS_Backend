using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PJS.Domain.Entities._Tarefas;
using PJS.Domain.Interfaces.Repository._Tarefa;
using PJS.Infrastructure.Data.Context;
using PJS.Infrastructure.Repositories._Base;

namespace PJS.Infrastructure.Repositories._Tarefa
{
    public class TarefaRepository : RepositoryBase<TarefaEntity>, ITarefaRepository
    {
        public TarefaRepository(AppDbContext context) : base(context)
        {
        }
    }
}