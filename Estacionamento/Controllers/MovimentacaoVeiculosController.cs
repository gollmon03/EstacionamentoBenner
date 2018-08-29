using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Estacionamento.Contexto;
using Estacionamento.Models;

namespace Estacionamento.Controllers
{
    public class MovimentacaoVeiculosController : Controller
    {
        private EstacionamentoContexto db = new EstacionamentoContexto();

        // GET: MovimentacaoVeiculos
        public ActionResult Index()
        {
            var movimentacaoVeiculos = db.MovimentacaoVeiculos.Include(m => m.Cliente).Include(m => m.ModeloVeiculo).Include(m => m.Usuario).Include(m => m.Vaga);
            return View(movimentacaoVeiculos.ToList());
        }

        // GET: MovimentacaoVeiculos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovimentacaoVeiculo movimentacaoVeiculo = db.MovimentacaoVeiculos.Find(id);
            if (movimentacaoVeiculo == null)
            {
                return HttpNotFound();
            }
            return View(movimentacaoVeiculo);
        }

        // GET: MovimentacaoVeiculos/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome");
            ViewBag.ModeloVeiculoId = new SelectList(db.ModeloVeiculos, "Id", "Marca");
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome");
            ViewBag.VagaId = new SelectList(db.Vagas, "Id", "Numero");
            return View();
        }

        // POST: MovimentacaoVeiculos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,DataHoraEntrada,DataHoraSaida,PlacaVeiculo,UsuarioId,ModeloVeiculoId,ClienteId,VagaId")] MovimentacaoVeiculo movimentacaoVeiculo)
        {
            if (ModelState.IsValid)
            {
                db.MovimentacaoVeiculos.Add(movimentacaoVeiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", movimentacaoVeiculo.ClienteId);
            ViewBag.ModeloVeiculoId = new SelectList(db.ModeloVeiculos, "Id", "Marca", movimentacaoVeiculo.ModeloVeiculoId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome", movimentacaoVeiculo.UsuarioId);
            ViewBag.VagaId = new SelectList(db.Vagas, "Id", "Numero", movimentacaoVeiculo.VagaId);
            return View(movimentacaoVeiculo);
        }

        // GET: MovimentacaoVeiculos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovimentacaoVeiculo movimentacaoVeiculo = db.MovimentacaoVeiculos.Find(id);
            if (movimentacaoVeiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", movimentacaoVeiculo.ClienteId);
            ViewBag.ModeloVeiculoId = new SelectList(db.ModeloVeiculos, "Id", "Marca", movimentacaoVeiculo.ModeloVeiculoId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome", movimentacaoVeiculo.UsuarioId);
            ViewBag.VagaId = new SelectList(db.Vagas, "Id", "Id", movimentacaoVeiculo.VagaId);
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
                db.Entry(movimentacaoVeiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClienteId = new SelectList(db.Clientes, "Id", "Nome", movimentacaoVeiculo.ClienteId);
            ViewBag.ModeloVeiculoId = new SelectList(db.ModeloVeiculos, "Id", "Marca", movimentacaoVeiculo.ModeloVeiculoId);
            ViewBag.UsuarioId = new SelectList(db.Usuarios, "Id", "Nome", movimentacaoVeiculo.UsuarioId);
            ViewBag.VagaId = new SelectList(db.Vagas, "Id", "Id", movimentacaoVeiculo.VagaId);
            return View(movimentacaoVeiculo);
        }

        // GET: MovimentacaoVeiculos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovimentacaoVeiculo movimentacaoVeiculo = db.MovimentacaoVeiculos.Find(id);
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
            MovimentacaoVeiculo movimentacaoVeiculo = db.MovimentacaoVeiculos.Find(id);
            db.MovimentacaoVeiculos.Remove(movimentacaoVeiculo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
