using LF.Domain.Enums.LancamentoFinanceiro;
using System;
using System.ComponentModel.DataAnnotations;


namespace LF.WebApp.Models
{
    public class BalancoDiarioSearchModel
    {
        [Required(ErrorMessage = "Preencha o campo Data")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd-MM-yyyy}")]
        [DataType(DataType.Date, ErrorMessage = "Data em formato inválido")]
        public DateTime Data { get; set; }

        public ETipo Tipo { get; set; }
    }
    public enum ETipoModel : int
    {
        Todos = 0,
        Debito = 1,
        Credito = 2
    }
}
