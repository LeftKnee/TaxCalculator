using Microsoft.EntityFrameworkCore;
using TaxCalculator.Api.Data;
using TaxCalculator.Api.Entities;
using TaxCalculator.Api.Repositories.Contracts;

namespace TaxCalculator.Api.Repositories
{
    public class TaxCalculatorLogRepository : ITaxCalculatorLogRepository
    {
        private readonly TaxCalculatorDbContext _taxCalculatorDbContext;
        public TaxCalculatorLogRepository(TaxCalculatorDbContext taxCalculatorDbContext )
        {
            this._taxCalculatorDbContext = taxCalculatorDbContext;
        }

        public async Task<IEnumerable<TaxCalculatorLog>> GetLogAsync()
        {
            var logItems = await this._taxCalculatorDbContext.TaxCalculatorLogs.ToListAsync();

            return logItems;
        }
    }
}
