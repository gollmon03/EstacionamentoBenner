using System.Linq;
using System.Net;
using System.Web.Mvc;
using Estacionamento.Filtro;
using Estacionamento.Models;
using RegrasNegocio.Regras;

namespace Estacionamento.Controllers
{
    [AutorizacaoFilter]
    public class MovimentacaoVeiculosController : Controller
    {
        private MovimentacaoVeiculoRegras movimentacaoveiculoregras = new MovimentacaoVeiculoRegras();
        private MensalistaRegras mensalistaregras = new MensalistaRegras();
        private ModeloVeiculoRegras modeloveiculoregras = new ModeloVeiculoRegras();
        private UsuarioRegras usuarioregras = new UsuarioRegras();
        private VagaRegras vagaregras = new VagaRegras();
        private TipoVeiculoRegras tipoVeiculoRegras = new TipoVeiculoRegras();
    
        // GET: MovimentacaoVeiculos
        public ActionResult Index()
        {
            var movimentacoes = movimentacaoveiculoregras.buscarTodos().Reverse();
            return View(movimentacoes);         
        }

        // GET: MovimentacaoVeiculos/Details/5
        public ActionResult Details(int id)
        {
            MovimentacaoVeiculo movimentacaoVeiculo = movimentacaoveiculoregras.buscarporID(id);
            if (movimentacaoVeiculo == null)
            {
                return HttpNotFound();
            }
            return View(movimentacaoVeiculo);
        }

        // GET: MovimentacaoVeiculos/Create
        public ActionResult Create()
        {
            var mensalita = mensalistaregras.buscarTodos();
            ViewBag.MensalistaId = new SelectList(mensalistaregras.buscarTodos(), "Id", "Id");
            ViewBag.TipoVeiculoId = new SelectList(tipoVeiculoRegras.buscarTodos(), "Id", "Nome");
            ViewBag.UsuarioId = new SelectList(usuarioregras.buscarTodos(), "Id", "Nome");
            ViewBag.VagaId = new SelectList(vagaregras.buscarTodos(), "Id", "Numero");
            return View();
        }

        // POST: MovimentacaoVeiculos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MovimentacaoVeiculo movimentacaoVeiculo)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    movimentacaoveiculoregras.Adicionar(movimentacaoVeiculo);
                    return RedirectToAction("Index");
                }
            }
            catch (System.Exception exp)
            {
                ModelState.AddModelError(string.Empty, exp.Message);
                
            }

            ViewBag.MensalistaId = new SelectList(mensalistaregras.buscarTodos(), "Id", "Id", movimentacaoVeiculo.MensalistaId);
            ViewBag.TipoVeiculoId = new SelectList(tipoVeiculoRegras.buscarTodos(), "Id", "Nome", movimentacaoVeiculo.TipoVeiculoId);
            ViewBag.UsuarioId = new SelectList(usuarioregras.buscarTodos(), "Id", "Nome", movimentacaoVeiculo.UsuarioId);
            ViewBag.VagaId = new SelectList(vagaregras.buscarTodos(), "Id", "Numero", movimentacaoVeiculo.VagaId);
            return View(movimentacaoVeiculo);
        }

        // GET: MovimentacaoVeiculos/Edit/5
        public ActionResult Edit(int id)
        {
            MovimentacaoVeiculo movimentacaoVeiculo = movimentacaoveiculoregras.buscarporID(id);
            if (movimentacaoVeiculo == null)
            {
                return HttpNotFound();
            }

            ViewBag.MensalistaId = new SelectList(mensalistaregras.buscarTodos(), "Id", "Id", movimentacaoVeiculo.MensalistaId);
            ViewBag.TipoVeiculoId = new SelectList(tipoVeiculoRegras.buscarTodos(), "Id", "Nome", movimentacaoVeiculo.TipoVeiculoId);
            ViewBag.UsuarioId = new SelectList(usuarioregras.buscarTodos(), "Id", "Nome", movimentacaoVeiculo.UsuarioId);
            ViewBag.VagaId = new SelectList(vagaregras.buscarTodos(), "Id", "Numero", movimentacaoVeiculo.VagaId);
            return View(movimentacaoVeiculo);
        }

        // POST: MovimentacaoVeiculos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,DataHoraEntrada,DataHoraSaida,PlacaVeiculo,UsuarioId,ModeloVeiculoId,ClienteId,VagaId")] MovimentacaoVeiculo movimentacaoVeiculo)
        {
            if (ModelState.IsValid)
            {
                movimentacaoveiculoregras.Atualizar(movimentacaoVeiculo);
                return RedirectToAction("Index");
            }

            ViewBag.MensalistaId = new SelectList(mensalistaregras.buscarTodos(), "Id", "Id", movimentacaoVeiculo.MensalistaId);
            ViewBag.TipoVeiculoId = new SelectList(tipoVeiculoRegras.buscarTodos(), "Id", "Nome", movimentacaoVeiculo.TipoVeiculoId);
            ViewBag.UsuarioId = new SelectList(usuarioregras.buscarTodos(), "Id", "Nome", movimentacaoVeiculo.UsuarioId);
            ViewBag.VagaId = new SelectList(vagaregras.buscarTodos(), "Id", "Numero", movimentacaoVeiculo.VagaId);
            return View(movimentacaoVeiculo);
        }

        // GET: MovimentacaoVeiculos/Delete/5
        public ActionResult Delete(int id)
        {
            MovimentacaoVeiculo movimentacaoVeiculo = movimentacaoveiculoregras.buscarporID(id);
            if (movimentacaoVeiculo == null)
            {
                return HttpNotFound();
            }
            return View(movimentacaoVeiculo);
        }

        // POST: MovimentacaoVeiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MovimentacaoVeiculo movimentacaoVeiculo = movimentacaoveiculoregras.buscarporID(id);
            movimentacaoveiculoregras.Remover(movimentacaoVeiculo);
            return RedirectToAction("Index");
        }

        public ActionResult FinalizarMovimentacao(int id)
        {
            try
            {
                var movimentacao = movimentacaoveiculoregras.FinalizarMovimentacao(id);
                return View(movimentacao);
            }
            catch (System.Exception exp)
            {
                ModelState.AddModelError(string.Empty, exp.Message);
            }
            return RedirectToAction("Index");
        }

        public JsonResult BuscaMensalistaPorPlaca(string placa)
        {
            var mensalista = mensalistaregras.BuscaPorPlaca(placa);
            if (mensalista == null)
                return Json("0", JsonRequestBehavior.AllowGet);
            return Json(mensalista.Pessoa.Nome, JsonRequestBehavior.AllowGet);
        }
    }
}
