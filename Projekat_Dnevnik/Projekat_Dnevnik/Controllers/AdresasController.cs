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
    public class AdresasController : Controller
    {
        private DnevnikEntities db = new DnevnikEntities();

        // GET: Adresas
       
        public ActionResult Index()
        {
            var adresa = db.Adresa.Include(a => a.Ucenik).Include(a => a.Vrsta_Adresa);
            return View(adresa.ToList());
        }

        // GET: Adresas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresa adresa = db.Adresa.Find(id);
            if (adresa == null)
            {
                return HttpNotFound();
            }
            return View(adresa);
        }

        // GET: Adresas/Create
        public ActionResult Create()
        {
            ViewBag.IDOsobe = new SelectList(db.Ucenik, "IDOsobe", "Ime");
            ViewBag.IDOznakeAdresa = new SelectList(db.Vrsta_Adresa, "IDOznakeAdresa", "Ime_OznakeAdresa");
            return View();
        }

        // POST: Adresas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Adresa1,Postanski_Broj,Grad,IDOsobe,IDOznakeAdresa")] Adresa adresa)
        {
            if (ModelState.IsValid)
            {
                db.Adresa.Add(adresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDOsobe = new SelectList(db.Ucenik, "IDOsobe", "Ime", adresa.IDOsobe);
            ViewBag.IDOznakeAdresa = new SelectList(db.Vrsta_Adresa, "IDOznakeAdresa", "Ime_OznakeAdresa", adresa.IDOznakeAdresa);
            return View(adresa);
        }

        // GET: Adresas/Edit/5
        
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresa adresa = db.Adresa.Find(id);
            if (adresa == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDOsobe = new SelectList(db.Ucenik, "IDOsobe", "Ime", adresa.IDOsobe);
            ViewBag.IDOznakeAdresa = new SelectList(db.Vrsta_Adresa, "IDOznakeAdresa", "Ime_OznakeAdresa", adresa.IDOznakeAdresa);
            return View(adresa);
        }

        // POST: Adresas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Adresa1,Postanski_Broj,Grad,IDOsobe,IDOznakeAdresa")] Adresa adresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDOsobe = new SelectList(db.Ucenik, "IDOsobe", "Ime", adresa.IDOsobe);
            ViewBag.IDOznakeAdresa = new SelectList(db.Vrsta_Adresa, "IDOznakeAdresa", "Ime_OznakeAdresa", adresa.IDOznakeAdresa);
            return View(adresa);
        }

        // GET: Adresas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Adresa adresa = db.Adresa.Find(id);
            if (adresa == null)
            {
                return HttpNotFound();
            }
            return View(adresa);
        }

        // POST: Adresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Adresa adresa = db.Adresa.Find(id);
            db.Adresa.Remove(adresa);
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
