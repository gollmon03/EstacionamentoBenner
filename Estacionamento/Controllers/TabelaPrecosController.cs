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
    public class TabelaPrecosController : Controller
    {
        private EstacionamentoContexto db = new EstacionamentoContexto();

        // GET: TabelaPrecos
        public ActionResult Index()
        {
            var tabelaPrecos = db.TabelaPrecos.Include(t => t.TipoVeiculo);
            return View(tabelaPrecos.ToList());
        }

        // GET: TabelaPrecos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabelaPreco tabelaPreco = db.TabelaPrecos.Find(id);
            if (tabelaPreco == null)
            {
                return HttpNotFound();
            }
            return View(tabelaPreco);
        }

        // GET: TabelaPrecos/Create
        public ActionResult Create()
        {
            ViewBag.TipoVeiculoId = new SelectList(db.TipoVeiculos, "Id", "Nome");
            return View();
        }

        // POST: TabelaPrecos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,ValorHora,TipoVeiculoId")] TabelaPreco tabelaPreco)
        {
            if (ModelState.IsValid)
            {
                db.TabelaPrecos.Add(tabelaPreco);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoVeiculoId = new SelectList(db.TipoVeiculos, "Id", "Nome", tabelaPreco.TipoVeiculoId);
            return View(tabelaPreco);
        }

        // GET: TabelaPrecos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabelaPreco tabelaPreco = db.TabelaPrecos.Find(id);
            if (tabelaPreco == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoVeiculoId = new SelectList(db.ModeloVeiculos, "Id", "Nome", tabelaPreco.TipoVeiculoId);
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
                db.Entry(tabelaPreco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoVeiculoId = new SelectList(db.ModeloVeiculos, "Id", "Nome", tabelaPreco.TipoVeiculoId);
            return View(tabelaPreco);
        }

        // GET: TabelaPrecos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TabelaPreco tabelaPreco = db.TabelaPrecos.Find(id);
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
            TabelaPreco tabelaPreco = db.TabelaPrecos.Find(id);
            db.TabelaPrecos.Remove(tabelaPreco);
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
