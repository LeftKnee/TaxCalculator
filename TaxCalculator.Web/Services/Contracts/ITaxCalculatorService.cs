using TaxCalculator.Models.Dtos;

namespace TaxCalculator.Web.Services.Contracts
{
    public interface ITaxCalculatorService
    {
        Task<IEnumerable<TaxCalculatorLogDto>> GetLogItems();
    }
}
