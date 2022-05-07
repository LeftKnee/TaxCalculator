using Microsoft.EntityFrameworkCore;
using TaxCalculator.Api.Data;
using TaxCalculator.Api.Entities;
using TaxCalculator.Api.Repositories.Contracts;
using TaxCalculator.Models.Dtos;

namespace TaxCalculator.Api.Repositories
{
    public class TaxCalculatorLogRepository : ITaxCalculatorLogRepository
    {
        private readonly TaxCalculatorDbContext _taxCalculatorDbContext;
        public TaxCalculatorLogRepository(TaxCalculatorDbContext taxCalculatorDbContext )
        {
            this._taxCalculatorDbContext = taxCalculatorDbContext;
        }

        public async Task<TaxCalculatorLog> AddLogItem(TaxCalculatorLogDto taxCalculatorLogDto)
        {
            var result = await this._taxCalculatorDbContext.AddAsync(new TaxCalculatorLog
            {
                Id = taxCalculatorLogDto.Id,
                AnnualIncome = taxCalculatorLogDto.AnnualIncome,
                DateAdded = taxCalculatorLogDto.DateAdded,
                PostalCode = taxCalculatorLogDto.PostalCode,
                TaxedValue = taxCalculatorLogDto.TaxedValue
            });

            await this._taxCalculatorDbContext.SaveChangesAsync();
            
            return result.Entity;
        }

        public async Task<IEnumerable<TaxCalculatorLog>> GetLogAsync()
        {
            var logItems = await this._taxCalculatorDbContext.TaxCalculatorLogs.ToListAsync();

            return logItems;
        }
    }
}
