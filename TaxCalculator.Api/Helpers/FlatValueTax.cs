﻿namespace TaxCalculator.Api.Helpers
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
                CalculateTax();
            }
        }

        public override void CalculateTax()
        {

            _totalTaxAmount = 1;

        }
    }
}