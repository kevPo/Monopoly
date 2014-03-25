using Monopoly;
using Monopoly.TraditionalMonopoly;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests.TraditionalMonopolyTests
{
    [TestFixture]
    public class TraditionalBoardFactoryTests
    {
        private FakeTraditionalBoardFactory fakeBoardFactory;

        [SetUp]
        public void SetUp()
        {
            fakeBoardFactory = new FakeTraditionalBoardFactory(new TraditionalDice(), new IPlayer[]{}, new TraditionalJailRoster());
        }

        [Test]
        public void TestIncomeTaxCharges10PercentIfBalanceLessThan2000()
        {
            var result = fakeBoardFactory.GetIncomeTaxResult(1500);
            Assert.That(result, Is.EqualTo(150));
        }

        [Test]
        public void TestIncomeTaxCharges200IfBalanceGreaterThan2000()
        {
            var result = fakeBoardFactory.GetIncomeTaxResult(2200);
            Assert.That(result, Is.EqualTo(200));
        }

        [Test]
        public void TestIncomeTaxChargesNothingWhenBalanceIsZero()
        {
            var result = fakeBoardFactory.GetIncomeTaxResult(0);
            Assert.That(result, Is.EqualTo(0));
        }

        [Test]
        public void TestIncomeTaxCharges200WhenBalanceIs2000()
        {
            var result = fakeBoardFactory.GetIncomeTaxResult(2000);
            Assert.That(result, Is.EqualTo(200));
        }

        [Test]
        public void TestLuxuryTaxCharges75Dollars()
        {
            var result = fakeBoardFactory.GetLuxuryTaxResult(2200);
            Assert.That(result, Is.EqualTo(75));
        }
        
    }
}
