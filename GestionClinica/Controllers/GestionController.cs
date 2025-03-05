using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace GestionClinica.Controllers
{
    public class GestionController : Controller
    {
        // GET: Gestion
        public ActionResult GestionAdministrador()
        {
            ViewBag.rolusuario = 1;
            return View();
        }

        public ActionResult Gestionusuario()
        {
            ViewBag.rolusuario = 2;
            return View();
        }

        public ActionResult cerrarsesion()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Index", "Home");
        }
    }
}