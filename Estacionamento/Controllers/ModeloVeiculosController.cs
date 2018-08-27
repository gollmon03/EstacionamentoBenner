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
    public class ModeloVeiculosController : Controller
    {
        private EstacionamentoContexto db = new EstacionamentoContexto();

        // GET: ModeloVeiculos
        public ActionResult Index()
        {
            var modeloVeiculos = db.ModeloVeiculos.Include(m => m.TipoVeiculo);
            return View(modeloVeiculos.ToList());
        }

        // GET: ModeloVeiculos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeloVeiculo modeloVeiculo = db.ModeloVeiculos.Find(id);
            if (modeloVeiculo == null)
            {
                return HttpNotFound();
            }
            return View(modeloVeiculo);
        }

        // GET: ModeloVeiculos/Create
        public ActionResult Create()
        {
            ViewBag.TipoVeiculoId = new SelectList(db.ModeloVeiculos, "Id", "Nome");
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
                db.ModeloVeiculos.Add(modeloVeiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoVeiculoId = new SelectList(db.ModeloVeiculos, "Id", "Nome", modeloVeiculo.TipoVeiculoId);
            return View(modeloVeiculo);
        }

        // GET: ModeloVeiculos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeloVeiculo modeloVeiculo = db.ModeloVeiculos.Find(id);
            if (modeloVeiculo == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoVeiculoId = new SelectList(db.ModeloVeiculos, "Id", "Nome", modeloVeiculo.TipoVeiculoId);
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
                db.Entry(modeloVeiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoVeiculoId = new SelectList(db.ModeloVeiculos, "Id", "Nome", modeloVeiculo.TipoVeiculoId);
            return View(modeloVeiculo);
        }

        // GET: ModeloVeiculos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ModeloVeiculo modeloVeiculo = db.ModeloVeiculos.Find(id);
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
            ModeloVeiculo modeloVeiculo = db.ModeloVeiculos.Find(id);
            db.ModeloVeiculos.Remove(modeloVeiculo);
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
