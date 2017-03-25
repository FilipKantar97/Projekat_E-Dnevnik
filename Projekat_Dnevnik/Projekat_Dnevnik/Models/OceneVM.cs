using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Projekat_Dnevnik.Models
{
    public class OceneVM
    {
        public int IDOsoba { get; set; }
        public string Srpski { get; set; }
        public string Matematika { get; set; }
        public string Istorija { get; set; }
        public string Geografija { get; set; }
        public string Informatika { get; set; }
        public string Fizicko { get; set; }
        public string Vladanje { get; set; }
    }
}