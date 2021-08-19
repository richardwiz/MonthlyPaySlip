using Payslip.Data;
using Payslip.Model;
using System.Collections.Generic;

namespace Payslip.Controller
{
    public class PaySlipCalculator : ICalculator
    {
        private EmployeePayslip EPaySlip { get; set; }

        public PaySlipCalculator() :this(string.Empty, 0){ }
        public PaySlipCalculator(string employeeName, decimal salary)
        {
            EPaySlip = new EmployeePayslip
            {
                EmployeeName = employeeName,
                Salary = salary
             };
        }

        public void CalculateMonthlyIncomeTaxByBand()
        {
            decimal tax = 0.0M;
            decimal lastBracketsUpperBound = 0.0M;

            List<TaxBracket> currentTaxBrackets = StaticDataProvider.GetStaticTaxBrackets();

            foreach (var bracket in currentTaxBrackets)
            {
                if (EPaySlip.Salary > bracket.UpperBracket)
                {
                    // Calculate tax on the whole bracket
                    tax += (bracket.UpperBracket - lastBracketsUpperBound) * bracket.TaxRate;
                }
                else 
                {
                    // Calculate tax on the part of salary that is above the end of last bracket
                    tax += (EPaySlip.Salary - lastBracketsUpperBound) * bracket.TaxRate;
                    break;
                }
                lastBracketsUpperBound = bracket.UpperBracket;

            }

            EPaySlip.MonthlyIncomeTax = decimal.Round(tax / 12, 2); 
        }

        public string PrintPayslip()
        {
            return EPaySlip.PrintPayslip();
        }

        public EmployeePayslip GetCurrentPayslip()
        {
            return EPaySlip;
        }

    }
}
