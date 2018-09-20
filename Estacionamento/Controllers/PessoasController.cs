using System.Web.Mvc;
using Estacionamento.Filtro;
using Estacionamento.Models;
using RegrasNegocio.Regras;


namespace Estacionamento.Controllers
{
    [AutorizacaoFilter]
    public class PessoasController : Controller
    {
        private PessoaRegras pessoaregras = new PessoaRegras();
        
        // GET: Pessoas
        public ActionResult Index()
        {
            return View(pessoaregras.buscarTodos());
        }

        // GET: Pessoas/Details/5
        public ActionResult Details(int id)
        {        
            Pessoa pessoa = pessoaregras.buscarporID(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // GET: Pessoas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pessoas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Tipo,Cpf,Cnpj")] Pessoa pessoa)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    pessoaregras.Adicionar(pessoa);
                    return RedirectToAction("Index");
                }
            }
            catch (System.Exception exp)
            {
                ModelState.AddModelError(string.Empty, exp.Message);               
            }
       
            return View(pessoa);

        }

        // GET: Pessoas/Edit/5
        public ActionResult Edit(int id)
        {

            Pessoa pessoa = pessoaregras.buscarporID(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Tipo,Cpf,Cnpj")] Pessoa pessoa)
        {
            if (ModelState.IsValid)
            {
                pessoaregras.Atualizar(pessoa);
                return RedirectToAction("Index");
            }
            return View(pessoa);
        }

        // GET: Pessoas/Delete/5
        public ActionResult Delete(int id)
        {
            Pessoa pessoa = pessoaregras.buscarporID(id);
            if (pessoa == null)
            {
                return HttpNotFound();
            }
            return View(pessoa);
        }

        // POST: Pessoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Pessoa pessoa = pessoaregras.buscarporID(id);
            pessoaregras.Remover(pessoa);
            return RedirectToAction("Index");
        }

       
    }
}
