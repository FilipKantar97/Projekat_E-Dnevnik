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

    public partial class Adresa
    {
        public string Adresa1 { get; set; }
        public string Postanski_Broj { get; set; }
        public string Grad { get; set; }
        [Key, ForeignKey("IDOznakeAdresa")]
        public int IDOsobe { get; set; }
        public int IDOznakeAdresa { get; set; }
    
        public virtual Ucenik Ucenik { get; set; }
        public virtual Vrsta_Adresa Vrsta_Adresa { get; set; }
    }
}