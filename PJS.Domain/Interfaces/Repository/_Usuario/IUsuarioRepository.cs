using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PJS.Domain.Entities._Usuario;
using PJS.Domain.Interfaces.Repository._Base;

namespace PJS.Domain.Interfaces.Repository._Usuario
{
    public interface IUsuarioRepository : IRepositoryBase<UsuarioEntity>
    {
        Task<UsuarioEntity> GetByEmailAsync(string email);
    }
}