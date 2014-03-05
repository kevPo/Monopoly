using Monopoly;
using Monopoly.Locations;
using NUnit.Framework;

namespace MonopolyTests.LocationTests
{
    [TestFixture]
    public class PropertyTests
    {
        [Test]
        public void TestPlayerLandsOnUnownedPropertyAndBuysIt()
        {
            var player = new Player("horse", 2000);
            var property = new Property("Boardwalk", 400);
            property.LandedOnBy(player);
            Assert.That(property.Owner.Name, Is.EqualTo("horse"));
            Assert.That(player.Balance, Is.EqualTo(1600));
        }
    }
}
