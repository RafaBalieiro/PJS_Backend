using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using PJS.Domain.Entities._Base;

namespace PJS.Domain.Interfaces.Services
{
    public interface IServiceBase<TEntity, in TCreateDto, in TUpdateDto, TReadDto>
    where TEntity : BaseEntity
    {
        // Retorno com DTO
        Task<TReadDto> GetByIdAsync(Guid id);
        Task<IEnumerable<TReadDto>> GetAllAsync();
        Task<IEnumerable<TReadDto>> FindAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TReadDto> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate);

        // Criação / Atualização com DTOs
        Task<TReadDto> CreateAsync(TCreateDto dto);
        Task UpdateAsync(Guid id, TUpdateDto dto);
        Task DeleteAsync(Guid id);

        // Utilitário
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
    }
}