using System;
using System.Collections.Generic;
using System.Text;

namespace LF.Domain.Entities
{
    public class Balanco
    {
        public DateTime Data { get; set; }
        public Decimal ValorTotalCredito { get; set; }
        public Decimal ValorTotalDebito { get; set; }
        public Decimal ValorTotalSaldo { get; set; }
    }
}
