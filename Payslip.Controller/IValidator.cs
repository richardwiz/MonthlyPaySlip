using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payslip.Controller
{
    public interface IValidator
    {
        abstract bool ValidateDetails(string[] args);
    }
}
