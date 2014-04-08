using System;
using Monopoly.Banker;
using Monopoly.Locations.Propertys;
using NUnit.Framework;

namespace MonopolyTests.LocationTests.PropertysTests
{
    [TestFixture]
    public class PropertyTests
    {
        private Int32 playerId;
        private IBanker banker;
        private Street mediterranean;

        [SetUp]
        public void SetUp()
        {
            playerId = 0;
            banker = new TraditionalBanker(new[] { playerId });
            mediterranean = new Street(1, "Mediterranean Avenue", 60, 2, banker, new Street[]{});
        }

        [Test]
        public void TestPlayerLandsOnUnownedPropertyAndBuysIt()
        {
            mediterranean.LandedOnBy(playerId);
            Assert.That(mediterranean.OwnerId, Is.EqualTo(playerId));
        }

        [Test]
        public void TestLandOnPlayerLandsOnOwnedPropertyAndNothingHappens()
        {
            mediterranean.LandedOnBy(playerId);
            mediterranean.LandedOnBy(playerId);
            Assert.That(banker.GetBalanceFor(playerId), Is.EqualTo(1440));
            Assert.That(mediterranean.OwnerId, Is.EqualTo(playerId));
        }

    }
}
