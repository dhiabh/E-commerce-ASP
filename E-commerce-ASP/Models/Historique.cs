//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace E_commerce_ASP.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Historique
    {
        public int Id { get; set; }
        public string Transaction { get; set; }
        public string idUser { get; set; }
        public string IdProduct { get; set; }
        public string NameProduct { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
    }
}