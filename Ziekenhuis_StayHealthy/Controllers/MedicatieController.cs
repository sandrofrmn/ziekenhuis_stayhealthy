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
    public class MedicatieController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Medicatie
        public ActionResult Index()
        {
            return View(db.Medicaties.ToList());
        }

        // GET: Medicatie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicatie medicatie = db.Medicaties.Find(id);
            if (medicatie == null)
            {
                return HttpNotFound();
            }
            return View(medicatie);
        }

        // GET: Medicatie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Medicatie/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Medicatie_ID,Naam,Merk,Dosis,Patient_ID")] Medicatie medicatie)
        {
            if (ModelState.IsValid)
            {
                db.Medicaties.Add(medicatie);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicatie);
        }

        // GET: Medicatie/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicatie medicatie = db.Medicaties.Find(id);
            if (medicatie == null)
            {
                return HttpNotFound();
            }
            return View(medicatie);
        }

        // POST: Medicatie/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Medicatie_ID,Naam,Merk,Dosis,Patient_ID")] Medicatie medicatie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicatie).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicatie);
        }

        // GET: Medicatie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medicatie medicatie = db.Medicaties.Find(id);
            if (medicatie == null)
            {
                return HttpNotFound();
            }
            return View(medicatie);
        }

        // POST: Medicatie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medicatie medicatie = db.Medicaties.Find(id);
            db.Medicaties.Remove(medicatie);
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
