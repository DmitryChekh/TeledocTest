using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teledoc_test.Models.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }



        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<FounderModel> Founders { get; set; }
        public DbSet<CustomerTypeModel> CustomerTypes { get; set; }
        public DbSet<CustomerFounderModel> CustomerFounder { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {



            modelBuilder.Entity<CustomerFounderModel>()
                .HasKey(t => new { t.CustomerId, t.FounderId });

            modelBuilder.Entity<CustomerFounderModel>()
                .HasOne(cf => cf.Customer)
                .WithMany(c => c.CustomerFounder)
                .HasForeignKey(cf => cf.CustomerId);



            modelBuilder.Entity<CustomerFounderModel>()
                .HasOne(cf => cf.Founder)
                .WithMany(f => f.CustomerFounder)
                .HasForeignKey(cf => cf.FounderId)
                .IsRequired().OnDelete(DeleteBehavior.Cascade);




            modelBuilder.Entity<CustomerTypeModel>()
                               .HasData(
                new CustomerTypeModel { TypeId = 1, Name = "Индивидуальный предприниматель" },
                new CustomerTypeModel { TypeId = 2, Name = "Юридическое лицо" }
                );

        }
    }


}
