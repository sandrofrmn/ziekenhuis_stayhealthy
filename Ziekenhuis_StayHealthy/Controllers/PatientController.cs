﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ziekenhuis_StayHealthy.Models;

namespace Ziekenhuis_StayHealthy.Controllers
{
    public class PatientController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Patient
        public ActionResult Index()
        {
            return View(db.Patients.ToList());
        }

        // GET: Patient/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                id = LoginController.Patient_ID;
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            }
            System.Diagnostics.Debug.WriteLine(id);
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patient/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Patient/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Patiënt_ID,Voornaam,Achternaam,Adres,Geboortedatum,Telefoonnummer,Afdeling_ID,Kamer_ID,Gearchiveerd")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(patient);
        }

        // GET: Patient/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patient/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Patiënt_ID,Voornaam,Achternaam,Adres,Geboortedatum,Telefoonnummer,Afdeling_ID,Kamer_ID,Gearchiveerd")] Patient patient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(patient);
        }

        // GET: Patient/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patient/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Interface()
        {
            return View();  
        }

        public ActionResult DashboardPatient()
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
        
        public ActionResult LampBedienen()
        {
            DomoticzAPI API = new DomoticzAPI();
            int device = API.GetRoomDevices(LoginController.Kamer_ID + 1, "lamp");
            API.ToggleSwitch(device);

            return RedirectToAction("DashboardPatient", "Patient");
        }

        public ActionResult MediaPlayerBedienen()
        {
            /*
            SqlConnection conn = new SqlConnection();
            SqlCommand cmd = new SqlCommand();
            */
            DomoticzAPI API = new DomoticzAPI();
            int device = API.GetRoomDevices(LoginController.Kamer_ID + 1, "media player");
            API.ToggleSwitch(device);

            return RedirectToAction("DashboardPatient", "Patient");
        }

        public ActionResult TemperatuurBedienen()
        {
            DomoticzAPI API = new DomoticzAPI();
            int device = API.GetRoomDevices(2, "temperatuur");
            API.KiesTemperatuur(device);


            return RedirectToAction("DashboardPatient", "Patient");
        }

        public ActionResult GordijnenBedienen()
        {
            DomoticzAPI API = new DomoticzAPI();
            int device = API.GetRoomDevices(LoginController.Kamer_ID + 1, "gordijn");
            API.ToggleSwitch(device);


            return RedirectToAction("DashboardPatient", "Patient");
        }
    }
}
