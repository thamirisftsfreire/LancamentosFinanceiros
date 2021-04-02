using LF.Domain.Entities;
using LF.Domain.Enums.LancamentoFinanceiro;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LF.Domain.Interfaces.Services
{
    public interface IBalancoService
    {
        Tuple<Balanco, List<Balanco>> ObterBalancoPorPerido(DateTime dataInicial, DateTime dataFinal);
        Balanco ObterBalancoPorDia(DateTime data);
    }
}
