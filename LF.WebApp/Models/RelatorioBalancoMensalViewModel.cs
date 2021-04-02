using LF.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LF.WebApp.Models
{
    public class RelatorioBalancoMensalViewModel
    {
        public BalancoMensalSearchModel BalancoMensalSearchModel { get; set; }
        public BalancoVM BalancoMensalViewModel { get; set; }
        public IEnumerable<BalancoVM> BalancosDiariosViewModel { get; set; }
    }
}
