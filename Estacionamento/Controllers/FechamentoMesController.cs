using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Estacionamento.Filtro;
using Estacionamento.Models;
using RegrasNegocio.Regras;

namespace Estacionamento.Controllers
{
    [AutorizacaoFilter]
    public class FechamentoMesController : Controller
    {
        private readonly MensalistaRegras mensalistaRegras = new MensalistaRegras();
        private readonly DocumentoFinanceiroRegras documentoFinanceiroRegras = new DocumentoFinanceiroRegras();

        // GET: FechamentoMes
        [HttpGet]
        public ActionResult GerarDocumento()
        {
            ViewBag.MensalistaId = new SelectList(mensalistaRegras.buscarTodos(), "Id", "Pessoa.Nome");
            return View();
        }
        
        public JsonResult Gerar(DateTime mes, string Tipo, int MensalistaId)
        {
            var result = "Ação executada com sucesso";
            try
            {
                documentoFinanceiroRegras.Gerar(mes, Tipo, MensalistaId);
            }
            catch (Exception exp)
            {
                result = "Erro ao executar a ação: " + exp.Message;                           
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }
    }
}