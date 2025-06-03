using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PJS.Domain.Entities._Nivel;
using PJS.Domain.Interfaces.Repository._Nivel;
using PJS.Infrastructure.Data.Context;
using PJS.Infrastructure.Repositories._Base;

namespace PJS.Infrastructure.Repositories._Nivel
{
    public class NivelRepository : RepositoryBase<NivelEntity>, INivelRepository
    {
        public NivelRepository(AppDbContext context) : base(context)
        {
        }
    }
}