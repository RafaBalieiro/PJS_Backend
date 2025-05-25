using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PJS.Domain.Entities._Base;
using PJS.Domain.Interfaces.Repository._Base;
using PJS.Domain.Interfaces.Services;

namespace PJS.Application.Services._Base
{
    public class ServiceBase<TEntity> : IServiceBase<TEntity> where TEntity : BaseEntity
    {
        private readonly IRepositoryBase<TEntity> _repository;

        public ServiceBase(IRepositoryBase<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual async Task CreateAsync(TEntity entity)
        {
            await _repository.AddAsync(entity);
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public virtual async Task<TEntity> GetByIdAsync(Guid id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.FindAsync(predicate);
        }

        public virtual async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.ExistsAsync(predicate);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            await _repository.UpdateAsync(entity);
        }
    }
}