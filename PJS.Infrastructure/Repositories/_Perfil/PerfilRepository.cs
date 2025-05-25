using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PJS.Domain.Entities._Perfil;
using PJS.Domain.Interfaces.Repository._Perfil;
using PJS.Infrastructure.Data.Context;
using PJS.Infrastructure.Repositories._Base;

namespace PJS.Infrastructure.Repositories._Perfil
{
    public class PerfilRepository : RepositoryBase<PerfilEntity>, IPerfilRepository
    {
        public PerfilRepository(AppDbContext context) : base(context)
        {
        }
    }
}