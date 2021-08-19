using NUnit.Framework;
using Payslip.Data;
using Payslip.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payslip.Test
{
    public class ProviderTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void StaticDataProvider_Test()
        {
            List<TaxBracket> brackets = StaticDataProvider.GetStaticTaxBrackets();

            Assert.IsNotNull(brackets); // List is initialised
            Assert.IsTrue(brackets.Count > 0); // There is something in the list

            foreach (var b in brackets)
            {
                Assert.IsTrue(b.UpperBracket > 0); // The brackets in the list have relevant data
            }
        }
    }
}
