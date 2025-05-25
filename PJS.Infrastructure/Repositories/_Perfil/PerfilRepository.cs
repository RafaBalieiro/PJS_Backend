using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PJS.Domain.Entities._Perfil;
using PJS.Domain.Interfaces.Repository._Perfil;
using PJS.Infrastructure.Data.Context;
using PJS.Infrastructure.Repositories._Base;

namespace PJS.Infrastructure.Repositories._Perfil
{
    public class PerfilRepository : RepositoryBase<PerfilEntity>, IPerfilRepository
    {

        private readonly AppDbContext _context;

        public PerfilRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PerfilEntity?> GetByUsuarioIdAsync(Guid usuarioId)
        {
            return await _context.Perfis
                .FirstOrDefaultAsync(p => p.UsuarioId == usuarioId);
        }
    }
}