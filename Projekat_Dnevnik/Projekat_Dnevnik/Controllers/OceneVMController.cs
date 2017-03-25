using Projekat_Dnevnik.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Projekat_Dnevnik.Controllers
{
    public class OceneVMController : Controller
    {
        // GET: OceneVM
        public ActionResult Index(int id)
        {
            DnevnikEntities de = new DnevnikEntities();
            Ocene o = de.Ocene.SingleOrDefault(x => x.IDOsoba == id);
            OceneVM ovm = new OceneVM();

            ovm.IDOsoba = o.IDOsoba;
            ovm.Srpski = o.Srpski;
            ovm.Matematika = o.Matematika;
            ovm.Istorija = o.Istorija;
            ovm.Geografija = o.Geografija;
            ovm.Informatika = o.Informatika;
            ovm.Fizicko = o.Fizicko;
            ovm.Vladanje = o.Vladanje;
            

            return View(ovm);
        }
    }
}