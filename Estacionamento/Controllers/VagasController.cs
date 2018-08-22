﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Estacionamento.Contexto;
using Estacionamento.Filtro;
using Estacionamento.Models;

namespace Estacionamento.Controllers
{
    [AutorizacaoFilter]
    public class VagasController : Controller
    {
        private EstacionamentoContexto db = new EstacionamentoContexto();

        // GET: Vagas
        public ActionResult Index()
        {
            
            var vagas = db.Vagas.Include(v => v.setor);
            var test = vagas.FirstOrDefault().Numero;
            return View(vagas.ToList());
        }

        // GET: Vagas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaga vaga = db.Vagas.Find(id);
            if (vaga == null)
            {
                return HttpNotFound();
            }
            return View(vaga);
        }

        // GET: Vagas/Create
        public ActionResult Create()
        {
            ViewBag.SetorId = new SelectList(db.Setores, "Id", "Nome");
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
                db.Vagas.Add(vaga);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.SetorId = new SelectList(db.Setores, "Id", "Nome", vaga.SetorId);
            return View(vaga);
        }

        // GET: Vagas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaga vaga = db.Vagas.Find(id);
            if (vaga == null)
            {
                return HttpNotFound();
            }
            ViewBag.SetorId = new SelectList(db.Setores, "Id", "Nome", vaga.SetorId);
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
                db.Entry(vaga).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SetorId = new SelectList(db.Setores, "Id", "Nome", vaga.SetorId);
            return View(vaga);
        }

        // GET: Vagas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Vaga vaga = db.Vagas.Find(id);
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
            Vaga vaga = db.Vagas.Find(id);
            db.Vagas.Remove(vaga);
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
