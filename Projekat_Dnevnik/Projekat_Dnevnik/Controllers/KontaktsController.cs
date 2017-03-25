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
    public class KontaktsController : Controller
    {
        private DnevnikEntities db = new DnevnikEntities();

        // GET: Kontakts
        public ActionResult Index()
        {
            var kontakt = db.Kontakt.Include(k => k.Ucenik).Include(k => k.Vrsta_Kontakta);
            return View(kontakt.ToList());
        }

        // GET: Kontakts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontakt kontakt = db.Kontakt.Find(id);
            if (kontakt == null)
            {
                return HttpNotFound();
            }
            return View(kontakt);
        }

        // GET: Kontakts/Create
        public ActionResult Create()
        {
            ViewBag.IDOsobe = new SelectList(db.Ucenik, "IDOsobe", "Ime");
            ViewBag.IDOznake = new SelectList(db.Vrsta_Kontakta, "IDOznake", "Ime_Oznake");
            return View();
        }

        // POST: Kontakts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Broj_Telefona,Lokal,IDOsobe,IDOznake")] Kontakt kontakt)
        {
            if (ModelState.IsValid)
            {
                db.Kontakt.Add(kontakt);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDOsobe = new SelectList(db.Ucenik, "IDOsobe", "Ime", kontakt.IDOsobe);
            ViewBag.IDOznake = new SelectList(db.Vrsta_Kontakta, "IDOznake", "Ime_Oznake", kontakt.IDOznake);
            return View(kontakt);
        }

        // GET: Kontakts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontakt kontakt = db.Kontakt.Find(id);
            if (kontakt == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDOsobe = new SelectList(db.Ucenik, "IDOsobe", "Ime", kontakt.IDOsobe);
            ViewBag.IDOznake = new SelectList(db.Vrsta_Kontakta, "IDOznake", "Ime_Oznake", kontakt.IDOznake);
            return View(kontakt);
        }

        // POST: Kontakts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Broj_Telefona,Lokal,IDOsobe,IDOznake")] Kontakt kontakt)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kontakt).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDOsobe = new SelectList(db.Ucenik, "IDOsobe", "Ime", kontakt.IDOsobe);
            ViewBag.IDOznake = new SelectList(db.Vrsta_Kontakta, "IDOznake", "Ime_Oznake", kontakt.IDOznake);
            return View(kontakt);
        }

        // GET: Kontakts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Kontakt kontakt = db.Kontakt.Find(id);
            if (kontakt == null)
            {
                return HttpNotFound();
            }
            return View(kontakt);
        }

        // POST: Kontakts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Kontakt kontakt = db.Kontakt.Find(id);
            db.Kontakt.Remove(kontakt);
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
