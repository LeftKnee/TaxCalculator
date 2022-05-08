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

        public IList<TaxCalculatorLogDisplayDto> TaxCalculatorLogs { get; set; }
        public TaxCalculatorLogUpdateDto TaxCalculatorUpdater { get; set; }

        protected override async Task OnInitializedAsync()
        {
            try
            {
                TaxCalculatorLogs = (await TaxCalculatorLogService.GetLogItems()).ToList();

            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;

            }

        }

        protected async Task AddLogItem_Click(TaxCalculatorLogUpdateDto TaxCalculatorUpdater)
        {

            var updatedDto = await TaxCalculatorLogService.AddTaxLogItem(TaxCalculatorUpdater);
            
            // Comment: This is not ideal and could have been avoided if the bindings were
            //          created properly from the beginning.
            TaxCalculatorLogs = (await TaxCalculatorLogService.GetLogItems()).ToList();
            StateHasChanged();
        }
    }
}

