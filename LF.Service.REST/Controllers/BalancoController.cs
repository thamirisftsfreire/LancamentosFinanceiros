using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LF.Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace LF.Service.REST.Controllers
{
    [ApiController]
    public class BalancoController : ControllerBase
    {
        private readonly IBalancoAppService _balancoAppService;
        
        [HttpPost]
        [Route("Balanco/RelatorioBalancoDiario")]
        public virtual async Task<IActionResult> RelatorioBalancoDiario([FromBody]JObject json)
        {
            try
            {
                DateTime data = json["data"].ToObject<DateTime>();

                return Ok(_balancoAppService.ObterBalancoPorDia(data));
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }
        [HttpPost]
        [Route("Balanco/RelatorioBalancoMensal")]
        public virtual async Task<IActionResult> RelatorioBalancoMensal([FromBody] JObject json)
        {
            try
            {
                DateTime dataInicial = json["dataInicial"].ToObject<DateTime>();
                DateTime dataFinal = json["dataFinal"].ToObject<DateTime>();

                return Ok(_balancoAppService.ObterBalancoPorPerido(dataInicial, dataFinal));
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
