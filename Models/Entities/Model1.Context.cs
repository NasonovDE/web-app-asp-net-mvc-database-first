﻿//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace web_app_asp_net_mvc_database_first.Models.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class KinoAfishaDFEntities : DbContext
    {
        public KinoAfishaDFEntities()
            : base("name=KinoAfishaDFEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Cinemas> Cinemas { get; set; }
        public virtual DbSet<FilmImages> FilmImages { get; set; }
        public virtual DbSet<Films> Films { get; set; }
        public virtual DbSet<Kinos> Kinos { get; set; }
    }
}
