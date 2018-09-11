using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Estacionamento.Filtro;
using Estacionamento.Models;
using RegrasNegocio.Regras;

namespace Estacionamento.Controllers
{
    [AutorizacaoFilter]
    public class UsuariosController : Controller
    {
        private UsuarioRegras usuarioregras = new UsuarioRegras();

        // GET: Usuarios
        public ActionResult Index()
        {
            return View(usuarioregras.buscarTodos());
        }

        // GET: Usuarios/Details/5
        public ActionResult Details(int id)
        {
            Usuario usuario = usuarioregras.buscarporID(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // GET: Usuarios/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usuarios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Cpf,Login,Senha")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    usuarioregras.Adicionar(usuario);
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ModelState.AddModelError(String.Empty, "Esse CPF ja esta cadastrado");

                }
            }
            return View(usuario);
        }

        // GET: Usuarios/Edit/5
        public ActionResult Edit(int id)
        {
            Usuario usuario = usuarioregras.buscarporID(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Cpf")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuarioregras.Atualizar(usuario);
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        // GET: Usuarios/Delete/5
        public ActionResult Delete(int id)
        {
            Usuario usuario = usuarioregras.buscarporID(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // POST: Usuarios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = usuarioregras.buscarporID(id);
            usuarioregras.Remover(usuario);
            return RedirectToAction("Index");
        }
    }
}
