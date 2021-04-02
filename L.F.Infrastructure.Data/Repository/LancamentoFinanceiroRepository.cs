using LF.Domain.Entities;
using LF.Domain.Enums.LancamentoFinanceiro;
using LF.Domain.Interfaces.Repositories;
using LF.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LF.Infrastructure.Data.Repository
{
    public class LancamentoFinanceiroRepository : BaseRepository<LancamentoFinanceiro>, ILancamentoFinanceiroRepository
    {
        public LancamentoFinanceiroRepository(LFContext context) : base(context)
        {
        }
        public void ConciliarLancamento(Guid id)
        {
            Ctx.Entry(Set.Find(id)).Property(x => x.Status == EStatus.CONCILIADO).IsModified = true;
        }

    }
}
