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
    public class PosicionesController : Controller
    {
        private RRHHEntities db = new RRHHEntities();

        // GET: Posiciones
        public ActionResult Index()
        {
            return View(db.Posiciones.ToList());
        }

        // GET: Posiciones/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posicione posicione = db.Posiciones.Find(id);
            if (posicione == null)
            {
                return HttpNotFound();
            }
            return View(posicione);
        }

        // GET: Posiciones/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Posiciones/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Salario_Maximo,Salario_Minimo")] Posicione posicione)
        {
            if (ModelState.IsValid)
            {
                db.Posiciones.Add(posicione);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(posicione);
        }

        // GET: Posiciones/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posicione posicione = db.Posiciones.Find(id);
            if (posicione == null)
            {
                return HttpNotFound();
            }
            return View(posicione);
        }

        // POST: Posiciones/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Salario_Maximo,Salario_Minimo")] Posicione posicione)
        {
            if (ModelState.IsValid)
            {
                db.Entry(posicione).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(posicione);
        }

        // GET: Posiciones/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Posicione posicione = db.Posiciones.Find(id);
            if (posicione == null)
            {
                return HttpNotFound();
            }
            return View(posicione);
        }

        // POST: Posiciones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Posicione posicione = db.Posiciones.Find(id);
            db.Posiciones.Remove(posicione);
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
