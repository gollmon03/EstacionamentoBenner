using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Estacionamento.Models;
using RegrasNegocio.Regras;

namespace Estacionamento.Controllers
{
    public class FechamentoMesController : Controller
    {

        private readonly MensalistaRegras mensalistaRegras = new MensalistaRegras();
        private readonly DocumentoFinanceiroRegras documentoFinanceiroRegras = new DocumentoFinanceiroRegras();

        // GET: FechamentoMes
        public ActionResult Index()
        {
            ViewBag.MensalistaId = new SelectList(mensalistaRegras.buscarTodos(), "Id", "Pessoa.Nome");
            return View();
        }

        public ActionResult GerarDocumento(DateTime? mes, string Tipo, int MensalistaId)
        {
            documentoFinanceiroRegras.Gerar((DateTime)mes, Tipo, MensalistaId);
            try
            {
                if (mes == null)
                    ModelState.AddModelError(string.Empty, "Campo Mês é obrigatório");
                if (ModelState.IsValid)
                {
                    //documentoFinanceiroRegras.Gerar((DateTime)mes, Tipo, MensalistaId);
                }else
                {
                    //erro campo obrigatório
                }
            }
            catch (Exception exp)
            {
                ModelState.AddModelError(string.Empty, exp.Message);                                
            }
            return RedirectToAction("Index");
        }
    }
}