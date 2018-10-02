using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Entidades.Entidades;
using Entidades.Entidades.Enuns;
using Estacionamento.Models;

namespace Estacionamento.Filtro
{
    public class AutorizacaoFilterAttribute : ActionFilterAttribute
    {
        private readonly TipoUsuario PapelPermitido;

        public AutorizacaoFilterAttribute(TipoUsuario papelPermitido = TipoUsuario.Operador)
        {
            PapelPermitido = papelPermitido;
        }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            Usuario usuarioLogado = filterContext.HttpContext.Session["usuarioLogado"] as Usuario;
            if (usuarioLogado == null)
            {                
                filterContext.Result = new RedirectToRouteResult(
                          new RouteValueDictionary(
                              new { action = "Index", controller = "Login" }));
                return;
            }
             
            if (usuarioLogado.Papel != TipoUsuario.Administrador)
            {
                if (usuarioLogado.Papel != PapelPermitido)
                {
                    filterContext.Result = new RedirectToRouteResult(
                              new RouteValueDictionary(
                                  new { action = "Index", controller = "Login" }));
                }
            } 
        }
    }
}