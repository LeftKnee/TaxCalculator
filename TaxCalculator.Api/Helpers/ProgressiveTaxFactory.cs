namespace TaxCalculator.Api.Helpers
{
    class ProgressiveTaxFactory : TaxFactory
    {
        private readonly double _annualIncome;

        public ProgressiveTaxFactory(double annualIncome)
        { 
            _annualIncome = annualIncome;
        }

        public override TaxCalculatorBase CalculateTax()
        {
            
            return new ProgressiveTax(_annualIncome);
        }
    }
}
