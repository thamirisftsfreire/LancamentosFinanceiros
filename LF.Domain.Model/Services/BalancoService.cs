using LF.Domain.Entities;
using LF.Domain.Enums.LancamentoFinanceiro;
using LF.Domain.Interfaces.Repositories;
using LF.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LF.Domain.Services
{
    public class BalancoService : IBalancoService
    {
        private readonly ILancamentoFinanceiroRepository _lancamentoFinanceiroRepository;
        private readonly Balanco _balanco;
        public BalancoService(ILancamentoFinanceiroRepository lancamentoFinanceiroRepository, Balanco balanco)
        {
            _lancamentoFinanceiroRepository = lancamentoFinanceiroRepository;
            _balanco = balanco;
        }

        public Tuple<Balanco, List<Balanco>> ObterBalancoPorPerido(DateTime dataInicial, DateTime dataFinal)
        {

            IEnumerable<LancamentoFinanceiro> _lancamentos = _lancamentoFinanceiroRepository.Buscar(c => c.DataHora.Date >= dataInicial.Date
                           && c.DataHora.Date <= dataFinal.Date && c.Status == EStatus.CONCILIADO);

            List<Balanco> _balancos = new List<Balanco>();

            Balanco _balanc = null;
            foreach (var lanc in _lancamentos)
            {
                if (_balanc == null)
                {
                    _balanc = new Balanco
                    {
                        Data = lanc.DataHora
                    };
                } else if (!_balanc.Data.Date.Equals(lanc.DataHora.Date)) {
                    _balancos.Add(_balanc);
                    _balanc = null;
                    _balanc = new Balanco
                    {
                        Data = lanc.DataHora
                    };
                }

                if (lanc.Tipo == ETipo.Credito)
                {
                    _balanc.ValorTotalCredito += lanc.Valor;
                    _balanc.ValorTotalSaldo += lanc.Valor;
                }
                else
                {
                    _balanc.ValorTotalDebito += lanc.Valor;
                    _balanc.ValorTotalSaldo -= lanc.Valor;
                }
            }

            if (_balanc != null)
            {
                _balancos.Add(_balanc);
            }

            _balanco.Data = DateTime.Today;
            _balanco.ValorTotalCredito = _balancos.Sum(c => c.ValorTotalCredito);
            _balanco.ValorTotalDebito = _balancos.Sum(c => c.ValorTotalDebito);
            _balanco.ValorTotalSaldo = _balancos.Sum(c => c.ValorTotalSaldo);

            return new Tuple<Balanco, List<Balanco>>(_balanco, _balancos);
        }

        public Balanco ObterBalancoPorDia(DateTime data)
        {
            IEnumerable<LancamentoFinanceiro> _lancamentos = _lancamentoFinanceiroRepository.Buscar(c => c.DataHora.Date == data.Date
                            && c.Status == EStatus.CONCILIADO);

            foreach (var lanc in _lancamentos)
            {
                if (lanc.Tipo == ETipo.Credito)
                {
                    _balanco.ValorTotalCredito += lanc.Valor;
                    _balanco.ValorTotalSaldo += lanc.Valor;
                }
                else
                {
                    _balanco.ValorTotalDebito += lanc.Valor;
                    _balanco.ValorTotalSaldo -= lanc.Valor;
                }
            }
            _balanco.Data = DateTime.Today;
            return _balanco;
        }
    }
}
