using LF.Domain.Entities;
using LF.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LF.Domain.Validations
{
    /// <summary>
    /// Regra 1:
    /// Caso o lançamento já tenha sido conciliado não deve permitir edição nem deleção do registro;
    /// </summary>
    public class LancamentoConciliadoValidation
    {
        private readonly ILancamentoFinanceiroRepository _lancamentoFinanceiroRepository;

        public LancamentoConciliadoValidation(ILancamentoFinanceiroRepository lancamentoFinanceiroRepository)
        {
            _lancamentoFinanceiroRepository = lancamentoFinanceiroRepository;
        }
        public bool IsSatisfiedBy(LancamentoFinanceiro lancamentoFinanceiro)
        {
            var _lancamentoFinanceiro = _lancamentoFinanceiroRepository.ObterPorId(lancamentoFinanceiro.Id).Result;

            if (_lancamentoFinanceiro.Status == Enums.LancamentoFinanceiro.EStatus.CONCILIADO)
                return false;
            
            return true;
        }
    }
}
