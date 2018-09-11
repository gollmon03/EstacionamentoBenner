using System.Linq;
using System.Net;
using System.Web.Mvc;
using Estacionamento.Filtro;
using Estacionamento.Models;
using RegrasNegocio.Regras;

namespace Estacionamento.Controllers
{
    [AutorizacaoFilter]
    public class TipoVeiculosController : Controller
    {
        private TipoVeiculoRegras tipoveiculoregras = new TipoVeiculoRegras();

        // GET: TipoVeiculos
        public ActionResult Index()
        {
            return View(tipoveiculoregras.buscarTodos());
        }

        // GET: TipoVeiculos/Details/5
        public ActionResult Details(int id)
        {
            TipoVeiculo tipoVeiculo = tipoveiculoregras.buscarporID(id);
            if (tipoVeiculo == null)
            {
                return HttpNotFound();
            }
            return View(tipoVeiculo);
        }

        // GET: TipoVeiculos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoVeiculos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] TipoVeiculo tipoVeiculo)
        {
            if (ModelState.IsValid)
            {
                tipoveiculoregras.Adicionar(tipoVeiculo);
                return RedirectToAction("Index");
            }

            return View(tipoVeiculo);
        }

        // GET: TipoVeiculos/Edit/5
        public ActionResult Edit(int id)
        {
            TipoVeiculo tipoVeiculo = tipoveiculoregras.buscarporID(id);
            if (tipoVeiculo == null)
            {
                return HttpNotFound();
            }
            return View(tipoVeiculo);
        }

        // POST: TipoVeiculos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] TipoVeiculo tipoVeiculo)
        {
            if (ModelState.IsValid)
            {
                tipoveiculoregras.Atualizar(tipoVeiculo);
                return RedirectToAction("Index");
            }
            return View(tipoVeiculo);
        }

        // GET: TipoVeiculos/Delete/5
        public ActionResult Delete(int id)
        {
            TipoVeiculo tipoVeiculo = tipoveiculoregras.buscarporID(id);
            if (tipoVeiculo == null)
            {
                return HttpNotFound();
            }
            return View(tipoVeiculo);
        }

        // POST: TipoVeiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoVeiculo tipoVeiculo = tipoveiculoregras.buscarporID(id);
            tipoveiculoregras.Remover(tipoVeiculo);
            return RedirectToAction("Index");
        }
    }
}
