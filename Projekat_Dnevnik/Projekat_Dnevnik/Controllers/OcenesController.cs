using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Projekat_Dnevnik.Models;

namespace Projekat_Dnevnik.Controllers
{
    public class OcenesController : Controller
    {
        private DnevnikEntities db = new DnevnikEntities();

        // GET: Ocenes
        public ActionResult Index()
        {
            var ocene = db.Ocene.Include(o => o.Ucenik);
            return View(ocene.ToList());
        }

        // GET: Ocenes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ocene ocene = db.Ocene.Find(id);
            if (ocene == null)
            {
                return HttpNotFound();
            }
            return View(ocene);
        }

        // GET: Ocenes/Create
        public ActionResult Create()
        {
            ViewBag.IDOsoba = new SelectList(db.Ucenik, "IDOsobe", "Ime");
            return View();
        }

        // POST: Ocenes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDOsoba,Srpski,Matematika,Istorija,Geografija,Informatika,Fizicko,Vladanje")] Ocene ocene)
        {
            if (ModelState.IsValid)
            {
                db.Ocene.Add(ocene);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDOsoba = new SelectList(db.Ucenik, "IDOsobe", "Ime", ocene.IDOsoba);
            return View(ocene);
        }

        // GET: Ocenes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ocene ocene = db.Ocene.Find(id);
            if (ocene == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDOsoba = new SelectList(db.Ucenik, "IDOsobe", "Ime", ocene.IDOsoba);
            return View(ocene);
        }

        // POST: Ocenes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDOsoba,Srpski,Matematika,Istorija,Geografija,Informatika,Fizicko,Vladanje")] Ocene ocene)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ocene).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDOsoba = new SelectList(db.Ucenik, "IDOsobe", "Ime", ocene.IDOsoba);
            return View(ocene);
        }

        // GET: Ocenes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ocene ocene = db.Ocene.Find(id);
            if (ocene == null)
            {
                return HttpNotFound();
            }
            return View(ocene);
        }

        // POST: Ocenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ocene ocene = db.Ocene.Find(id);
            db.Ocene.Remove(ocene);
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
