using LF.Domain.Enums.LancamentoFinanceiro;
using System;
using System.Collections.Generic;
using System.Text;

namespace LF.Domain.Entities
{
    public class LancamentoFinanceiro : BaseEntity
    {
        public DateTime DataHora { get; set; }
        public Decimal Valor { get; set; }
        public ETipo Tipo { get; set; }
        public EStatus Status { get; set; }
    }
}
