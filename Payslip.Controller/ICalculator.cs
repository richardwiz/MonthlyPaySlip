using Payslip.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payslip.Controller
{
    public interface ICalculator
    {
        abstract void CalculateMonthlyIncomeTaxByBand();
        abstract string PrintPayslip();
        abstract EmployeePayslip GetCurrentPayslip();
    }
}
