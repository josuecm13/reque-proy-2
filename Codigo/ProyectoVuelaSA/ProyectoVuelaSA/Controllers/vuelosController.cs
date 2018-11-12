using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoVuelaSA.Models;

namespace ProyectoVuelaSA.Controllers
{
    public class vuelosController : Controller
    {
        private ProyectoRequeEntities db = new ProyectoRequeEntities();

        // GET: vuelos
        public ActionResult Index()
        {
            var vuelo = db.vuelo.Include(v => v.aeropuerto).Include(v => v.aeropuerto1);
            return View(vuelo.ToList());
        }

        // GET: vuelos/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vuelo vuelo = db.vuelo.Find(id);
            if (vuelo == null)
            {
                return HttpNotFound();
            }
            return View(vuelo);
        }

        // GET: vuelos/Create
        public ActionResult Create()
        {
            ViewBag.aeropuertosalida = new SelectList(db.aeropuerto, "idaeropuerto", "ciudadnombre");
            ViewBag.aeropuertodestino = new SelectList(db.aeropuerto, "idaeropuerto", "ciudadnombre");
            return View();
        }

        // POST: vuelos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idvuelo,aeropuertosalida,aeropuertodestino,fechasalida,fechallegada,precioturista,precioejecutiva,precioprimeraclase")] vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                db.vuelo.Add(vuelo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.aeropuertosalida = new SelectList(db.aeropuerto, "idaeropuerto", "ciudadnombre", vuelo.aeropuertosalida);
            ViewBag.aeropuertodestino = new SelectList(db.aeropuerto, "idaeropuerto", "ciudadnombre", vuelo.aeropuertodestino);
            return View(vuelo);
        }

        // GET: vuelos/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vuelo vuelo = db.vuelo.Find(id);
            if (vuelo == null)
            {
                return HttpNotFound();
            }
            ViewBag.aeropuertosalida = new SelectList(db.aeropuerto, "idaeropuerto", "ciudadnombre", vuelo.aeropuertosalida);
            ViewBag.aeropuertodestino = new SelectList(db.aeropuerto, "idaeropuerto", "ciudadnombre", vuelo.aeropuertodestino);
            return View(vuelo);
        }

        // POST: vuelos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "idvuelo,aeropuertosalida,aeropuertodestino,fechasalida,fechallegada,precioturista,precioejecutiva,precioprimeraclase")] vuelo vuelo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vuelo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.aeropuertosalida = new SelectList(db.aeropuerto, "idaeropuerto", "ciudadnombre", vuelo.aeropuertosalida);
            ViewBag.aeropuertodestino = new SelectList(db.aeropuerto, "idaeropuerto", "ciudadnombre", vuelo.aeropuertodestino);
            return View(vuelo);
        }

        // GET: vuelos/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            vuelo vuelo = db.vuelo.Find(id);
            if (vuelo == null)
            {
                return HttpNotFound();
            }
            return View(vuelo);
        }

        // POST: vuelos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            vuelo vuelo = db.vuelo.Find(id);
            db.vuelo.Remove(vuelo);
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
