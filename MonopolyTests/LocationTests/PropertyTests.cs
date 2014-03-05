using Monopoly;
using Monopoly.Locations;
using NUnit.Framework;

namespace MonopolyTests.LocationTests
{
    [TestFixture]
    public class PropertyTests
    {
        private IPlayer player;
        private Property property;

        [SetUp]
        public void SetUp()
        {
            player = new Player("horse", 2000);
            property = new Property("Boardwalk", 400);
        }

        [Test]
        public void TestPlayerLandsOnUnownedPropertyAndBuysIt()
        {
            property.LandedOnBy(player);
            Assert.That(property.Owner.Name, Is.EqualTo("horse"));
            Assert.That(player.Balance, Is.EqualTo(1600));
        }

        [Test]
        public void TestLandOnPlayerLandsOnOwnedPropertyAndNothingHappens()
        {
            property.BoughtBy(player);
            property.LandedOnBy(player);
            Assert.That(player.Balance, Is.EqualTo(2000));
        }

        [Test]
        public void PassingOverUnownedPropertyShouldDoNothing()
        {
            property.PassedOverBy(player);
            Assert.That(player.Balance, Is.EqualTo(2000));
            Assert.That(property.Owner, Is.Null);
        }
    }
}
