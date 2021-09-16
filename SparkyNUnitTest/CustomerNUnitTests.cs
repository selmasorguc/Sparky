namespace Sparky
{
    using NUnit.Framework;
    using System;

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
            Assert.Multiple(() =>
            {
                Assert.That(customer.GreetMessage, Is.EqualTo("Hello, Ben Spark"));
                Assert.That(customer.GreetMessage, Does.Contain(","));
                Assert.That(customer.GreetMessage, Does.StartWith("Hello"));
                Assert.That(customer.GreetMessage, Does.EndWith("Spark"));
                Assert.That(customer.GreetMessage, Does.Contain("ben spark").IgnoreCase);
                Assert.That(customer.GreetMessage, Does.Match("Hello, [A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+"));
            });
        }

        [Test]
        public void GreetMessage_NotGreeted_ReturnsNull()
        {
            Assert.IsNull(customer.GreetMessage);
        }

        [Test]
        public void DiscountCheckDefaultCustomer_ResturnDiscountRange()
        {
            int result = customer.Discount;

            Assert.That(result, Is.InRange(10, 25));
        }

        [Test]
        public void GreetMessage_GreetWithoutLastName_ReturnNotNull()
        {
            customer.GreetAndCombineNames("ben", "");

            Assert.IsNotNull(customer.GreetMessage);
            Assert.IsFalse(string.IsNullOrEmpty(customer.GreetMessage));
        }

        [Test]
        public void GreetChecker_EmptyFirstName_ThrowException()
        {
            var exceptionDetails = Assert.Throws<ArgumentException>(() =>
            customer.GreetAndCombineNames("", "Spark"));

            Assert.AreEqual("Empty first name", exceptionDetails.Message);

            Assert.That(() => customer.GreetAndCombineNames("", "spark"),
                Throws.ArgumentException.With.Message.EqualTo("Empty first name"));

            //Just to chek if exception was thrown or not
            Assert.Throws<ArgumentException>(() =>
            customer.GreetAndCombineNames("", "Spark"));
        }

        [Test]
        public void CustomerType_CreateCustomerWIthLessThan100Order_ReturnBasicCustomer()
        {
            customer.OrderTotal = 10;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<BasicCustomer>());
        }

        [Test]
        public void CustomerType_CreateCustomerWIthMoreThan100Order_ReturnPlatinumCustomer()
        {
            customer.OrderTotal = 120;
            var result = customer.GetCustomerDetails();
            Assert.That(result, Is.TypeOf<PlatinumCustomer>());
        }
    }
}
