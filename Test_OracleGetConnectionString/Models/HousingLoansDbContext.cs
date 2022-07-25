using Loans.Models.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_OracleGetConnectionString.Models
{
    public class HousingLoansDbContext: DbContext
    {
        public HousingLoansDbContext(DbContextOptions options)
            :base(options)
        { 
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Housingloansdata>()
                .HasKey(o => new  { o.customerId, o.loansId });

            //base.OnModelCreating(modelBuilder);
        }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<Customerdetail> Customerdetails { get; set; }
        public DbSet<Housingloansdata> Housingloansdatas { get; set; }
    }
}
