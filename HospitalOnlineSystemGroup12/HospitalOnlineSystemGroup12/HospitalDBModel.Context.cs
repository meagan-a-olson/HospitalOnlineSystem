﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HospitalOnlineSystemGroup12
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class HospitalDBEntities : DbContext
    {
        public HospitalDBEntities()
            : base("name=HospitalDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<AppointmentsTable> AppointmentsTables { get; set; }
        public virtual DbSet<DoctorsTable> DoctorsTables { get; set; }
        public virtual DbSet<MedicationListTable> MedicationListTables { get; set; }
        public virtual DbSet<MessagesTable> MessagesTables { get; set; }
        public virtual DbSet<PatientsTable> PatientsTables { get; set; }
        public virtual DbSet<TestsTable> TestsTables { get; set; }
        public virtual DbSet<UsersTable> UsersTables { get; set; }
    }
}
