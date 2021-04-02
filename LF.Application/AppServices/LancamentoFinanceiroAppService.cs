using LF.Application.Interfaces;
using LF.Application.ViewModels;
using LF.Domain.Entities;
using LF.Domain.Interfaces.Services;
using LF.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LF.Application.AppServices
{
    public class LancamentoFinanceiroAppService : BaseAppService<ILancamentoFinanceiroService, LancamentoFinanceiro, LancamentoFinanceiroVM>, ILancamentoFinanceiroAppService
    {
        private readonly ILancamentoFinanceiroService _lancamentoFinanceiroService;
        public LancamentoFinanceiroAppService(ILancamentoFinanceiroService lancamentoFinanceiroService, IUnitOfWork uoW)
            : base(lancamentoFinanceiroService, uoW)
        {
            _lancamentoFinanceiroService = lancamentoFinanceiroService;
        }
        public void ConciliarLancamento(Guid id)
        {
            _lancamentoFinanceiroService.ConciliarLancamento(id);
        }
    }
}
