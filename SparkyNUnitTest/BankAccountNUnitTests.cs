namespace Sparky
{
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class BankAccountNUnitTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void BankDesposit_Add100_ReturnTrue()
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.Message(""));

            BankAccount bankAccount = new(logMock.Object);

            var result = bankAccount.Deposit(100);
            Assert.IsTrue(result);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));
        }

        [Test]
        [TestCase(200, 100)]
        [TestCase(200, 150)]
        public void BankWithdraw_Withdraw100With200Balance_ReturnsTrue(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.LogToDb(It.IsAny<string>())).Returns(true);

            logMock.Setup(x => x.LogBalanceAfterWithdrawl(It.Is<int>(x => x > 0))).Returns(true);

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(balance);

            var result = bankAccount.Withdraw(withdraw);
            Assert.IsTrue(result);
        }

        [Test]
        [TestCase(90, 100)]
        [TestCase(200, 300)]
        public void BankWithdraw_WithdrawMoreWithLessBalance_ReturnsFlase(int balance, int withdraw)
        {
            var logMock = new Mock<ILogBook>();
            logMock.Setup(x => x.LogToDb(It.IsAny<string>())).Returns(true);

            logMock.Setup(x => x.LogBalanceAfterWithdrawl(It.Is<int>(x => x > 0))).Returns(true);
            // logMock.Setup(x => x.LogBalanceAfterWithdrawl(It.Is<int>(x => x < 0))).Returns(false);
            logMock.Setup(x => x.LogBalanceAfterWithdrawl(It.IsInRange<int>(int.MinValue, -1, Moq.Range.Inclusive)))
                .Returns(false);

            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(balance);

            var result = bankAccount.Withdraw(withdraw);
            Assert.IsFalse(result);
        }

        [Test]
        public void BankLogDummy_LogMockstring_ReturnsTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "Hello";

            logMock.Setup(x => x.MessageWIthReturrStr(It.IsAny<string>())).Returns((string str) => str.ToLower());
            Assert.That(logMock.Object.MessageWIthReturrStr("HeLlo"), Is.EqualTo(desiredOutput));
        }
    }
}
