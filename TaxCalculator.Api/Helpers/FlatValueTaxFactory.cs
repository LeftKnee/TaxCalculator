namespace TaxCalculator.Api.Helpers
{
    class FlatValueTaxFactory : TaxFactory
    {
        private readonly double _annualIncome;

        public FlatValueTaxFactory(double annualIncome)
        { 
            _annualIncome = annualIncome;
        }

        public override TaxCalculatorBase CalculateTax()
        {
            
            return new FlatValueTax(_annualIncome);
        }
    }
}
