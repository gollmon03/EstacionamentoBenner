using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Estacionamento.Contexto;

namespace Estacionamento.Controllers
{

    public class LoginController : Controller
    {
        private EstacionamentoContexto db = new EstacionamentoContexto();

        [HttpGet]
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [ValidateAntiForgeryToken]
        [HttpPost]
        public ActionResult Index(String login, String senha)
        {

            var funcionario = db.Usuarios.Where(u => u.Login == login && u.Senha == senha).FirstOrDefault();
            if (funcionario != null)
            {
                Session["usuarioLogado"] = funcionario;
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Login ou senha invalido");
                return View();
            }
        }


        public ActionResult Deslogar()
        {
            if (Session["usuarioLogado"] != null)
            {
                Session["usuarioLogado"] = null;
            }
            return RedirectToAction("Index");
        }

    }
}