using Monopoly;
using Monopoly.Locations.Taxable;
using NUnit.Framework;

namespace MonopolyTests.LocationTests
{
    [TestFixture]
    public class TaxLocationTests
    {
        private IncomeTax incomeTax;

        [SetUp]
        public void SetUp()
        {
            incomeTax = new IncomeTax(4, "Income Tax");
        }

        [Test]
        public void TestIncomeTaxCharges10PercentIfBalanceLessThan2000()
        {
            var player = new Player("Horse", 1800);
            incomeTax.LandedOnBy(player);
            Assert.That(player.Balance, Is.EqualTo(1620));
        }

        [Test]
        public void TestIncomeTaxCharges200IfBalanceGreaterThan2000()
        {
            var player = new Player("Horse", 2200);
            incomeTax.LandedOnBy(player);
            Assert.That(player.Balance, Is.EqualTo(2000));
        }

        [Test]
        public void TestIncomeTaxChargesNothingWhenBalanceIsZero()
        {
            var player = new Player("Horse", 0);
            incomeTax.LandedOnBy(player);
            Assert.That(player.Balance, Is.EqualTo(0));
        }

        [Test]
        public void TestIncomeTaxCharges200WhenBalanceIs2000()
        {
            var player = new Player("Horse", 2000);
            incomeTax.LandedOnBy(player);
            Assert.That(player.Balance, Is.EqualTo(1800));
        }
    }
}
