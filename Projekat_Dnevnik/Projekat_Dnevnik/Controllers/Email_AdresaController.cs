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
    public class Email_AdresaController : Controller
    {
        private DnevnikEntities db = new DnevnikEntities();

        // GET: Email_Adresa
        public ActionResult Index()
        {
            var email_Adresa = db.Email_Adresa.Include(e => e.Ucenik).Include(e => e.Vrsta_Email);
            return View(email_Adresa.ToList());
        }

        // GET: Email_Adresa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Email_Adresa email_Adresa = db.Email_Adresa.Find(id);
            if (email_Adresa == null)
            {
                return HttpNotFound();
            }
            return View(email_Adresa);
        }

        // GET: Email_Adresa/Create
        public ActionResult Create()
        {
            ViewBag.IDOsobe = new SelectList(db.Ucenik, "IDOsobe", "Ime");
            ViewBag.IDOznakeMail = new SelectList(db.Vrsta_Email, "IDOznakeMail", "Ime_OznakeMail");
            return View();
        }

        // POST: Email_Adresa/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Adresa,IDOsobe,IDOznakeMail")] Email_Adresa email_Adresa)
        {
            if (ModelState.IsValid)
            {
                db.Email_Adresa.Add(email_Adresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IDOsobe = new SelectList(db.Ucenik, "IDOsobe", "Ime", email_Adresa.IDOsobe);
            ViewBag.IDOznakeMail = new SelectList(db.Vrsta_Email, "IDOznakeMail", "Ime_OznakeMail", email_Adresa.IDOznakeMail);
            return View(email_Adresa);
        }

        // GET: Email_Adresa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Email_Adresa email_Adresa = db.Email_Adresa.Find(id);
            if (email_Adresa == null)
            {
                return HttpNotFound();
            }
            ViewBag.IDOsobe = new SelectList(db.Ucenik, "IDOsobe", "Ime", email_Adresa.IDOsobe);
            ViewBag.IDOznakeMail = new SelectList(db.Vrsta_Email, "IDOznakeMail", "Ime_OznakeMail", email_Adresa.IDOznakeMail);
            return View(email_Adresa);
        }

        // POST: Email_Adresa/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Adresa,IDOsobe,IDOznakeMail")] Email_Adresa email_Adresa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(email_Adresa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IDOsobe = new SelectList(db.Ucenik, "IDOsobe", "Ime", email_Adresa.IDOsobe);
            ViewBag.IDOznakeMail = new SelectList(db.Vrsta_Email, "IDOznakeMail", "Ime_OznakeMail", email_Adresa.IDOznakeMail);
            return View(email_Adresa);
        }

        // GET: Email_Adresa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Email_Adresa email_Adresa = db.Email_Adresa.Find(id);
            if (email_Adresa == null)
            {
                return HttpNotFound();
            }
            return View(email_Adresa);
        }

        // POST: Email_Adresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Email_Adresa email_Adresa = db.Email_Adresa.Find(id);
            db.Email_Adresa.Remove(email_Adresa);
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
