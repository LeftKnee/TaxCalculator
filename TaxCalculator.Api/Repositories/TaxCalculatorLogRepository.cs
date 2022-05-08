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

        public async Task<TaxCalculatorLog> AddLogItem(TaxCalculatorLogUpdateDto taxCalculatorLogDto)
        {
            TaxFactory factory = null;
            var annualIncome = taxCalculatorLogDto.AnnualIncome;

            // Comment: This could have been done better in real life.
            //          Ideally - the tax class itself should be aware of the postal codes and hand that back here
            //          for a decision to be made on which factory to be used.
            switch (taxCalculatorLogDto.PostalCode)
            {
                case "7441":
                case "1000":
                    factory = new ProgressiveTaxFactory(annualIncome);
                    break;

                case "A100":
                    factory = new FlatValueTaxFactory(annualIncome);
                    break;

                case "7000":
                    factory = new FlatRateTaxFactory(annualIncome);
                    break;

                default:
                    break;
            }

            // Comment: Messy - but for this it works. If no factory is found, it could indicate a data error, or something else went wrong
            //          So we should perhaps be logging it or giving some other sort of feedback. For now - just return an empty object
            //          to at least prevent a complete unhandled exception.
            if (factory == null)
                return new TaxCalculatorLog();

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
