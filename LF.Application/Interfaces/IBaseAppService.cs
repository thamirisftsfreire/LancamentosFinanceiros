using LF.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LF.Application.Interfaces
{
    public interface IBaseAppService<TEntityViewModel>
         where TEntityViewModel : BaseVM
    {
        Task<TEntityViewModel> Adicionar(TEntityViewModel obj);
        Task<TEntityViewModel> ObterPorId(Guid id);
        Task<IEnumerable<TEntityViewModel>> ObterTodos();
        IEnumerable<TEntityViewModel> Buscar(Expression<Func<TEntityViewModel, bool>> predicate);
        TEntityViewModel Editar(TEntityViewModel obj);
        Task RemoverAsync(Guid id);
        Task Remover(TEntityViewModel obj);
        void Dispose();
    }
}
