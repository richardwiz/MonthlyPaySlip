using NUnit.Framework;
using Payslip.Controller;

namespace Payslip.Test
{
    public class CalculatorTests
    {
        public ICalculator Calc { get; set; }

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CalcMonthlyIncomeTax_Example_Test()
        {
            Calc = new PaySlipCalculator("Mary Song", 60000.00M);
            Calc.CalculateMonthlyIncomeTaxByBand();

            Assert.IsTrue(Calc.GetCurrentPayslip().MonthlyIncomeTax == 500.00M);
        }    

        [Test]
        public void CalcMonthlyIncomeTax_BottomBracket_Test()
        {
            Calc = new PaySlipCalculator("Ozymandius", 10000.00M);
            Calc.CalculateMonthlyIncomeTaxByBand();

            Assert.IsTrue(Calc.GetCurrentPayslip().MonthlyIncomeTax == 0.00M);
        }

        [Test]
        public void CalcMonthlyIncomeTax_TopBracket_Test()
        {
            Calc = new PaySlipCalculator("Jean Luc Picard", 200000.00M);
            Calc.CalculateMonthlyIncomeTaxByBand();

            Assert.IsTrue(Calc.GetCurrentPayslip().MonthlyIncomeTax == 4000.00M);
        }
    }
}
