using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PJS.Domain.Entities._Base;

namespace PJS.Domain.Interfaces.Repository._Base
{
    public interface IRepositoryBase<TEntity> where TEntity : BaseEntity
    {
        Task<TEntity> GetByIdAsync(Guid Id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
        Task AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<TEntity>> GetAllWithIncludeAsync(params Expression<Func<TEntity, object>>[] includes);
    }
}