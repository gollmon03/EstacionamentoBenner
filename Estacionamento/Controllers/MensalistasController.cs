using System.Web.Mvc;
using Estacionamento.Models;
using RegrasNegocio.Regras;

namespace Estacionamento.Controllers
{
    public class MensalistasController : Controller
    {
        private MensalistaRegras mensalistaregras = new MensalistaRegras();
        private PessoaRegras pessoaregras = new PessoaRegras();
        private ModeloVeiculoRegras modeloveiculoregras = new ModeloVeiculoRegras();

        // GET: Mensalistas
        public ActionResult Index()
        {
            return View(mensalistaregras.buscarTodos());
        }

        // GET: Mensalistas/Details/5
        public ActionResult Details(int id)
        {           
            Mensalista mensalista = mensalistaregras.buscarporID(id);
            if (mensalista == null)
            {
                return HttpNotFound();
            }
            return View(mensalista);
        }

        // GET: Mensalistas/Create
        public ActionResult Create()
        {
            ViewBag.ModeloVeiculoId = new SelectList(modeloveiculoregras.buscarTodos(), "Id", "Marca");
            ViewBag.PessoaId = new SelectList(pessoaregras.buscarTodos(), "Id", "Nome");
            return View();
        }

        // POST: Mensalistas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PlacaVeiculo,ValorMensal,PessoaId,ModeloVeiculoId")] Mensalista mensalista)
        {
            if (ModelState.IsValid)
            {
                mensalistaregras.Adicionar(mensalista);
                return RedirectToAction("Index");
            }

            ViewBag.ModeloVeiculoId = new SelectList(modeloveiculoregras.buscarTodos(), "Id", "Marca", mensalista.ModeloVeiculoId);
            ViewBag.PessoaId = new SelectList(pessoaregras.buscarTodos(), "Id", "Nome", mensalista.PessoaId);
            return View(mensalista);
        }

        // GET: Mensalistas/Edit/5
        public ActionResult Edit(int id)
        {          
            Mensalista mensalista = mensalistaregras.buscarporID(id);
            if (mensalista == null)
            {
                return HttpNotFound();
            }
            ViewBag.ModeloVeiculoId = new SelectList(modeloveiculoregras.buscarTodos(), "Id", "Marca", mensalista.ModeloVeiculoId);
            ViewBag.PessoaId = new SelectList(pessoaregras.buscarTodos(), "Id", "Nome", mensalista.PessoaId);
            return View(mensalista);
        }

        // POST: Mensalistas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PlacaVeiculo,ValorMensal,PessoaId,ModeloVeiculoId")] Mensalista mensalista)
        {
            if (ModelState.IsValid)
            {
                mensalistaregras.Atualizar(mensalista);
                return RedirectToAction("Index");
            }
            ViewBag.ModeloVeiculoId = new SelectList(modeloveiculoregras.buscarTodos(), "Id", "Marca", mensalista.ModeloVeiculoId);
            ViewBag.PessoaId = new SelectList(pessoaregras.buscarTodos(), mensalista.PessoaId);
            return View(mensalista);
        }

        // GET: Mensalistas/Delete/5
        public ActionResult Delete(int id)
        {

            Mensalista mensalista = mensalistaregras.buscarporID(id);
            if (mensalista == null)
            {
                return HttpNotFound();
            }
            return View(mensalista);
        }

        // POST: Mensalistas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Mensalista mensalista = mensalistaregras.buscarporID(id);
            mensalistaregras.Remover(mensalista);
            return RedirectToAction("Index");
        }

    }
}
