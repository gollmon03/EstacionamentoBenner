using System.Net;
using System.Web.Mvc;
using Estacionamento.Models;
using RegrasNegocio.Regras;

namespace Estacionamento.Controllers
{
    public class ModeloVeiculosController : Controller
    {
        private ModeloVeiculoRegras modeloveiculoregras = new ModeloVeiculoRegras();
        private TipoVeiculoRegras tipoveiculoregras = new TipoVeiculoRegras();

        // GET: ModeloVeiculos
        public ActionResult Index()
        {
            return View(modeloveiculoregras.buscarTodos());
        }

        // GET: ModeloVeiculos/Details/5
        public ActionResult Details(int id)
        {
            ModeloVeiculo modeloVeiculo = modeloveiculoregras.buscarporID(id);
            if (modeloVeiculo == null)
            {
                return HttpNotFound();
            }
            return View(modeloVeiculo);
        }

        // GET: ModeloVeiculos/Create
        public ActionResult Create()
        {
            ViewBag.TipoVeiculoId = new SelectList(tipoveiculoregras.buscarTodos(), "Id", "Nome");
            return View();
        }

        // POST: ModeloVeiculos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Marca,Nome,TipoVeiculoId")] ModeloVeiculo modeloVeiculo)
        {
            if (ModelState.IsValid)
            {
                modeloveiculoregras.Adicionar(modeloVeiculo);
                return RedirectToAction("Index");
            }

            ViewBag.TipoVeiculoId = new SelectList(tipoveiculoregras.buscarTodos(), "Id", "Nome", modeloVeiculo.TipoVeiculoId);
            return View(modeloVeiculo);
        }

        // GET: ModeloVeiculos/Edit/5
        public ActionResult Edit(int id)
        {
            ModeloVeiculo modeloVeiculo = modeloveiculoregras.buscarporID(id);
            if (modeloVeiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoVeiculoId = new SelectList(tipoveiculoregras.buscarTodos(), "Id", "Nome", modeloVeiculo.TipoVeiculoId);
            return View(modeloVeiculo);
        }

        // POST: ModeloVeiculos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Marca,Nome,TipoVeiculoId")] ModeloVeiculo modeloVeiculo)
        {
            if (ModelState.IsValid)
            {
                modeloveiculoregras.Atualizar(modeloVeiculo);
                return RedirectToAction("Index");
            }
            ViewBag.TipoVeiculoId = new SelectList(tipoveiculoregras.buscarTodos(), "Id", "Nome", modeloVeiculo.TipoVeiculoId);
            return View(modeloVeiculo);
        }

        // GET: ModeloVeiculos/Delete/5
        public ActionResult Delete(int id)
        {
            ModeloVeiculo modeloVeiculo = modeloveiculoregras.buscarporID(id);
            if (modeloVeiculo == null)
            {
                return HttpNotFound();
            }
            return View(modeloVeiculo);
        }

        // POST: ModeloVeiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ModeloVeiculo modeloVeiculo = modeloveiculoregras.buscarporID(id);
            modeloveiculoregras.Remover(modeloVeiculo);
            return RedirectToAction("Index");
        }
    }
}
