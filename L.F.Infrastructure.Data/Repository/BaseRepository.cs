using LF.Domain.Entities;
using LF.Domain.Interfaces.Repositories;
using LF.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LF.Infrastructure.Data.Repository
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>, IDisposable where TEntity : BaseEntity
    {
        protected LFContext Ctx { get; }
        protected DbSet<TEntity> Set { get; }

        public BaseRepository(LFContext context)
        {
            Ctx = context;
            Set = Ctx.Set<TEntity>();
        }

        public virtual async Task<TEntity> Adicionar(TEntity tEntity)
        {
            if (tEntity.Id == Guid.Empty)
                tEntity.Id = Guid.NewGuid();
            var entity = await Set.AddAsync(tEntity);
            return entity.Entity;
        }

        public virtual async Task<TEntity> ObterPorId(Guid id)
        {
            return await Set.FindAsync(id);
        }
        public virtual async Task<IEnumerable<TEntity>> ObterTodos()
        {
            return await Set.AsNoTracking().ToListAsync();
        }
        public IEnumerable<TEntity> Buscar(Expression<Func<TEntity, bool>> predicate)
        {
            return Set.Where(predicate);
        }

        public TEntity Editar(TEntity tEntity)
        {
            var entry = Ctx.Entry(tEntity);
            Set.Attach(tEntity);
            entry.State = EntityState.Modified;

            return tEntity;
        }

        public virtual async Task Remover(TEntity tEntity)
        {
            Set.Remove(tEntity);
        }

        public virtual async Task RemoverAsync(Guid id)
        {
            Set.Remove(await Set.FindAsync(id));
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                Ctx?.Dispose();
            }
        }
    }
}
