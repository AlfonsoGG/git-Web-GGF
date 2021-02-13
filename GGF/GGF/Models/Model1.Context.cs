﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class GiveGoodFaceEntities : DbContext
    {
        public GiveGoodFaceEntities()
            : base("name=GiveGoodFaceEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<CT_Eventos> CT_Eventos { get; set; }
        public virtual DbSet<Modulos> Modulos { get; set; }
        public virtual DbSet<Pacientes> Pacientes { get; set; }
        public virtual DbSet<RegistrosEvento> RegistrosEvento { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Roles_Modulos> Roles_Modulos { get; set; }
        public virtual DbSet<Sy_Configuraciones> Sy_Configuraciones { get; set; }
        public virtual DbSet<Terapeutas> Terapeutas { get; set; }
        public virtual DbSet<Tokens> Tokens { get; set; }
        public virtual DbSet<Usuarios> Usuarios { get; set; }
    
        public virtual ObjectResult<GetPatientsByTherapist_Result> GetPatientsByTherapist(Nullable<int> p_TerapeutaId)
        {
            var p_TerapeutaIdParameter = p_TerapeutaId.HasValue ?
                new ObjectParameter("p_TerapeutaId", p_TerapeutaId) :
                new ObjectParameter("p_TerapeutaId", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<GetPatientsByTherapist_Result>("GetPatientsByTherapist", p_TerapeutaIdParameter);
        }
    }
}
