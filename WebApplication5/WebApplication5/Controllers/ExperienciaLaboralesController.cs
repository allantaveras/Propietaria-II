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
    public class ExperienciaLaboralesController : Controller
    {
        private RRHHEntities db = new RRHHEntities();

        // GET: ExperienciaLaborales
        public ActionResult Index()
        {
            var experienciaLaborales = db.ExperienciaLaborales.Include(e => e.Aplicante);
            return View(experienciaLaborales.ToList());
        }

        // GET: ExperienciaLaborales/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExperienciaLaborale experienciaLaborale = db.ExperienciaLaborales.Find(id);
            if (experienciaLaborale == null)
            {
                return HttpNotFound();
            }
            return View(experienciaLaborale);
        }

        // GET: ExperienciaLaborales/Create
        public ActionResult Create()
        {
            ViewBag.AplicanteId = new SelectList(db.Aplicantes, "Id", "Nombre");
            return View();
        }

        // POST: ExperienciaLaborales/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Compañia,Posicion,Fecha_Inicio,Fecha_Fin,AplicanteId")] ExperienciaLaborale experienciaLaborale)
        {
            if (ModelState.IsValid)
            {
                db.ExperienciaLaborales.Add(experienciaLaborale);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AplicanteId = new SelectList(db.Aplicantes, "Id", "Nombre", experienciaLaborale.AplicanteId);
            return View(experienciaLaborale);
        }

        // GET: ExperienciaLaborales/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExperienciaLaborale experienciaLaborale = db.ExperienciaLaborales.Find(id);
            if (experienciaLaborale == null)
            {
                return HttpNotFound();
            }
            ViewBag.AplicanteId = new SelectList(db.Aplicantes, "Id", "Nombre", experienciaLaborale.AplicanteId);
            return View(experienciaLaborale);
        }

        // POST: ExperienciaLaborales/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Compañia,Posicion,Fecha_Inicio,Fecha_Fin,AplicanteId")] ExperienciaLaborale experienciaLaborale)
        {
            if (ModelState.IsValid)
            {
                db.Entry(experienciaLaborale).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AplicanteId = new SelectList(db.Aplicantes, "Id", "Nombre", experienciaLaborale.AplicanteId);
            return View(experienciaLaborale);
        }

        // GET: ExperienciaLaborales/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ExperienciaLaborale experienciaLaborale = db.ExperienciaLaborales.Find(id);
            if (experienciaLaborale == null)
            {
                return HttpNotFound();
            }
            return View(experienciaLaborale);
        }

        // POST: ExperienciaLaborales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ExperienciaLaborale experienciaLaborale = db.ExperienciaLaborales.Find(id);
            db.ExperienciaLaborales.Remove(experienciaLaborale);
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
