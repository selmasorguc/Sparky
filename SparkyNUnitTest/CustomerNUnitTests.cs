using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparky
{
    [TestFixture]
    public class CustomerNUnitTests
    {
        private Customer customer;
        [SetUp]
        public void SetUp()
        {
            customer = new Customer();
        }


        [Test]
        public void CombineName_InputFirstLastName_ReturnFullName()
        {

            //Act
            customer.GreetAndCombineNames("Ben", "Spark");

            //Assert
            Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Ben Spark"));
            Assert.That(customer.GreetMessage, Does.Contain(","));
            Assert.That(customer.GreetMessage, Does.StartWith("Hello"));
            Assert.That(customer.GreetMessage, Does.EndWith("Spark"));
            Assert.That(customer.GreetMessage, Does.Contain("ben spark").IgnoreCase);
            Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));

        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            Assert.IsNull(customer.GreetMessage);
        }
    }
}
