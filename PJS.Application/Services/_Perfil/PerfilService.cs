using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PJS.Application.Interfaces.Services._Perfil;
using PJS.Application.Services._Base;
using PJS.Domain.Entities._Perfil;
using PJS.Domain.Interfaces.Repository._Base;

namespace PJS.Application.Services._Perfil
{
    public class PerfilService : ServiceBase<PerfilEntity>, IPerfilService
    {
        public PerfilService(IRepositoryBase<PerfilEntity> repository) : base(repository)
        {
        }
    }
}