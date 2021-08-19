using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payslip.Model
{
    public abstract class Payslip
    {
        public string EmployeeName { get; set; }
        public decimal Salary { get; set; }

        public Payslip()
        {

        }
    }
}
