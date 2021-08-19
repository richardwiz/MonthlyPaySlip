using NUnit.Framework;
using Payslip.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Payslip.Test
{
    class ValidationTests
    {
        public IValidator Validator { get; set; }

        [SetUp]
        public void Setup()
        {
            Validator = new PayslipValidator();
        }

        [Test]
        public void ConsoleDataValidation_Test_Positive()
        {
            string[] args = { "Mary Song", "45000" };
            bool valid = Validator.ValidateDetails(args);
            Assert.IsTrue(valid);
        }

        [Test]
        public void ConsoleDataValidation_Test_DecimalPoint()
        {
            string[] args = { "Mary Song", "45000.00" };
            bool valid = Validator.ValidateDetails(args);
            Assert.IsTrue(valid);
        }

        [Test]
        public void ConsoleDataValidation_Test_DollarSign()
        {
            string[] args = { "Mary Song", "$45000.00" };
            bool valid = Validator.ValidateDetails(args);
            Assert.IsFalse(valid);
        }

        [Test]
        public void ConsoleDataValidation_Test_Negative()
        {
            string[] args = { "", "" };
            bool valid = Validator.ValidateDetails(args);
            Assert.IsFalse(valid);
        }

        [Test]
        public void ConsoleDataValidation_Test_BadDecimal()
        {
            string[] args = { "Mary Song", "bad decimal" };
            bool valid = Validator.ValidateDetails(args);
            Assert.IsFalse(valid);
        }


    }
}
