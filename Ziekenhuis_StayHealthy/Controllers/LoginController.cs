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

        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(User user)
        {
            int Patient_ID;
            int Kamer_ID;
            var patienten = db.Patient.ToList();
            for(int i = 0; i <patienten.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(patienten[i].Voornaam);
                if (patienten[i].Voornaam == user.name)
                {
                    Patient_ID = patienten[i].Kamer_ID.Value;
                    System.Diagnostics.Debug.WriteLine(patienten[i].Voornaam);
                    if (patienten[i].Kamer_ID != null)
                    {
                        Kamer_ID = patienten[i].Kamer_ID.Value;
                        
                    }
                }
            }
            

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
    }
}