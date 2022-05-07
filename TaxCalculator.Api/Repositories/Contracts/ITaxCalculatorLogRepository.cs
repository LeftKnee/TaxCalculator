using TaxCalculator.Api.Entities;

namespace TaxCalculator.Api.Repositories.Contracts
{
    public interface ITaxCalculatorLogRepository
    {
        Task<IEnumerable<TaxCalculatorLog>> GetLogAsync();
    }
}
