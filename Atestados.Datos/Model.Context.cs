﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Atestados.Datos
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class BDAtestadosMVC_ServiciosEntities : DbContext
    {
        public BDAtestadosMVC_ServiciosEntities()
            : base("name=BDAtestadosMVC_ServiciosEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Configuracion> Configuracion { get; set; }
        public virtual DbSet<TipoConfiguracion> TipoConfiguracion { get; set; }
    
        public virtual ObjectResult<pr_ObtieneConfiguracion_Result> pr_ObtieneConfiguracion(Nullable<int> idConfiguracion, ObjectParameter codigo, ObjectParameter mensaje)
        {
            var idConfiguracionParameter = idConfiguracion.HasValue ?
                new ObjectParameter("IdConfiguracion", idConfiguracion) :
                new ObjectParameter("IdConfiguracion", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<pr_ObtieneConfiguracion_Result>("pr_ObtieneConfiguracion", idConfiguracionParameter, codigo, mensaje);
        }
    }
}
