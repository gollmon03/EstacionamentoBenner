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
    public class TipoVeiculosController : Controller
    {
        private EstacionamentoContexto db = new EstacionamentoContexto();

        // GET: TipoVeiculos
        public ActionResult Index()
        {
            return View(db.TipoVeiculos.ToList());
        }

        // GET: TipoVeiculos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoVeiculo tipoVeiculo = db.TipoVeiculos.Find(id);
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
                db.TipoVeiculos.Add(tipoVeiculo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoVeiculo);
        }

        // GET: TipoVeiculos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoVeiculo tipoVeiculo = db.TipoVeiculos.Find(id);
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
                db.Entry(tipoVeiculo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoVeiculo);
        }

        // GET: TipoVeiculos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoVeiculo tipoVeiculo = db.TipoVeiculos.Find(id);
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
            TipoVeiculo tipoVeiculo = db.TipoVeiculos.Find(id);
            db.TipoVeiculos.Remove(tipoVeiculo);
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
