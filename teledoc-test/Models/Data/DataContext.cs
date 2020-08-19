using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace teledoc_test.Models.Data
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<CustomerModel> Customers { get; set; }
        public DbSet<FounderModel> Founders { get; set; }
        public DbSet<CustomerTypeModel> CustomerTypes { get; set; }
        public DbSet<CustomerFounderModel> CustomerFounder { get; set; }

    }


}
