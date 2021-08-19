using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payslip.Model
{
    public class EmployeePayslip : Payslip
    {
        public decimal GrossMonthlyIncome { get { return Salary / 12; } }
        public decimal MonthlyIncomeTax { get; set; }
        public decimal NetMonthlyIncome { get { return GrossMonthlyIncome - MonthlyIncomeTax; } }

        public EmployeePayslip(): this(string.Empty, 0) { }

        public EmployeePayslip(string eName, int sal)
        {
            this.EmployeeName = eName;
            this.Salary = sal;
        }

        public override string ToString()
        {
            return String.Format("Name: {0}, Salary: {1}, Monthly: {2}, MonthlyTax: {3}, NetIncome: {4}.", EmployeeName, Salary, GrossMonthlyIncome, MonthlyIncomeTax, NetMonthlyIncome);
        }

        public string PrintPayslip()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(String.Format("Monthly payslip for: {0}", EmployeeName));
            sb.AppendLine(String.Format("Gross Monthly Income: ${0}", Decimal.Round(GrossMonthlyIncome, 2)));
            sb.AppendLine(String.Format("Monthly Income Tax: ${0}", Decimal.Round(MonthlyIncomeTax), 2));
            sb.AppendLine(String.Format("Net Monthly Income: ${0}", Decimal.Round(NetMonthlyIncome), 2));
            return sb.ToString();
        }
    }
}
