using LF.Domain.Entities;
using LF.Domain.Interfaces.Repositories;
using LF.Domain.Interfaces.Services;
using LF.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LF.Domain.Services
{
    public class LancamentoFinanceiroService : BaseService<LancamentoFinanceiro>, ILancamentoFinanceiroService
    {
        private readonly ILancamentoFinanceiroRepository _repository;
        private readonly LancamentoConciliadoValidation _lancamentoConciliadoValidation;
        private readonly LancamentoFinanceiro _lancamento;
        public LancamentoFinanceiroService(ILancamentoFinanceiroRepository repository, 
            LancamentoConciliadoValidation lancamentoConciliadoValidation,
            LancamentoFinanceiro lancamento) : base(repository)
        {
            _repository = repository;
            _lancamentoConciliadoValidation = lancamentoConciliadoValidation;
            _lancamento = lancamento;
        }
        public void Editar(LancamentoFinanceiro lancamento)
        {
            if (!_lancamentoConciliadoValidation.IsSatisfiedBy(lancamento))
                throw new Exception("Não é possível alterar um lançamento conciliado.");
            _repository.Editar(lancamento);
        }
        public void ConciliarLancamento(Guid id)
        {
            _repository.ConciliarLancamento(id);
        }

    }
}
