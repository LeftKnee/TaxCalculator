
namespace TaxCalculator.Models.Dtos
{
    public class TaxCalculatorLogDto
    {
        public DateTime DateAdded { get; set; }
        public string PostalCode { get; set; }
        public double AnnualIncome { get; set; }
        public double TaxedValue { get; set; }
    }
}
