using System.Linq;
using System.Net;
using System.Web.Mvc;
using Estacionamento.Filtro;
using Estacionamento.Models;
using RegrasNegocio.Regras;

namespace Estacionamento.Controllers
{
    [AutorizacaoFilter(Entidades.Entidades.Enuns.TipoUsuario.Administrador)]
    public class SetoresController : Controller
    {
        private readonly SetorRegras setorregras = new SetorRegras();

        // GET: Setores
        public ActionResult Index()
        {
            return View(setorregras.buscarTodos());
        }

        // GET: Setores/Details/5
        public ActionResult Details(int id)
        {
            Setor setor = setorregras.buscarporID(id);
            if (setor == null)
            {
                return HttpNotFound();
            }
            return View(setor);
        }

        // GET: Setores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Setores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Sigla,Situacao")] Setor setor)
        {
            if (ModelState.IsValid)
            {
                setorregras.Adicionar(setor);
                return RedirectToAction("Index");
            }

            return View(setor);
        }

        // GET: Setores/Edit/5
        public ActionResult Edit(int id)
        {
            Setor setor = setorregras.buscarporID(id);
            if (setor == null)
            {
                return HttpNotFound();
            }
            return View(setor);
        }

        // POST: Setores/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Sigla,Situacao")] Setor setor)
        {
            if (ModelState.IsValid)
            {
                setorregras.Atualizar(setor);
                return RedirectToAction("Index");
            }
            return View(setor);
        }

        // GET: Setores/Delete/5
        public ActionResult Delete(int id)
        {
            Setor setor = setorregras.buscarporID(id);
            if (setor == null)
            {
                return HttpNotFound();
            }
            return View(setor);
        }

        // POST: Setores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Setor setor = setorregras.buscarporID(id);
            setorregras.Remover(setor);
            return RedirectToAction("Index");
        }

    }
}
