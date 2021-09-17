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
            string desiredOutput = "hello";

            logMock.Setup(x => x.MessageWIthReturrStr(It.IsAny<string>())).Returns((string str) => str.ToLower());
            Assert.That(logMock.Object.MessageWIthReturrStr("Hello"), Is.EqualTo(desiredOutput));
        }


        [Test]
        public void BankLogDummy_LogMockstringOutputString_ReturnsTrue()
        {
            var logMock = new Mock<ILogBook>();
            string desiredOutput = "hello";

            logMock.Setup(x => x.LogWithOutputResult(It.IsAny<string>(), out desiredOutput)).Returns(true);
            string result = "";
            Assert.IsTrue(logMock.Object.LogWithOutputResult("Ben", out result));
            Assert.That(result, Is.EqualTo(desiredOutput));
        }

        [Test]
        public void BankLogDummy_LogRefChecker_ReturnsTrue()
        {
            var logMock = new Mock<ILogBook>();
            Customer customer = new();
            Customer customerNotUsed = new();
            //Working with references

            logMock.Setup(x => x.LogWithREfObject(ref customer)).Returns(true);
            
            Assert.IsFalse(logMock.Object.LogWithREfObject(ref customerNotUsed));
            Assert.IsTrue(logMock.Object.LogWithREfObject(ref customer));
        }

        [Test]
        public void BankLogDummy_SetAndGetLogType_MockTest()
        {
            var logMock = new Mock<ILogBook>();

            logMock.Setup(x => x.LogSeverity).Returns(10);
            logMock.Setup(x => x.LogType).Returns("warning");
            //You cannot assign values to logMock like this
            logMock.Object.LogSeverity = 100;

            //only this way
           // logMock.SetupAllProperties();
            //logMock.Object.LogSeverity = 100;

            Assert.That(logMock.Object.LogSeverity, Is.EqualTo(10));
            Assert.That(logMock.Object.LogType, Is.EqualTo("warning"));


            //callbacks
            string logTemp = "Hello, ";
            logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true).Callback((string str) => logTemp +=str);
            logMock.Object.LogToDb("Ben");
            Assert.That(logTemp, Is.EqualTo("Hello, Ben"));


            //callbacks
            int counter = 5;
            logMock.Setup(u => u.LogToDb(It.IsAny<string>())).Returns(true).Callback(() => counter++);
            logMock.Object.LogToDb("Ben"); //if we call this 2 times counter will be 7
            Assert.That(counter, Is.EqualTo(6));
        }

        [Test]
        public void BankLogDummy_VerifyExample()
        {
            var logMock = new Mock<ILogBook>();
            BankAccount bankAccount = new(logMock.Object);
            bankAccount.Deposit(100);
            Assert.That(bankAccount.GetBalance, Is.EqualTo(100));

            //verifcation
            logMock.Verify(u => u.Message(It.IsAny<string>()), Times.Exactly(2));
            logMock.Verify(u => u.Message("Test"), Times.Once);
            logMock.VerifySet(u => u.LogSeverity = 101, Times.Once);//verifyget is available too
        }
    }
}
