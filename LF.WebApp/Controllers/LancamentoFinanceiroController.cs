using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LF.Application.ViewModels;
using LF.Application.Interfaces;

namespace LF.WebApp.Controllers
{
    public class LancamentoFinanceiroController : Controller
    {
        private readonly ILancamentoFinanceiroAppService _lfAppService;
        private readonly LancamentoFinanceiroVM _lancamentoVM;

        public LancamentoFinanceiroController(ILancamentoFinanceiroAppService lfAppService, LancamentoFinanceiroVM lancamentoVM)
        {
            _lfAppService = lfAppService;
            _lancamentoVM = lancamentoVM;
        }


        public virtual async Task<IActionResult> ConsultarLancamento()
        {
            return View(await _lfAppService.ObterTodos());
        }

        public virtual async Task<IActionResult> VisualizarLancamento(Guid? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var lancamentoFinanceiroVM = await _lfAppService.ObterPorId(id.Value);
                if (lancamentoFinanceiroVM == null)
                {
                    return NotFound();
                }
                return View(lancamentoFinanceiroVM);
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return RedirectToAction("ConsultarLancamento");
            }

        }

        public virtual async Task<IActionResult> CadastrarLancamento()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> CadastrarLancamento([Bind("DataHora,Valor,Tipo,Status,Id")] LancamentoFinanceiroVM lancamentoFinanceiroVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    await _lfAppService.Adicionar(lancamentoFinanceiroVM);
                    TempData["Ok"] = "Operação realizada com sucesso.";
                    return RedirectToAction(nameof(ConsultarLancamento));
                }
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
            }
            return View(lancamentoFinanceiroVM);
        }


        public virtual async Task<IActionResult> EditarLancamento(Guid? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }
                var lancamentoFinanceiroVM = await _lfAppService.ObterPorId(id.Value);
                if (lancamentoFinanceiroVM == null)
                {
                    return NotFound();
                }
                return View(lancamentoFinanceiroVM);
            }
            catch(Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return RedirectToAction("ConsultarLancamento");
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> EditarLancamento(Guid id, [Bind("DataHora,Valor,Tipo,Status,Id")] LancamentoFinanceiroVM lancamentoFinanceiroVM)
        {
            try
            {
                if (id != lancamentoFinanceiroVM.Id)
                {
                    return NotFound();
                }

                if (ModelState.IsValid)
                {
                    try
                    {
                        _lfAppService.Editar(lancamentoFinanceiroVM);
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!LancamentoFinanceiroVMExists(lancamentoFinanceiroVM.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    TempData["Ok"] = "Operação realizada com sucesso.";
                    return View(lancamentoFinanceiroVM);
                }
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
            }
            return View(lancamentoFinanceiroVM);
        }


        public virtual async Task<IActionResult> RemoverLancamento(Guid? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                var lancamentoFinanceiroVM = await _lfAppService.ObterPorId(id.Value);
                if (lancamentoFinanceiroVM == null)
                {
                    return NotFound();
                }
                return View(lancamentoFinanceiroVM);
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return RedirectToAction("ConsultarLancamento");
            }
            
        }
        public ActionResult ConciliarLancamento(Guid? id)
        {
            try
            {
                if (id == null)
                {
                    return NotFound();
                }

                _lfAppService.ConciliarLancamento(id.Value);
                
            }
            catch(Exception ex)
            {
                TempData["Erro"] = ex.Message;
            }
            return RedirectToAction("ConsultarLancamento");
        }

        [HttpPost, ActionName("RemoverLancamento")]
        [ValidateAntiForgeryToken]
        public virtual async Task<IActionResult> RemocaoConfirmada(Guid id)
        {
            var lancamentoFinanceiroVM = _lfAppService.ObterPorId(id).Result;
            await _lfAppService.Remover(lancamentoFinanceiroVM);
            TempData["Ok"] = "Operação realizada com sucesso.";
            return RedirectToAction(nameof(ConsultarLancamento));
        }

        private bool LancamentoFinanceiroVMExists(Guid id)
        {
            return _lfAppService.ObterPorId(id) != null;
        }


    }

}
