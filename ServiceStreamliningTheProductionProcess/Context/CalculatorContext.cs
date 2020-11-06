using ServiceStreamliningTheProductionProcess.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ServiceStreamliningTheProductionProcess.Context
{
    public class CalculatorContext : DbContext
    {
        //public CalculatorContext(DbContextOptions<CalculatorContext> options)
        //: base(options) { }
        public CalculatorContext()
            : base("name=DefaultConnection") { }
        public DbSet<City> City { get; set; }
        public DbSet<Module> Module { get; set; }
        public DbSet<SearchHistory> SearchHistory { get; set; }

        //At the begining I program it in EF6,then improve it to EF Core 
        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{

        //    modelBuilder.Entity<Student>()
        //            .Property(s => s.CreatedDate)
        //            .HasDefaultValueSql("GETDATE()");
        //}

    }
}