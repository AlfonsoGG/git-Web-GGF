//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GGF.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Tokens
    {
        public int Token_Id { get; set; }
        public int Terapeuta_Id { get; set; }
        public string Token { get; set; }
        public System.DateTime ExpiracionFecha { get; set; }
        public Nullable<System.DateTime> RelacionFecha { get; set; }
        public Nullable<int> Paciente_Id { get; set; }
    
        public virtual Terapeutas Terapeutas { get; set; }
        public virtual Pacientes Pacientes { get; set; }
    }
}