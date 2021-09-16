using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sparky;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SparkyMSTest
{
    [TestClass]
    public class CalculatorMSTests
    {
        [TestMethod]
        public void AddNumbers_InputTwoInt_GetCorrectAddition()
        {
            //ARRANGE
            Calculator calc = new();

            //ACT
            int result = calc.AddNumbers(10, 20);

            //ASSERT
            Assert.AreEqual(30, result);
        }
    }
}
