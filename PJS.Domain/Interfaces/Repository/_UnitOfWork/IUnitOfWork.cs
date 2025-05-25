using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PJS.Domain.Interfaces.Repository._UnitWork
{
    public interface IUnitOfWork : IDisposable
    {
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        Task<int> SaveChangesAsync();
    }
}