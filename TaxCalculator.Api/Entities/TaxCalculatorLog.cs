namespace TaxCalculator.Api.Entities
{
    public class TaxCalculatorLog
    {
        public int Id { get; set; }
        public DateTime DateAdded { get; set; }
        public string PostalCode { get; set; }
        public Double AnnualIncome { get; set; }
        public Double TaxedValue { get; set; }
    }
}
