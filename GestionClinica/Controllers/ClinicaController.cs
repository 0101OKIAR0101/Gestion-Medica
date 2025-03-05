using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GestionClinica.Models;

namespace GestionClinica.Controllers
{
    public class ClinicaController : Controller
    {
        GestionMedicaEntities2 conexion = new GestionMedicaEntities2();
    
        // GET: Clinica
        public ActionResult ListaClinicas()
        {
            ViewBag.rolusuario = 1;
            var clinicas = conexion.Clinicas.ToList();
            return View(clinicas);
        }

        public ActionResult ListaClinicas2(int? id)
        {
            ViewBag.rolusuario = 2;
            var clinicas = conexion.Clinicas.ToList();
            return View(clinicas);
        }



        public ActionResult CrearClinica()
        {
            ViewBag.rolusuario = 1;
            return View();
        }
        [HttpPost]
        public ActionResult CrearClinica([Bind(Include = "idClinica,Nombre,Direccion,Ciudad,Comuna,Fechadehora,Hora,Activo" )]Clinicas clinicas)
        {
            if (ModelState.IsValid)
            {
                conexion.Clinicas.Add(clinicas);
                conexion.SaveChanges();
                return RedirectToAction("ListaClinicas");   
            }
            return View(clinicas);
        }

        public ActionResult CrearClinica2()
        {
            ViewBag.rolusuario = 2;
            return View();
        }
        [HttpPost]
        public ActionResult CrearClinica2([Bind(Include = "idClinica,Nombre,Direccion,Ciudad,Comuna,Fechadehora,Hora,Activo")] Clinicas clinicas)
        {
            if (ModelState.IsValid)
            {
                conexion.Clinicas.Add(clinicas);
                conexion.SaveChanges();
                return RedirectToAction("ListaClinicas2");
            }
            return View(clinicas);
        }


        public ActionResult EditarClinica(int? id)
        {
            ViewBag.rolusuario = 1;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Clinicas clinicas = conexion.Clinicas.Find(id); 

            if (clinicas == null)
            {
                return HttpNotFound();
            }
            return View(clinicas);
        }

        [HttpPost]
        public ActionResult EditarClinica([Bind(Include = "idClinica,Nombre,Direccion,Ciudad,Comuna,Fechadehora,Hora,Activo")] Clinicas clinicas)
        {
            if (ModelState.IsValid)
            {
                conexion.Entry(clinicas).State = System.Data.Entity.EntityState.Modified;
                conexion.SaveChanges();
                return RedirectToAction("ListaClinicas");
            }
            return View(clinicas);
        }

        public ActionResult DetalleClinica(int? id)
        {
            ViewBag.rolusuario = 1;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Clinicas clinicas = conexion.Clinicas.Find(id);

            if (clinicas == null)
            {
                return HttpNotFound();
            }
            return View(clinicas);
        }

        public ActionResult DetalleClinica2(int? id)
        {
            ViewBag.rolusuario = 2;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Clinicas clinicas = conexion.Clinicas.Find(id);

            if (clinicas == null)
            {
                return HttpNotFound();
            }
            return View(clinicas);
        }



        public ActionResult BorrarClinica(int? id)
        {
            ViewBag.rolusuario = 1;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Clinicas clinicas = conexion.Clinicas.Find(id);

            if (clinicas == null)
            {
                return HttpNotFound();
            }
            return View(clinicas);
        }

        [HttpPost, ActionName("BorrarClinica")]

        public ActionResult BorrarClinica(int id)
        {

            Clinicas clinicas = conexion.Clinicas.Find(id);
            conexion.Clinicas.Remove(clinicas);
            conexion.SaveChanges();
            return RedirectToAction("ListaClinicas");

        }


    }

}