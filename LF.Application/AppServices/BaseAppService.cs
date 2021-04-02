using AutoMapper;
using LF.Application.AutoMapper;
using LF.Application.Interfaces;
using LF.Application.ViewModels;
using LF.Domain.Entities;
using LF.Domain.Interfaces.Services;
using LF.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LF.Application.AppServices
{
    public class BaseAppService<TIService, TEntity, TEntityViewModel> : ApplicationService, IBaseAppService<TEntityViewModel> 
        where TEntity : BaseEntity
        where TEntityViewModel : BaseVM
        where TIService : IBaseService<TEntity>
    {
        private readonly TIService _baseService;
        protected readonly IMapper AutoMapper;


        public BaseAppService(TIService baseService, IUnitOfWork uow)
            : base(uow)
        {
            _baseService = baseService;
            AutoMapper = new Mapper(AutoMapperConfig.RegisterMappings()); // autoMapper;
        }
        public virtual async Task<TEntityViewModel> Adicionar(TEntityViewModel obj)
        {
            BeginTransaction();
            var ret = _baseService.Adicionar(AutoMapper.Map<TEntity>(obj));
            Commit();
            return await AutoMapper.Map<Task<TEntityViewModel>>(ret);
        }

        public virtual async Task<TEntityViewModel> ObterPorId(Guid id)
        {
            return await AutoMapper.Map<Task<TEntityViewModel>>(_baseService.ObterPorId(id));
        }
        public virtual async Task<IEnumerable<TEntityViewModel>> ObterTodos()
        {
            return await AutoMapper.Map< Task<IEnumerable<TEntityViewModel>>>(_baseService.ObterTodos());
        }
       

        public IEnumerable<TEntityViewModel> Buscar(Expression<Func<TEntityViewModel, bool>> predicate)
        {
            return AutoMapper.Map<IEnumerable<TEntityViewModel>>(_baseService.Buscar(AutoMapper.Map<Expression<Func<TEntity, bool>>>(predicate)));
        }

        public virtual TEntityViewModel Editar(TEntityViewModel obj)
        {
            BeginTransaction();
            var ret = _baseService.Editar(AutoMapper.Map<TEntity>(obj));
            Commit();
            return AutoMapper.Map<TEntityViewModel>(ret);
        }

        public virtual async Task RemoverAsync(Guid id)
        {
            BeginTransaction();
            await _baseService.RemoverAsync(id);
            Commit();
        }

        public virtual async Task Remover(TEntityViewModel obj)
        {
            BeginTransaction();
            await _baseService.Remover(AutoMapper.Map<TEntity>(obj));
            Commit();
        }

        public void Dispose()
        {
            _baseService.Dispose();
        }

    }
}
