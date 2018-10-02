using System.Linq;
using System.Net;
using System.Web.Mvc;
using Estacionamento.Filtro;
using Estacionamento.Models;
using RegrasNegocio.Regras;

namespace Estacionamento.Controllers
{
    [AutorizacaoFilter(Entidades.Entidades.Enuns.TipoUsuario.Administrador)]
    public class VagasController : Controller
    {
        private VagaRegras vagaregras = new VagaRegras();
        private SetorRegras setorregras = new SetorRegras();

        // GET: Vagas
        public ActionResult Index()
        { 
            return View(vagaregras.buscarTodos());
        }

        // GET: Vagas/Details/5
        public ActionResult Details(int id)
        {           
            Vaga vaga = vagaregras.buscarporID(id);
            if (vaga == null)
            {
                return HttpNotFound();
            }
            return View(vaga);
        }

        // GET: Vagas/Create
        public ActionResult Create()
        {
            ViewBag.SetorId = new SelectList(setorregras.buscarTodos(), "Id", "Nome");
            return View();
        }

        // POST: Vagas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Numero,Situacao,SetorId")] Vaga vaga)
        {
            if (ModelState.IsValid)
            {
                vagaregras.Adicionar(vaga);
                return RedirectToAction("Index");
            }

            ViewBag.SetorId = new SelectList(setorregras.buscarTodos(), "Id", "Nome", vaga.SetorId);
            return View(vaga);
        }

        // GET: Vagas/Edit/5
        public ActionResult Edit(int id)
        {
            Vaga vaga = vagaregras.buscarporID(id);
            if (vaga == null)
            {
                return HttpNotFound();
            }
            ViewBag.SetorId = new SelectList(setorregras.buscarTodos(), "Id", "Nome", vaga.SetorId);
            return View(vaga);
        }

        // POST: Vagas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Numero,Situacao,SetorId")] Vaga vaga)
        {
            if (ModelState.IsValid)
            {
                vagaregras.Atualizar(vaga);
                return RedirectToAction("Index");
            }
            ViewBag.SetorId = new SelectList(setorregras.buscarTodos(), "Id", "Nome", vaga.SetorId);
            return View(vaga);
        }

        // GET: Vagas/Delete/5
        public ActionResult Delete(int id)
        {
            Vaga vaga = vagaregras.buscarporID(id);
            if (vaga == null)
            {
                return HttpNotFound();
            }
            return View(vaga);
        }

        // POST: Vagas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Vaga vaga = vagaregras.buscarporID(id);
            vagaregras.Remover(vaga);
            return RedirectToAction("Index");
        }

    }
}
