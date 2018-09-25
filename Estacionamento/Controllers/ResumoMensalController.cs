using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Estacionamento.Models;
using RegrasNegocio.Regras;

namespace Estacionamento.Controllers
{
    public class ResumoMensalController : Controller
    {

        // GET: ResumoMensal
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult BuscaDocFianaceiro(DateTime data)
        {
            var docFin = new DocumentoFinanceiroRegras();

            IList<DocumentoFinanceiro> documentosFinanceiro = docFin.BuscaPorData(data);
            return Json(documentosFinanceiro, JsonRequestBehavior.AllowGet);
        }
    }
}