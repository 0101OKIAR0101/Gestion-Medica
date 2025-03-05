using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GestionClinica.Models;

namespace GestionClinica.Controllers
{
    public class AccesoController : Controller
    {
        GestionMedicaEntities2 conexion = new GestionMedicaEntities2();
        // GET: Acceso
        public ActionResult AccesoUsuario()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AccesoUsuario(Usuarios datos)
        {
            if (ModelState.IsValid)
            {

                var Usuario = conexion.Usuarios.FirstOrDefault(u => u.CorreoElectronico == datos.CorreoElectronico && u.Clave == datos.Clave);

                if (Usuario != null)
                {
                    if (Usuario.IdRol == 1)
                    {
                        return RedirectToAction("GestionAdministrador", "Gestion");
                    }
                    else if (Usuario.IdRol == 2)
                    {
                        return RedirectToAction("GestionUsuario", "Gestion");
                    }
                    else
                    {
                        return RedirectToAction("Error", "Gestion");
                    }
                }
            }

            return View();


        }
    } 
}