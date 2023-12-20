using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Course9
{
    public class ETicaretContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=DEIMOS-CM\\SQLEXPRESS;Database=EFCoreGencay;Trusted_Connection=True;Trust Server Certificate=True;");
        }

        public ETicaretContext()
        {
            DataSeeder.SeedData(this);
        }
    }
}
