﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SRSWebApplication.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SRSDBEntities : DbContext
    {
        public SRSDBEntities()
            : base("name=SRSDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Courses> Courses { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<Instructors> Instructors { get; set; }
        public virtual DbSet<Registrations> Registrations { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<StudyTerms> StudyTerms { get; set; }
        public virtual DbSet<TAAssignments> TAAssignments { get; set; }
        public virtual DbSet<TAGraders> TAGraders { get; set; }
        public virtual DbSet<TeachingAssignments> TeachingAssignments { get; set; }
    }
}
