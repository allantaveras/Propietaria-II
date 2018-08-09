using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class AplicantesController : Controller
    {
        private RRHHEntities db = new RRHHEntities();

        // GET: Aplicantes
        public ActionResult Index()
        {
            var aplicantes = db.Aplicantes.Include(a => a.Posicione);
            return View(aplicantes.ToList());
        }

        // GET: Aplicantes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aplicante aplicante = db.Aplicantes.Find(id);
            if (aplicante == null)
            {
                return HttpNotFound();
            }
            return View(aplicante);
        }

        // GET: Aplicantes/Create
        public ActionResult Create()
        {
            ViewBag.IdPosicion = new SelectList(db.Posiciones, "Id", "Nombre");
            return View();
        }

        // POST: Aplicantes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,IdPosicion,Salario_Esperado,Fecha_Ultima_Aplicacion,Cedula")] Aplicante aplicante)
        {
            if (ModelState.IsValid)
            {
                db.Aplicantes.Add(aplicante);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdPosicion = new SelectList(db.Posiciones, "Id", "Nombre", aplicante.IdPosicion);
            return View(aplicante);
        }

        // GET: Aplicantes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aplicante aplicante = db.Aplicantes.Find(id);
            if (aplicante == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdPosicion = new SelectList(db.Posiciones, "Id", "Nombre", aplicante.IdPosicion);
            return View(aplicante);
        }

        // POST: Aplicantes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,IdPosicion,Salario_Esperado,Fecha_Ultima_Aplicacion,Cedula")] Aplicante aplicante)
        {
            if (ModelState.IsValid)
            {
                db.Entry(aplicante).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdPosicion = new SelectList(db.Posiciones, "Id", "Nombre", aplicante.IdPosicion);
            return View(aplicante);
        }

        // GET: Aplicantes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Aplicante aplicante = db.Aplicantes.Find(id);
            if (aplicante == null)
            {
                return HttpNotFound();
            }
            return View(aplicante);
        }

        // POST: Aplicantes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Aplicante aplicante = db.Aplicantes.Find(id);
            db.Aplicantes.Remove(aplicante);
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
