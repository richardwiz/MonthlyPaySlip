using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payslip.Model
{
    public class TaxBracket
    {
        public decimal LowerBracket { get; set; }
        public decimal UpperBracket { get; set; }
        public decimal TaxRate { get; set; }

        public TaxBracket():this(0,0,0) { }

        public TaxBracket(decimal lowerBracket, decimal upperBracket, decimal rate)
        {
            LowerBracket = lowerBracket;
            UpperBracket = upperBracket;
            TaxRate = rate;
        }
    }
}
