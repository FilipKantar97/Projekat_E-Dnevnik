
using Projekat_Dnevnik.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekat_Dnevnik.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
          return RedirectToAction("Login", "Login");  
        }
        
        public ActionResult AdminIndex()
        {
            return View();
        }
    }
}