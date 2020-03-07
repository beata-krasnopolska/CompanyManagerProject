﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompanyManager.DAL.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace CompanyManager.DAL
{
    public class PersonContext : DbContext
    {
         public PersonContext() : base("name=CompanyManagerConnectionString")
         {
         }

         public DbSet<Person> Persons { get; set; }
         //public DbSet<Post> Posts { get; set; }

         //protected override void OnModelCreating(DbModelBuilder modelBuilder)
         //{
         //       modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
         //}
       
    }
}