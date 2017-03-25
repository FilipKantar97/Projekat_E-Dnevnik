using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekat_Dnevnik.Controllers
{
    public class AdminLoginController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        // GET: AdminLogin
        public ActionResult Login(string name, string password)
        {
            if ("admin".Equals(name) && "admin".Equals(password))
            {
                return RedirectToAction("AdminIndex", "Home");
            }
            else 
            {
                 RedirectToAction("Login","AdminLogin");
            }
            return View();
        }
    }
}