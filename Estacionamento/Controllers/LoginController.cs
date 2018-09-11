﻿using System;
using System.Linq;
using System.Web.Mvc;
using Estacionamento.Models;
using RegrasNegocio.Regras;

namespace Estacionamento.Controllers
{

    public class LoginController : Controller
    {
        private UsuarioRegras usuarioregras = new UsuarioRegras();

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

            var funcionario = new Usuario()
            {
                Login = "thiago",
                Senha = "thiago"
            };

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