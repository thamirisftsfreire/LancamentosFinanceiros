using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LF.Application.ViewModels
{
    public class BalancoVM
    {
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.DateTime, ErrorMessage = "Data em formato inválido")]
        public DateTime Data { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public Decimal ValorTotalCredito { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public Decimal ValorTotalDebito { get; set; }

        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public Decimal ValorTotalSaldo { get; set; }
    }
}
