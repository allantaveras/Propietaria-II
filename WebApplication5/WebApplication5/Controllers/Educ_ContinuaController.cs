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
    public class Educ_ContinuaController : Controller
    {
        private RRHHEntities db = new RRHHEntities();

        // GET: Educ_Continua
        public ActionResult Index()
        {
            var educ_Continua = db.Educ_Continua.Include(e => e.Aplicante);
            return View(educ_Continua.ToList());
        }

        // GET: Educ_Continua/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Educ_Continua educ_Continua = db.Educ_Continua.Find(id);
            if (educ_Continua == null)
            {
                return HttpNotFound();
            }
            return View(educ_Continua);
        }

        // GET: Educ_Continua/Create
        public ActionResult Create()
        {
            ViewBag.IDEducacionContinua = new SelectList(db.Aplicantes, "Id", "Nombre");
            return View();
        }

        // POST: Educ_Continua/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDEducacionContinua,IDAplicante,Costo,Descripcion,Duracion,Empresa")] Educ_Continua educ_Continua)
        {
            if (ModelState.IsValid)
            {
                db.Educ_Continua.Add(educ_Continua);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDEducacionContinua = new SelectList(db.Aplicantes, "Id", "Nombre", educ_Continua.IDEducacionContinua);
            return View(educ_Continua);
        }

        // GET: Educ_Continua/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Educ_Continua educ_Continua = db.Educ_Continua.Find(id);
            if (educ_Continua == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDEducacionContinua = new SelectList(db.Aplicantes, "Id", "Nombre", educ_Continua.IDEducacionContinua);
            return View(educ_Continua);
        }

        // POST: Educ_Continua/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDEducacionContinua,IDAplicante,Costo,Descripcion,Duracion,Empresa")] Educ_Continua educ_Continua)
        {
            if (ModelState.IsValid)
            {
                db.Entry(educ_Continua).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDEducacionContinua = new SelectList(db.Aplicantes, "Id", "Nombre", educ_Continua.IDEducacionContinua);
            return View(educ_Continua);
        }

        // GET: Educ_Continua/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Educ_Continua educ_Continua = db.Educ_Continua.Find(id);
            if (educ_Continua == null)
            {
                return HttpNotFound();
            }
            return View(educ_Continua);
        }

        // POST: Educ_Continua/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Educ_Continua educ_Continua = db.Educ_Continua.Find(id);
            db.Educ_Continua.Remove(educ_Continua);
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
