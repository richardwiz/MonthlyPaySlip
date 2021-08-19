using Payslip.Controller;
using System;

namespace Payslip.console
{
    class Program
    {
        static void Main(string[] args)
        {
            IValidator validator = new PayslipValidator();
            if (validator.ValidateDetails(args))
            {
                ICalculator calc = new PaySlipCalculator(args[0], Decimal.Parse(args[1]));

                calc.CalculateMonthlyIncomeTaxByBand();
                Console.WriteLine(calc.PrintPayslip());
                Console.WriteLine("Please press any key to exit, Thank You");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Please enter the Employee name and Salary correctly.");
            }
        }
        
    }
}
