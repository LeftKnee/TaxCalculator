using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Text;
using TaxCalculator.Models.Dtos;
using TaxCalculator.Web.Services.Contracts;

namespace TaxCalculator.Web.Services
{
    public class TaxCalculatorService: ITaxCalculatorService
    {
        private readonly HttpClient _httpClient;
        public TaxCalculatorService(HttpClient httpClient)
        {
            this._httpClient = httpClient;
        }

        public async Task<TaxCalculatorLogUpdateDto> AddTaxLogItem(TaxCalculatorLogUpdateDto updaterDto)
        {
            try
            {
                var json = JsonConvert.SerializeObject(updaterDto);
                var data = new StringContent(json, Encoding.UTF8, "application/json");
                var response = await this._httpClient.PostAsync("api/TaxCalculatorLog", data);

                if (response.IsSuccessStatusCode)
                {
                    // Comment: Possible null checking here should have been done.
                    return await response.Content.ReadFromJsonAsync<TaxCalculatorLogUpdateDto>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }

            }
            catch (Exception)
            {
                //Comment: We may want to log this exception and in a real life scenarion something that would have been done.
                throw;
            }
        }

        public async Task<IEnumerable<TaxCalculatorLogDisplayDto>> GetLogItems()
        {
            try
            {
                var response = await this._httpClient.GetAsync("api/TaxCalculatorLog");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<TaxCalculatorLogDisplayDto>();
                    }

                    // Comment: There may be a null here and normally would have checked.
                    return await response.Content.ReadFromJsonAsync<IEnumerable<TaxCalculatorLogDisplayDto>>();
                }
                else
                {
                    var message = await response.Content.ReadAsStringAsync();
                    throw new Exception($"Http status code: {response.StatusCode} message: {message}");
                }

            }
            catch (Exception)
            {
                //We may want to log this exception
                throw;
            }
        }
    }
}
