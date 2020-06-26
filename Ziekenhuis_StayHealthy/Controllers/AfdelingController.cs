using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ziekenhuis_StayHealthy.Models;

namespace Ziekenhuis_StayHealthy.Controllers
{
    public class AfdelingController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Afdeling
        public ActionResult Index()
        {
            return View(db.Afdelings.ToList());
        }

        // GET: Afdeling/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afdeling afdeling = db.Afdelings.Find(id);
            if (afdeling == null)
            {
                return HttpNotFound();
            }
            return View(afdeling);
        }

        // GET: Afdeling/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Afdeling/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Afdeling_ID,Naam,Max_Patiënt")] Afdeling afdeling)
        {
            if (ModelState.IsValid)
            {
                db.Afdelings.Add(afdeling);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(afdeling);
        }

        // GET: Afdeling/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afdeling afdeling = db.Afdelings.Find(id);
            if (afdeling == null)
            {
                return HttpNotFound();
            }
            return View(afdeling);
        }

        // POST: Afdeling/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Afdeling_ID,Naam,Max_Patiënt")] Afdeling afdeling)
        {
            if (ModelState.IsValid)
            {
                db.Entry(afdeling).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(afdeling);
        }

        // GET: Afdeling/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Afdeling afdeling = db.Afdelings.Find(id);
            if (afdeling == null)
            {
                return HttpNotFound();
            }
            return View(afdeling);
        }

        // POST: Afdeling/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Afdeling afdeling = db.Afdelings.Find(id);
            db.Afdelings.Remove(afdeling);
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
