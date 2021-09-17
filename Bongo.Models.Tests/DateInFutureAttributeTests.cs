using Bongo.Models.ModelValidations;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bongo.Models
{
    [TestFixture]
    public class DateInFutureAttributeTests
    {
        [Test]
        [TestCase(100, ExpectedResult = true)]

        [TestCase(-100, ExpectedResult = false)]
        public bool DateValidator_InputExpectedDataRange_DateValidity(int addTime)
        {
            DateInFutureAttribute date = new(() => DateTime.Now);

            return date.IsValid(DateTime.Now.AddSeconds(addTime));   
        }

        [Test]
        public void DateValidator_NotValidDate_ReturnErrorMessage()
        {
            var result = new DateInFutureAttribute();

            Assert.AreEqual("Date must be in the future", result.ErrorMessage);
        }
    }
}
