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
    public class RecomendacionesController : Controller
    {
        private RRHHEntities db = new RRHHEntities();

        // GET: Recomendaciones
        public ActionResult Index()
        {
            var recomendaciones = db.Recomendaciones.Include(r => r.Aplicante);
            return View(recomendaciones.ToList());
        }

        // GET: Recomendaciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recomendacione recomendacione = db.Recomendaciones.Find(id);
            if (recomendacione == null)
            {
                return HttpNotFound();
            }
            return View(recomendacione);
        }

        // GET: Recomendaciones/Create
        public ActionResult Create()
        {
            ViewBag.AplicanteId = new SelectList(db.Aplicantes, "Id", "Nombre");
            return View();
        }

        // POST: Recomendaciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre_Empleado_Recomienda,AplicanteId")] Recomendacione recomendacione)
        {
            if (ModelState.IsValid)
            {
                db.Recomendaciones.Add(recomendacione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AplicanteId = new SelectList(db.Aplicantes, "Id", "Nombre", recomendacione.AplicanteId);
            return View(recomendacione);
        }

        // GET: Recomendaciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recomendacione recomendacione = db.Recomendaciones.Find(id);
            if (recomendacione == null)
            {
                return HttpNotFound();
            }
            ViewBag.AplicanteId = new SelectList(db.Aplicantes, "Id", "Nombre", recomendacione.AplicanteId);
            return View(recomendacione);
        }

        // POST: Recomendaciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre_Empleado_Recomienda,AplicanteId")] Recomendacione recomendacione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recomendacione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AplicanteId = new SelectList(db.Aplicantes, "Id", "Nombre", recomendacione.AplicanteId);
            return View(recomendacione);
        }

        // GET: Recomendaciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recomendacione recomendacione = db.Recomendaciones.Find(id);
            if (recomendacione == null)
            {
                return HttpNotFound();
            }
            return View(recomendacione);
        }

        // POST: Recomendaciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recomendacione recomendacione = db.Recomendaciones.Find(id);
            db.Recomendaciones.Remove(recomendacione);
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
