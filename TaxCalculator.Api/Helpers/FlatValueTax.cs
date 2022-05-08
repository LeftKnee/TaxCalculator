namespace TaxCalculator.Api.Helpers
{
    public class FlatValueTax : TaxCalculatorBase
    {
        private double _annualIncome;
        private double _totalTaxAmount;

        public FlatValueTax(double annualIncome)
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
            if (_annualIncome < 200000 )
            {
                _totalTaxAmount = _annualIncome * (0.05);
            }
            else
            {
                _totalTaxAmount = 10000;
            }
                

        }
    }
}
