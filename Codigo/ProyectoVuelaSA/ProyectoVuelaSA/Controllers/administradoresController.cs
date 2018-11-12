using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoVuelaSA.Models;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoVuelaSA.Controllers
{
    public class administradoresController : Controller
    {
        private ProyectoRequeEntities db = new ProyectoRequeEntities();

        // GET: administradores
        public ActionResult Index()
        {
            return View(db.usuario.ToList());
        }

        // GET: administradores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: administradores/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(usuario usuario)
        {
            if (ModelState.IsValid)
            {
                usuario.email = "";
                usuario.idpaisnacionalidad = 0;
                usuario.pasaporte = 0;
                db.usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Administrador", "Home", new { area = "" });
            }

            return View(usuario);
        }


        //Boarding pass
        public ActionResult BoardingPass()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult BoardingPass(reservacion reservacion)
        {
            usuario clienteConsulta = db.usuario.Where(u => u.pasaporte == reservacion.codreservacion).FirstOrDefault();
            reservacion reservacionConsulta = db.reservacion.Where(r => r.pasedeabordaje == reservacion.pasedeabordaje).FirstOrDefault();
            if ( reservacionConsulta != null)
            {
                if(clienteConsulta.idusuario == reservacionConsulta.codcliente)
                {
                    ModelState.AddModelError("", "Verificado");
                }
                else
                {
                    ModelState.AddModelError("", "Reservacion no coincide con el pasaporte");
                }
            }
            else
            {
                ModelState.AddModelError("", "Pase de abordaje no registrado");
            }
            return View();
        }


        //Check in

        public ActionResult CheckIn()
        {
            return View();
        }


  

        //Dispose

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
