using TaxCalculator.Api.Entities;
using TaxCalculator.Models.Dtos;

namespace TaxCalculator.Api.Repositories.Contracts
{
    public interface ITaxCalculatorLogRepository
    {
        Task<IEnumerable<TaxCalculatorLog>> GetLogAsync();
        Task<TaxCalculatorLog> AddLogItem(TaxCalculatorLogDto taxCalculatorLogDto);
    }
}
