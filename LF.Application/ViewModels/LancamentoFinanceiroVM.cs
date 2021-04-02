using LF.Domain.Enums.LancamentoFinanceiro;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LF.Application.ViewModels
{
    public class LancamentoFinanceiroVM : BaseVM
    {
        [Required(ErrorMessage = "Preencha o campo Data")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.DateTime, ErrorMessage = "Data em formato inválido")]
        public DateTime DataHora { get; set; }

        [Required(ErrorMessage = "Preencha o campo Valor")]
        [DisplayFormat(DataFormatString = "{0:C0}", ApplyFormatInEditMode = true)]
        public Decimal Valor { get; set; }

        [Required(ErrorMessage = "Preencha o campo Tipo")]
        [EnumDataType(typeof(ETipo))]
        public ETipo Tipo { get; set; }

        [Required(ErrorMessage = "Preencha o campo Status")]
        [EnumDataType(typeof(EStatus))]
        public EStatus Status { get; set; }


    }
}
