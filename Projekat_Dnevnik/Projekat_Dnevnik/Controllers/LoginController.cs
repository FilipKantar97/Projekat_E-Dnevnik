using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Projekat_Dnevnik.Models;
using System.Configuration;
using System.Data.SqlClient;

namespace Projekat_Dnevnik.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(string name, string password)
        {
           
            int id = 0;
          
                using (SqlConnection con = new SqlConnection(Konekcija.kon))
                {
                    SqlCommand komanda = new SqlCommand("select IDOsobe from Ucenik where JMBG=@jmbg and Pin=@pin", con);
                    komanda.Parameters.AddWithValue("jmbg", name);
                    komanda.Parameters.AddWithValue("pin", Convert.ToInt32(password));

                    try
                    {
                        con.Open();
                        SqlDataReader read = komanda.ExecuteReader();
                        if (read.Read())
                        {
                            id = Convert.ToInt32(read[0]);
                        }
                        con.Close();
                        if (id > 0)
                        {
                            return RedirectToAction("Index", "OceneVM", new { @id = id });
                        }
                        else
                        {
                            return RedirectToAction("Login", "Login");
                        }
                    }
                    catch (Exception)
                    {

                        throw;
                    }                
            }
            return View();
        }
    }
}