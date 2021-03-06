﻿using CompanyManager.DAL.Entities;
using System.Data.Entity;

namespace CompanyManager.DAL
{
    public class PersonContext : DbContext
    {
        public PersonContext() : base("name=CompanyManagerDBConnectionString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PersonContext, Migrations.Configuration>());            
        }

        static PersonContext()
        {
            var ensureDLLIsCopied = System.Data.Entity.SqlServer.SqlProviderServices.Instance;
        }

         public DbSet<Person> Persons { get; set; }

         public DbSet<Post> Posts { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }    
    }
}
