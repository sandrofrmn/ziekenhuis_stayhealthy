using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ziekenhuis_StayHealthy.Models;

namespace Ziekenhuis_StayHealthy.Controllers
{
    public class LoginController : Controller
    {
        Patientnaam db = new Patientnaam();
        public static int Patient_ID;
        public static int Kamer_ID;

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(User user)
        {
            (Patient_ID, Kamer_ID) = Logincheck(user);
            //System.Diagnostics.Debug.WriteLine(Patient_ID);

            if (user.name == "admin" || user.name == "zorgverlener")
            {
                Session["function"] = user.name;
            }
            else
            {
                Session["user"] = user.name;
                Session["function"] = "patient";
            }
            return RedirectToAction("Index", "home");
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "home");
        }
        
        public (int, int) Logincheck(User user)
        {
            var patienten = db.Patient.ToList();
            for (int i = 0; i < patienten.Count; i++)
            {
                if (patienten[i].Voornaam == user.name)
                {
                    Patient_ID = patienten[i].Patiënt_ID;
                    if (patienten[i].Kamer_ID != null)
                    {
                        Kamer_ID = patienten[i].Kamer_ID.Value;                      
                    }
                }
            }
            return (Patient_ID, Kamer_ID);
        }
    }
}