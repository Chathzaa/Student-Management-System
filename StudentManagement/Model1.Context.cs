﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace StudentManagement
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class registerdbEntities : DbContext
    {
        public registerdbEntities()
            : base("name=registerdbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TBL_USERS> TBL_USERS { get; set; }
        public virtual DbSet<course_tab> course_tab { get; set; }
        public virtual DbSet<Fee_tab> Fee_tab { get; set; }
        public virtual DbSet<info_tab> info_tab { get; set; }
        public virtual DbSet<student_tab> student_tab { get; set; }
        public virtual DbSet<teacher_tab> teacher_tab { get; set; }
        public virtual DbSet<regis_tab> regis_tab { get; set; }
    }
}