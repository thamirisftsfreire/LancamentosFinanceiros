using LF.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LF.Application.Interfaces
{
    public interface ILancamentoFinanceiroAppService : IBaseAppService<LancamentoFinanceiroVM>
    {
        void ConciliarLancamento(Guid id);
    }
}
