using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payslip.Controller
{
    public class PayslipValidator : IValidator
    {
        public bool ValidateDetails(string[] args)
        {
            // arg 1 = string
            if (String.IsNullOrEmpty(args[0]))
            {
                return false;
            }
            // arg 2 decimal
            decimal test;
            NumberStyles style = NumberStyles.Integer | NumberStyles.AllowDecimalPoint | NumberStyles.Integer;
             CultureInfo culture = CultureInfo.CreateSpecificCulture("en-GB");
            if (!Decimal.TryParse(args[1], style, culture, out test))
            {
                return false;
            }
            // arg 2 0?
            if (test <= 0.0M)
            {
                return false;
            }
            return true;
        }

    }
}
