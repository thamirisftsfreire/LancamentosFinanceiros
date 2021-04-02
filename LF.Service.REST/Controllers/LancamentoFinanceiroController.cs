using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using LF.Application.Interfaces;
using LF.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace LF.Service.REST.Controllers
{

    [ApiController]
    public class LancamentoFinanceiroController : ControllerBase
    {
        private readonly ILancamentoFinanceiroAppService _lancamentoFinanceiroAppService;

        public LancamentoFinanceiroController(ILancamentoFinanceiroAppService lancamentoFinanceiroAppService)
        {
            _lancamentoFinanceiroAppService = lancamentoFinanceiroAppService;
        }
        [HttpPost]
        [Route("LancamentoFinanceiro/Adicionar")]
        public virtual async Task<IActionResult> Adicionar([FromBody]JObject json)
        {
            try
            {
                var lancamentoFinanceiroVM = JsonConvert.DeserializeObject<LancamentoFinanceiroVM>(json.Root.ToString());
                var result = _lancamentoFinanceiroAppService.Adicionar(lancamentoFinanceiroVM);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
            }
            catch(Exception ex)
            {
                throw ex;                
            }            
        }
        [HttpGet]
        [Route("LancamentoFinanceiro/ObterPorId")]
        public virtual async Task<IActionResult> ObterPorId(Guid id)
        {
            try
            {
                var result = _lancamentoFinanceiroAppService.ObterPorId(id);
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        [Route("LancamentoFinanceiro/Editar")]
        public virtual async Task<IActionResult> Editar([FromBody] JObject json)
        {
            try
            {
                var lancamentoFinanceiroVM = JsonConvert.DeserializeObject<LancamentoFinanceiroVM>(json.Root.ToString());
                _lancamentoFinanceiroAppService.Editar(lancamentoFinanceiroVM);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok();
        }
        [HttpDelete]
        [Route("LancamentoFinanceiro/Remover")]
        public virtual async Task<IActionResult> RemoverAsync(Guid id)
        {
            
            try
            {
                _lancamentoFinanceiroAppService.RemoverAsync(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok();
        }
        [HttpPost]
        [Route("LancamentoFinanceiro/ConciliarLancamento")]
        public virtual async Task<IActionResult> ConciliarLancamento(Guid id)
        {
            try
            {               
                _lancamentoFinanceiroAppService.ConciliarLancamento(id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return Ok();
        }
    }
}
