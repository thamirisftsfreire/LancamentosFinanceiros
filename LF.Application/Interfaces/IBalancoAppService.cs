using LF.Application.ViewModels;
using LF.Domain.Enums.LancamentoFinanceiro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LF.Application.Interfaces
{
    public interface IBalancoAppService
    {
        Tuple<BalancoVM, List<BalancoVM>> ObterBalancoPorPerido(DateTime dataInicial, DateTime dataFinal);
        BalancoVM ObterBalancoPorDia(DateTime data);
    }
}
