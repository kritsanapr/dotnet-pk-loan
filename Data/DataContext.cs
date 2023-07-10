using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace pk_loan_crud.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options): base(options) {}
        public DbSet<PKLoan> PKLoans{ get; set; }

        protected override void OnModelCreating(ModelBuilder builder) {

            new DbInitializer(builder).Seed();
        }

    }
}