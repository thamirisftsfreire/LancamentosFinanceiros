using LF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace LF.Domain.Interfaces.Repositories
{
    public interface ILancamentoFinanceiroRepository : IBaseRepository<LancamentoFinanceiro>
    {
        void ConciliarLancamento(Guid id);
    }
}
