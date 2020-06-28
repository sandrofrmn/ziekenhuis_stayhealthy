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
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(User user)
        {

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