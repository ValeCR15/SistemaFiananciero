//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SistemaFinanciero.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Persona
    {
        public int idCedula { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public Nullable<System.DateTime> fechadenacimiento { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}
