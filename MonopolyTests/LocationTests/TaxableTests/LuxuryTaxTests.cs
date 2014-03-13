using Monopoly;
using Monopoly.Locations.Taxable;
using NUnit.Framework;

namespace MonopolyTests.LocationTests.TaxableTests
{
    [TestFixture]
    public class LuxuryTaxTests
    {
        [Test]
        public void TestLuxuryTaxCharges75Dollars()
        {
            var player = new Player("horse", 100);
            var luxuryTax = new LuxuryTax(38, "Luxury Tax");
            luxuryTax.LandedOnBy(player);
            Assert.That(player.Balance, Is.EqualTo(25));
        }
    }
}
