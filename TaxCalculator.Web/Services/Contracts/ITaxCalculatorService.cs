using TaxCalculator.Models.Dtos;

namespace TaxCalculator.Web.Services.Contracts
{
    public interface ITaxCalculatorService
    {
        Task<IEnumerable<TaxCalculatorLogDisplayDto>> GetLogItems();
        Task<TaxCalculatorLogUpdateDto> AddTaxLogItem(TaxCalculatorLogUpdateDto updaterDto);
    }
}
