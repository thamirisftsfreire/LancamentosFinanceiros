using LF.Domain.Entities;
using System;
using System.Collections.Generic;

namespace LF.Domain.Interfaces.Services
{
    public interface ILancamentoFinanceiroService : IBaseService<LancamentoFinanceiro>
    {
        void ConciliarLancamento(Guid id);
    }
}
