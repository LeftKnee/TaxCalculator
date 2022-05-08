using Microsoft.AspNetCore.Components;
using TaxCalculator.Models.Dtos;
using TaxCalculator.Web.Services.Contracts;

namespace TaxCalculator.Web.Pages
{
    public class TaxLogsBase : ComponentBase
    {
        [Inject]
        public ITaxCalculatorService TaxCalculatorLogService { get; set; }
        public string ErrorMessage { get; set; }

        public IEnumerable<TaxCalculatorLogDisplayDto> TaxCalculatorLogs { get; set; }
        public TaxCalculatorLogUpdateDto TaxCalculatorUpdater { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                TaxCalculatorLogs = await TaxCalculatorLogService.GetLogItems();

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;

            }

        }

        protected async Task AddLogItem_Click(TaxCalculatorLogUpdateDto TaxCalculatorUpdater)
        {
            
            var updatedDto = await TaxCalculatorLogService.AddTaxLogItem(TaxCalculatorUpdater);

        }
    }
}
