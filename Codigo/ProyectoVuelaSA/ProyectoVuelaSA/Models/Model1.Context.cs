﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProyectoVuelaSA.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProyectoRequeEntities : DbContext
    {
        public ProyectoRequeEntities()
            : base("name=ProyectoRequeEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<aeropuerto> aeropuerto { get; set; }
        public virtual DbSet<equipajecheckin> equipajecheckin { get; set; }
        public virtual DbSet<reservacion> reservacion { get; set; }
        public virtual DbSet<usuario> usuario { get; set; }
        public virtual DbSet<vuelo> vuelo { get; set; }
        public virtual DbSet<asiento> asiento { get; set; }
    }
}
