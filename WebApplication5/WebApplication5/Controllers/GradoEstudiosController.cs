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
    public class GradoEstudiosController : Controller
    {
        private RRHHEntities db = new RRHHEntities();

        // GET: GradoEstudios
        public ActionResult Index()
        {
            var gradoEstudios = db.GradoEstudios.Include(g => g.Aplicante);
            return View(gradoEstudios.ToList());
        }

        // GET: GradoEstudios/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradoEstudio gradoEstudio = db.GradoEstudios.Find(id);
            if (gradoEstudio == null)
            {
                return HttpNotFound();
            }
            return View(gradoEstudio);
        }

        // GET: GradoEstudios/Create
        public ActionResult Create()
        {
            ViewBag.AplicanteId = new SelectList(db.Aplicantes, "Id", "Nombre");
            return View();
        }

        // POST: GradoEstudios/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre_Institucion,Titulo,Fecha_Graduacion,AplicanteId")] GradoEstudio gradoEstudio)
        {
            if (ModelState.IsValid)
            {
                db.GradoEstudios.Add(gradoEstudio);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AplicanteId = new SelectList(db.Aplicantes, "Id", "Nombre", gradoEstudio.AplicanteId);
            return View(gradoEstudio);
        }

        // GET: GradoEstudios/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradoEstudio gradoEstudio = db.GradoEstudios.Find(id);
            if (gradoEstudio == null)
            {
                return HttpNotFound();
            }
            ViewBag.AplicanteId = new SelectList(db.Aplicantes, "Id", "Nombre", gradoEstudio.AplicanteId);
            return View(gradoEstudio);
        }

        // POST: GradoEstudios/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre_Institucion,Titulo,Fecha_Graduacion,AplicanteId")] GradoEstudio gradoEstudio)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gradoEstudio).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AplicanteId = new SelectList(db.Aplicantes, "Id", "Nombre", gradoEstudio.AplicanteId);
            return View(gradoEstudio);
        }

        // GET: GradoEstudios/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GradoEstudio gradoEstudio = db.GradoEstudios.Find(id);
            if (gradoEstudio == null)
            {
                return HttpNotFound();
            }
            return View(gradoEstudio);
        }

        // POST: GradoEstudios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GradoEstudio gradoEstudio = db.GradoEstudios.Find(id);
            db.GradoEstudios.Remove(gradoEstudio);
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
