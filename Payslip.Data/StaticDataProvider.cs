using Payslip.Model;
using System.Collections.Generic;
using System.Linq;

namespace Payslip.Data
{
    public class StaticDataProvider
    {
        /// <summary>
        /// Simulates going to DB for static data.
        /// Allows any TaxBrackets to be defined.
        /// </summary>
        /// <returns>An Ordered List of TaxBrackets</returns>
        public static List<TaxBracket> GetStaticTaxBrackets()
        {
            List<TaxBracket> brackets = new List<TaxBracket>();

            brackets.Add(new TaxBracket(0.0M, 20000.0M, 0.0M));
            brackets.Add(new TaxBracket(20001.0M, 40000.0M, 0.1M));
            brackets.Add(new TaxBracket(40001.0M, 80000.0M, 0.2M));
            brackets.Add(new TaxBracket(80001.0M, 180000.0M, 0.3M));
            brackets.Add(new TaxBracket(180001.0M, decimal.MaxValue, 0.4M));
            brackets.OrderBy(x => x.TaxRate);
            return brackets;
        }
    }
}
