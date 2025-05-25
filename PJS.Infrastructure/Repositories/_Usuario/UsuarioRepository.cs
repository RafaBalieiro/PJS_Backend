using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PJS.Domain.Entities._Usuario;
using PJS.Domain.Interfaces.Repository._Usuario;
using PJS.Infrastructure.Data.Context;
using PJS.Infrastructure.Repositories._Base;

namespace PJS.Infrastructure.Repositories._Usuario
{
    public class UsuarioRepository : RepositoryBase<UsuarioEntity>, IUsuarioRepository
    {
        private readonly AppDbContext _context;
        public UsuarioRepository(AppDbContext context) : base(context)
        {
            _context = context;
        }

        public Task<UsuarioEntity> GetByEmailAsync(string email)
        {
            return _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(u => u.Email.ToLower() == email.ToLower()); ;
        }
    }
}