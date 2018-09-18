using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Estacionamento.Filtro;
using RegrasNegocio.Regras;

namespace Estacionamento.Controllers
{
    [AutorizacaoFilter]
    public class HomeController : Controller
    {
        private readonly MovimentacaoVeiculoRegras movimentacaoVeiculoRegras;

        public HomeController()
        {
            this.movimentacaoVeiculoRegras = new MovimentacaoVeiculoRegras();
        }

        public ActionResult Index()
        {
            var movimentacoes = movimentacaoVeiculoRegras.BuscaTodosAtivos();
            return View(movimentacoes);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult FinalizarMovimentacao(int id)
        {
            try
            {
                var movimentacao = movimentacaoVeiculoRegras.FinalizarMovimentacao(id);
                return View(movimentacao);
            }
            catch (System.Exception exp)
            {
                ModelState.AddModelError(string.Empty, exp.Message);
            }
            return RedirectToAction("Index");
        }
    }
}