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
    public class UceniksController : Controller
    {
        private DnevnikEntities db = new DnevnikEntities();

        // GET: Uceniks
        public ActionResult Index()
        {
            var ucenik = db.Ucenik.Include(u => u.Ocene);
            return View(ucenik.ToList());
        }

        // GET: Uceniks/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ucenik ucenik = db.Ucenik.Find(id);
            if (ucenik == null)
            {
                return HttpNotFound();
            }
            return View(ucenik);
        }

        // GET: Uceniks/Create
        public ActionResult Create()
        {
            ViewBag.IDOsobe = new SelectList(db.Ocene, "IDOsoba", "Srpski");
            return View();
        }

        // POST: Uceniks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDOsobe,Ime,Prezime,Ime_Roditelja,JMBG,Datum_Rodjenja,Mesto_Rodjenja,Opstina_Rodjenja,Pol,Broj_Licne_Karte,Fotografija,Beleska,Pin")] Ucenik ucenik)
        {
            if (ModelState.IsValid)
            {
                db.Ucenik.Add(ucenik);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDOsobe = new SelectList(db.Ocene, "IDOsoba", "Srpski", ucenik.IDOsobe);
            return View(ucenik);
        }

        // GET: Uceniks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ucenik ucenik = db.Ucenik.Find(id);
            if (ucenik == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDOsobe = new SelectList(db.Ocene, "IDOsoba", "Srpski", ucenik.IDOsobe);
            return View(ucenik);
        }

        // POST: Uceniks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDOsobe,Ime,Prezime,Ime_Roditelja,JMBG,Datum_Rodjenja,Mesto_Rodjenja,Opstina_Rodjenja,Pol,Broj_Licne_Karte,Fotografija,Beleska,Pin")] Ucenik ucenik)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ucenik).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDOsobe = new SelectList(db.Ocene, "IDOsoba", "Srpski", ucenik.IDOsobe);
            return View(ucenik);
        }

        // GET: Uceniks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ucenik ucenik = db.Ucenik.Find(id);
            if (ucenik == null)
            {
                return HttpNotFound();
            }
            return View(ucenik);
        }

        // POST: Uceniks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ucenik ucenik = db.Ucenik.Find(id);
            db.Ucenik.Remove(ucenik);
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
