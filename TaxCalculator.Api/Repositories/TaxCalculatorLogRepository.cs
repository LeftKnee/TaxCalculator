using Microsoft.EntityFrameworkCore;
using TaxCalculator.Api.Data;
using TaxCalculator.Api.Entities;
using TaxCalculator.Api.Helpers;
using TaxCalculator.Api.Repositories.Contracts;
using TaxCalculator.Models.Dtos;

namespace TaxCalculator.Api.Repositories
{
    public class TaxCalculatorLogRepository : ITaxCalculatorLogRepository
    {
        private readonly TaxCalculatorDbContext _taxCalculatorDbContext;
        public TaxCalculatorLogRepository(TaxCalculatorDbContext taxCalculatorDbContext)
        {
            this._taxCalculatorDbContext = taxCalculatorDbContext;
        }

        public async Task<TaxCalculatorLog> AddLogItem(TaxCalculatorLogDto taxCalculatorLogDto)
        {
            TaxFactory factory = null;
            var annualIncome = taxCalculatorLogDto.AnnualIncome;

            switch (taxCalculatorLogDto.PostalCode)
            {
                case "7441":
                    factory = new ProgressiveTaxFactory(annualIncome);
                    break;

                default:
                    break;
            }

            TaxCalculatorBase tax = factory.CalculateTax();

            var result = await this._taxCalculatorDbContext.AddAsync(new TaxCalculatorLog
            {
                AnnualIncome = taxCalculatorLogDto.AnnualIncome,
                DateAdded = DateTime.Now,
                PostalCode = taxCalculatorLogDto.PostalCode,
                TaxedValue = tax.TotalTaxAmount
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
