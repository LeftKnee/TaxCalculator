namespace TaxCalculator.Api.Helpers
{
    public class ProgressiveTax : TaxCalculatorBase
    {
        private double _annualIncome;
        private double _totalTaxAmount;

        public ProgressiveTax(double annualIncome)
        {
            AnnualIncome = annualIncome;
        }

        public override double TotalTaxAmount 
        { 
            get { return _totalTaxAmount; } 
        }
        public override double AnnualIncome 
        { 
            set 
            { 
                _annualIncome = value;
                CalculateTax();
            }
        }

        public override void CalculateTax()
        {

            _totalTaxAmount = _annualIncome - 10;

        }
    }
}
