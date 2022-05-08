namespace TaxCalculator.Api.Helpers
{
    class FlatRateTaxFactory : TaxFactory
    {
        private readonly double _annualIncome;

        public FlatRateTaxFactory(double annualIncome)
        {
            _annualIncome = annualIncome;
        }

        public override TaxCalculatorBase CalculateTax()
        {

            return new FlatRateTax(_annualIncome);
        }
    }
}
