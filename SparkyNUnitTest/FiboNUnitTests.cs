namespace Sparky
{
    using NUnit.Framework;
    using Sparky;
    using System.Collections.Generic;

    [TestFixture]
    public class FiboNUnitTests
    {
        Fibo fibo;
        [SetUp]
        public void SetUp()
        {
            fibo = new Fibo();
        }

        [Test]
        public void GetFibo_InputListRange1_GetOrderedNotEmpty()
        {

            fibo = new Fibo();
            fibo.Range = 1;
            List<int> expectedRange = new() { 0 };


            Assert.Multiple(() =>
            {
                Assert.That(fibo.GetFiboSeries(), Is.Not.Empty);
                Assert.That(fibo.GetFiboSeries(), Is.Ordered);
                Assert.AreEqual(fibo.GetFiboSeries(), expectedRange);
            });
        }


        [Test]
        public void GetFibo_InputListRange6_GetOrderedNotEmpty()
        {

            fibo = new Fibo();
            fibo.Range = 6;
            List<int> expectedRange = new() { 0, 1, 1, 2, 3, 5 };


            Assert.Multiple(() =>
            {
                Assert.That(fibo.GetFiboSeries(), Does.Contain(3));
                Assert.That(fibo.GetFiboSeries().Count, Is.EqualTo(6));
                Assert.That(fibo.GetFiboSeries(), Has.No.Member(4));
                Assert.AreEqual(fibo.GetFiboSeries(), expectedRange );

            });
        }
    }
}
