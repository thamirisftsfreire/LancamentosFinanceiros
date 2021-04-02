using AutoMapper;
using LF.Application.AutoMapper;
using LF.Application.Interfaces;
using LF.Application.ViewModels;
using LF.Domain.Enums.LancamentoFinanceiro;
using LF.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LF.Application.AppServices
{
    public class BalancoAppService : IBalancoAppService
    {
        private readonly IBalancoService _balancoService;
        protected readonly IMapper AutoMapper;
        public BalancoAppService(IBalancoService balancoService)
        {
            _balancoService = balancoService;
            AutoMapper = new Mapper(AutoMapperConfig.RegisterMappings()); // autoMapper;
        }
        public Tuple<BalancoVM, List<BalancoVM>> ObterBalancoPorPerido(DateTime dataInicial, DateTime dataFinal)
        {
            return  AutoMapper.Map<Tuple<BalancoVM, List<BalancoVM>>>(_balancoService.ObterBalancoPorPerido(dataInicial, dataFinal));
        }
        public BalancoVM ObterBalancoPorDia(DateTime data)
        {
            return  AutoMapper.Map<BalancoVM>(_balancoService.ObterBalancoPorDia(data));
        }
        
    }
    
}
