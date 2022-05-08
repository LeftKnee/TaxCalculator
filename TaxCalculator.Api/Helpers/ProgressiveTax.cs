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
                GetTax();
            }
        }

        private void GetTax()
        {
            var taxToBePaid = 0m;

            // Comment - this works for the static example, but would likely be read in from sort of DB driven logic process.
            var taxRanges = new[]
                             {
                                new { Lower = 0m, Upper = 8350m, Rate = 0.1m },
                                new { Lower = 8351m, Upper = 33950m, Rate = 0.15m },
                                new { Lower = 33951m, Upper = 82250m, Rate = 0.25m },
                                new { Lower = 82251m, Upper = 171550m, Rate = 0.28m },
                                new { Lower = 171551m, Upper = 372950m, Rate = 0.33m },
                                new { Lower = 372951m, Upper = decimal.MaxValue, Rate = 0.35m }
                            };

            foreach (var range in taxRanges)
            {
                if ((int)_annualIncome > range.Lower)
                {
                    var taxableAtThisRate = Math.Min(range.Upper - range.Lower, (int)_annualIncome - range.Lower);
                    var taxThisBand = taxableAtThisRate * range.Rate;
                    taxToBePaid += taxThisBand;
                }
            }

            _totalTaxAmount = (double)taxToBePaid;
        }
    }
}
