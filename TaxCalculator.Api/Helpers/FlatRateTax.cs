namespace TaxCalculator.Api.Helpers
{
    public class FlatRateTax : TaxCalculatorBase
    {
        private double _annualIncome;
        private double _totalTaxAmount;

        public FlatRateTax(double annualIncome)
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
                GetTax();
            }
        }

        private void GetTax()
        {

            _totalTaxAmount = _annualIncome * (17.5/100);

        }
    }
}
