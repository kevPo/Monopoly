using Monopoly;
using Monopoly.Locations;
using Monopoly.TraditionalMonopoly;
using NUnit.Framework;

namespace MonopolyTests.LocationTests
{
    [TestFixture]
    public class PropertyTests
    {
        private IPlayer player;
        private Property property;
        private IBanker banker;

        [SetUp]
        public void SetUp()
        {
            player = new Player("horse", 2000);
            banker = new TraditionalBanker();
            property = new Property(39, "Boardwalk", 400, 50, banker);
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
            property.LandedOnBy(player);
            property.LandedOnBy(player);
            Assert.That(player.Balance, Is.EqualTo(1600));
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
