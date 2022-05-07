using Microsoft.EntityFrameworkCore;
using TaxCalculator.Api.Entities;

namespace TaxCalculator.Api.Data
{
    public class TaxCalculatorDbContext: DbContext
    {
        public TaxCalculatorDbContext(DbContextOptions<TaxCalculatorDbContext> options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<TaxCalculatorLog> TaxCalculatorLogs { get; set; }
    }
}
