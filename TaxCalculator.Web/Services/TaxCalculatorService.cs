using System.Net.Http.Json;
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

        public async Task<IEnumerable<TaxCalculatorLogDto>> GetLogItems()
        {
            try
            {
                var response = await this._httpClient.GetAsync("api/TaxCalculatorLog");

                if (response.IsSuccessStatusCode)
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
                    {
                        return Enumerable.Empty<TaxCalculatorLogDto>();
                    }

                    return await response.Content.ReadFromJsonAsync<IEnumerable<TaxCalculatorLogDto>>();
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
