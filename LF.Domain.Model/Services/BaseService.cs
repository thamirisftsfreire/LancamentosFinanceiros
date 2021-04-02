using LF.Domain.Entities;
using LF.Domain.Interfaces.Repositories;
using LF.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LF.Domain.Services
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : BaseEntity
    {
        private readonly IBaseRepository<TEntity> _repository;

        public BaseService(IBaseRepository<TEntity> repository)
        {
            _repository = repository;
        }

        public virtual async Task<TEntity> Adicionar(TEntity tEntity)
        {
            return await _repository.Adicionar(tEntity);
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await _repository.ObterPorId(id);
        }
        public virtual async Task<IEnumerable<TEntity>>  ObterTodos()
        {
            return await _repository.ObterTodos();
        }
        
        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return _repository.Buscar(predicate);
        }
        public TEntity Editar(TEntity tEntity)
        {
            return _repository.Editar(tEntity);
        }

        public virtual async Task RemoverAsync(Guid id)
        {
            await _repository.RemoverAsync(id);
        }

        public virtual async Task Remover(TEntity tEntity)
        {
            await _repository.Remover(tEntity);
        }

        public virtual void Dispose()
        {
            _repository.Dispose();
        }
    }
}
