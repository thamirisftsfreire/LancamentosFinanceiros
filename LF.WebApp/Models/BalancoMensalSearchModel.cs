using LF.Domain.Enums.LancamentoFinanceiro;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LF.WebApp.Models
{
    public class BalancoMensalSearchModel
    {
        public DateTime DataInicial { get; set; }
        public DateTime DataFinal { get; set; }
    }
}
