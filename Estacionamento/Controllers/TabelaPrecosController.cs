using System.Linq;
using System.Net;
using System.Web.Mvc;
using Estacionamento.Filtro;
using Estacionamento.Models;
using RegrasNegocio.Regras;

namespace Estacionamento.Controllers
{
    [AutorizacaoFilter]
    public class TabelaPrecosController : Controller
    {
        private TabelaPrecoRegras tabelaprecoregras = new TabelaPrecoRegras();
        private TipoVeiculoRegras tipoveiculoregras = new TipoVeiculoRegras();
        private ModeloVeiculoRegras modeloveiculoregras = new ModeloVeiculoRegras();

        // GET: TabelaPrecos
        public ActionResult Index()
        {
            return View(tabelaprecoregras.buscarTodos());
        }

        // GET: TabelaPrecos/Details/5
        public ActionResult Details(int id)
        {
            TabelaPreco tabelaPreco = tabelaprecoregras.buscarporID(id);
            if (tabelaPreco == null)
            {
                return HttpNotFound();
            }
            return View(tabelaPreco);
        }

        // GET: TabelaPrecos/Create
        public ActionResult Create()
        {
            ViewBag.TipoVeiculoId = new SelectList(tipoveiculoregras.buscarTodos(), "Id", "Nome");
            return View();
        }

        // POST: TabelaPrecos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,ValorHora,TipoVeiculoId")] TabelaPreco tabelaPreco)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    tabelaprecoregras.Adicionar(tabelaPreco);
                    return RedirectToAction("Index");
                }
            }
            catch (System.Exception exp)
            {
                ModelState.AddModelError(string.Empty, exp.Message);
            }

            ViewBag.TipoVeiculoId = new SelectList(tipoveiculoregras.buscarTodos(), "Id", "Nome", tabelaPreco.TipoVeiculoId);
            return View(tabelaPreco);
        }

        // GET: TabelaPrecos/Edit/5
        public ActionResult Edit(int id)
        {
            TabelaPreco tabelaPreco = tabelaprecoregras.buscarporID(id);
            if (tabelaPreco == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoVeiculoId = new SelectList(tipoveiculoregras.buscarTodos(), "Id", "Nome", tabelaPreco.TipoVeiculoId);
            return View(tabelaPreco);
        }

        // POST: TabelaPrecos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,ValorHora,TipoVeiculoId")] TabelaPreco tabelaPreco)
        {
            if (ModelState.IsValid)
            {
                tabelaprecoregras.Atualizar(tabelaPreco);
                return RedirectToAction("Index");
            }
            ViewBag.TipoVeiculoId = new SelectList(modeloveiculoregras.buscarTodos(), "Id", "Nome", tabelaPreco.TipoVeiculoId);
            return View(tabelaPreco);
        }

        // GET: TabelaPrecos/Delete/5
        public ActionResult Delete(int id)
        {
            TabelaPreco tabelaPreco = tabelaprecoregras.buscarporID(id);
            if (tabelaPreco == null)
            {
                return HttpNotFound();
            }
            return View(tabelaPreco);
        }

        // POST: TabelaPrecos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TabelaPreco tabelaPreco = tabelaprecoregras.buscarporID(id);
            tabelaprecoregras.Remover(tabelaPreco);
            return RedirectToAction("Index");
        }
    }
}
