//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Projekat_Dnevnik.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Kontakt
    {
        public string Broj_Telefona { get; set; }
        public string Lokal { get; set; }
        [Key, ForeignKey("IDOznake")]
        public int IDOsobe { get; set; }
        public int IDOznake { get; set; }
    
        public virtual Ucenik Ucenik { get; set; }
        public virtual Vrsta_Kontakta Vrsta_Kontakta { get; set; }
    }
}
