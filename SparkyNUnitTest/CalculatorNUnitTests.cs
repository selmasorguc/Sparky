using NUnit.Framework;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SparkyNUnitTest
{
    [TestFixture]
    class CalculatorNUnitTests
    {
        [Test]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //ARRANGE
            Calculator calc = new();

            //ACT
            int result = calc.AddNumbers(10, 20);

            //ASSERT
            Assert.AreEqual(30, result);
        }

        [Test]
        [TestCase(10)]
        [TestCase(234)]
        public void IsOddNumber_InputEvenInt_ReturnFalse(int a)
        {
            //ARRANGE
            Calculator calc = new();

            //ACT
            bool result = calc.IsOddNumber(a);

            //ASSERT
            //Assert.AreEqual(false, result);
            //Assert.IsFalse(result);
            Assert.That(result, Is.EqualTo(false));
        }

        [Test]
        [TestCase(10, ExpectedResult = false)]
        [TestCase(11, ExpectedResult = true)]
        [TestCase(1221, ExpectedResult = true)]
        public bool IsOddChecker_InputNumber_ReturnTrueOrFalse(int a)
        {
            Calculator calc = new();

            return calc.IsOddNumber(a);
        }


        [Test]
        [TestCase(5.4, 10.5)] //15.9
        [TestCase(5.43, 10.53)] //15.93
        [TestCase(5.49, 10.59)] //16.08
        public void AddNumbersDouble_InputTwoDouble_GetCorrectAddition(double a, double b)
        {
            //ARRANGE
            Calculator calc = new();

            //ACT
            double result = calc.AddNumbersDouble(a,b);

            //ASSERT
            Assert.AreEqual(15.9, result, .2); //15.7 - 16.1
        }

        [Test]
        public void OddRanger_InputMinAndMaxRange_ReturnsValidOddNumberRange()
        {
            Calculator calc = new();
            List<int> expectedOddRange = new() { 5, 7, 9 };//5-10

            List<int> result = calc.GetOddRange(5, 10);

            Assert.That(result, Is.EquivalentTo(expectedOddRange));
            Assert.AreEqual( expectedOddRange, result);
            Assert.Contains(7, result);
            Assert.That(result, Does.Contain(7));
            Assert.That(result, Is.Not.Empty);
            Assert.That(result.Count, Is.EqualTo(3));
        }
    }
}
