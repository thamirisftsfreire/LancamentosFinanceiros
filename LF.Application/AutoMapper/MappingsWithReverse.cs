using AutoMapper;
using LF.Application.ViewModels;
using LF.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LF.Application.AutoMapper
{
    public class MappingsWithReverse : Profile
    {
        public MappingsWithReverse()
        {
            CreateMap<LancamentoFinanceiro, LancamentoFinanceiroVM>().ReverseMap();
            CreateMap<Balanco, BalancoVM>().ReverseMap();
            CreateMap<Tuple<Balanco, List<Balanco>>, Tuple<BalancoVM, List<BalancoVM>>>().ReverseMap();
            CreateMap<Task<List<Balanco>>, Task<List<BalancoVM>>>().ReverseMap();
            CreateMap<Task<LancamentoFinanceiro>, Task<LancamentoFinanceiroVM>>().ReverseMap();
            CreateMap<Task<Balanco>, Task<BalancoVM>>().ReverseMap();
            CreateMap<Task<IEnumerable<LancamentoFinanceiro>>, Task<IEnumerable<LancamentoFinanceiroVM>>>().ReverseMap();
            CreateMap<Task<IEnumerable<Balanco>>, Task<IEnumerable<BalancoVM>>>().ReverseMap();
        }
    }
}
