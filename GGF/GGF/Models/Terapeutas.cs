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
    
    public partial class Terapeutas
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Terapeutas()
        {
            this.Pacientes = new HashSet<Pacientes>();
            this.Tokens = new HashSet<Tokens>();
        }
    
        public int Terapeuta_Id { get; set; }
        public int Usuario_Id { get; set; }
        public Nullable<bool> Activo { get; set; }
        public Nullable<System.DateTime> EdicionFecha { get; set; }
        public Nullable<int> EdicionUsuario { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pacientes> Pacientes { get; set; }
        public virtual Usuarios Usuarios { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tokens> Tokens { get; set; }
    }
}
