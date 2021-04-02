using LF.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LF.WebApp.Models
{
    public class RelatorioBalancoDiarioViewModel
    {
        public BalancoDiarioSearchModel BalancoDiarioSearchModel { get; set; }
        public BalancoVM BalancoViewModel { get; set; }
    }
}
