using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using AutoMapper;
using PJS.Domain.Entities._Base;
using PJS.Domain.Interfaces.Repository._Base;
using PJS.Domain.Interfaces.Repository._UnitWork;
using PJS.Domain.Interfaces.Services;

namespace PJS.Application.Services._Base
{
    public class ServiceBase<TEntity, TCreateDto, TUpdateDto, TReadDto> : IServiceBase<TEntity, TCreateDto, TUpdateDto, TReadDto>
     where TEntity : BaseEntity
    {
        protected readonly IRepositoryBase<TEntity> _repository;
        protected readonly IMapper _mapper;
        protected readonly IUnitOfWork _unitOfWork;

        public ServiceBase(IRepositoryBase<TEntity> repository, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public virtual async Task<TReadDto> GetByIdAsync(Guid id)
        {
            var entity = await _repository.GetByIdAsync(id);
            if (entity == null)
                throw new KeyNotFoundException($"{typeof(TEntity).Name} com ID {id} não encontrada.");

            return _mapper.Map<TReadDto>(entity);
        }

        public virtual async Task<IEnumerable<TReadDto>> GetAllAsync()
        {
            var entities = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<TReadDto>>(entities);
        }

        public virtual async Task<IEnumerable<TReadDto>> FindAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entities = await _repository.FindAsync(predicate);
            return _mapper.Map<IEnumerable<TReadDto>>(entities);
        }

        public virtual async Task<TReadDto> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate)
        {
            var entity = await _repository.FirstOrDefaultAsync(predicate);
            if (entity == null)
                throw new KeyNotFoundException($"{typeof(TEntity).Name} não encontrada com o critério especificado.");

            return _mapper.Map<TReadDto>(entity);
        }

        public virtual async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _repository.ExistsAsync(predicate);
        }

        public virtual async Task<TReadDto> CreateAsync(TCreateDto dto)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var entity = _mapper.Map<TEntity>(dto);

                await _repository.AddAsync(entity);

                await _unitOfWork.CommitAsync();

                return _mapper.Map<TReadDto>(entity);
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw new Exception($"Erro ao criar {typeof(TEntity).Name}.", ex);
            }
        }

        public virtual async Task UpdateAsync(Guid id, TUpdateDto dto)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                    throw new KeyNotFoundException($"{typeof(TEntity).Name} com ID {id} não encontrada para atualização.");

                _mapper.Map(dto, entity);
                await _repository.UpdateAsync(entity);

                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw new Exception($"Erro ao atualizar {typeof(TEntity).Name} com ID {id}.", ex);
            }
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            await _unitOfWork.BeginTransactionAsync();
            try
            {
                var entity = await _repository.GetByIdAsync(id);
                if (entity == null)
                    throw new KeyNotFoundException($"{typeof(TEntity).Name} com ID {id} não encontrada para exclusão.");

                await _repository.DeleteAsync(id);

                await _unitOfWork.CommitAsync();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollbackAsync();
                throw new Exception($"Erro ao deletar {typeof(TEntity).Name} com ID {id}.", ex);
            }
        }
    }

}