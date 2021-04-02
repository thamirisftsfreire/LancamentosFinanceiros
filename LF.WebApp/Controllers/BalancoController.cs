using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LF.Application.Interfaces;
using LF.WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace LF.WebApp.Controllers
{
    public class BalancoController : Controller
    {
        private readonly IBalancoAppService _balancoAppService;
        public BalancoController(IBalancoAppService balancoAppService)
        {
            _balancoAppService = balancoAppService;
        }
        public IActionResult RelatorioBalancoDiario()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RelatorioBalancoDiario(RelatorioBalancoDiarioViewModel relatorioBalancoDiarioViewModel)
        {
            relatorioBalancoDiarioViewModel.BalancoViewModel = 
                 _balancoAppService.ObterBalancoPorDia(relatorioBalancoDiarioViewModel.BalancoDiarioSearchModel.Data);
            
            return View(relatorioBalancoDiarioViewModel);
        }
        public IActionResult RelatorioBalancoMensal()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RelatorioBalancoMensal(RelatorioBalancoMensalViewModel relatorioBalancoDiarioViewModel)
        {
            var retorno =
                 _balancoAppService.ObterBalancoPorPerido(relatorioBalancoDiarioViewModel.BalancoMensalSearchModel.DataInicial,
                relatorioBalancoDiarioViewModel.BalancoMensalSearchModel.DataFinal);

            relatorioBalancoDiarioViewModel.BalancoMensalViewModel = retorno.Item1;
            relatorioBalancoDiarioViewModel.BalancosDiariosViewModel = retorno.Item2;

            return View(relatorioBalancoDiarioViewModel);
        }
    }
}
