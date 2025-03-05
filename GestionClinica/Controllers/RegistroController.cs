using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Roles = GestionClinica.Models.Roles;
using GestionClinica.Models;
using System.Web.Security;

namespace GestionClinica.Controllers
{

    public class RegistroController : Controller
    {
        GestionMedicaEntities2 conexion = new GestionMedicaEntities2();
        // GET: Registro
        public ActionResult Registro()
        {
            if (!conexion.Roles.Any())
            {
                var roles = new List<Roles>
                {
                    new Roles {NombreRol = "Administrador"},
                    new Roles {NombreRol = "Usuarios"}

                };
                conexion.Roles.AddRange(roles);
                conexion.SaveChanges();
            
            }
            
            var rolesList = conexion.Roles.ToList();
            ViewBag.Roles = new SelectList(rolesList, "IdRol", "NombreRol");
            return View();
        }
        [HttpPost]
        public ActionResult Registro(Usuarios usuario, int idRol)
        {
            if (ModelState.IsValid)
            {
                usuario.IdRol = idRol;
                usuario.Activo = true;
                conexion.Usuarios.Add(usuario);
                conexion.SaveChanges();
                FormsAuthentication.SetAuthCookie(usuario.CorreoElectronico, false);
                return RedirectToAction("AccesoUsuario", "Acceso");
            }
 
            return View(usuario);
        }
    }
}