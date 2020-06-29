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
    public class ZorgverlenerController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Zorgverlener
        public ActionResult Index()
        {
            return View(db.Zorgverleners.ToList());
        }

        // GET: Zorgverlener/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zorgverlener zorgverlener = db.Zorgverleners.Find(id);
            if (zorgverlener == null)
            {
                return HttpNotFound();
            }
            return View(zorgverlener);
        }

        // GET: Zorgverlener/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zorgverlener/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Zorgverlener_ID,Naam,Functie")] Zorgverlener zorgverlener)
        {
            if (ModelState.IsValid)
            {
                db.Zorgverleners.Add(zorgverlener);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(zorgverlener);
        }

        // GET: Zorgverlener/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zorgverlener zorgverlener = db.Zorgverleners.Find(id);
            if (zorgverlener == null)
            {
                return HttpNotFound();
            }
            return View(zorgverlener);
        }

        // POST: Zorgverlener/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Zorgverlener_ID,Naam,Functie")] Zorgverlener zorgverlener)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zorgverlener).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(zorgverlener);
        }

        // GET: Zorgverlener/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zorgverlener zorgverlener = db.Zorgverleners.Find(id);
            if (zorgverlener == null)
            {
                return HttpNotFound();
            }
            return View(zorgverlener);
        }

        // POST: Zorgverlener/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Zorgverlener zorgverlener = db.Zorgverleners.Find(id);
            db.Zorgverleners.Remove(zorgverlener);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DashboardZorgverlener()
        {
            return View();
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
