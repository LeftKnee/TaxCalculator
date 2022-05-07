namespace TaxCalculator.Api.Helpers
{
    public abstract class TaxCalculatorBase
    {
        public abstract double TotalTaxAmount { get; }
        public abstract double AnnualIncome { set; }
        public abstract void CalculateTax();
    }
}
