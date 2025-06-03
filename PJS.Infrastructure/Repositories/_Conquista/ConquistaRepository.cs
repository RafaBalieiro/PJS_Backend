using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PJS.Domain.Entities._Conquista;
using PJS.Domain.Interfaces.Repository._Conquista;
using PJS.Infrastructure.Data.Context;
using PJS.Infrastructure.Repositories._Base;

namespace PJS.Infrastructure.Repositories._Conquista
{
    public class ConquistaRepository : RepositoryBase<ConquistaEntity>, IConquistaRepository
    {
        public ConquistaRepository(AppDbContext context) : base(context)
        {
        }
    }
}