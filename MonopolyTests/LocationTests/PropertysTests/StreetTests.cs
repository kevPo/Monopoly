using System;
using System.Collections.Generic;
using Monopoly.Banker;
using Monopoly.Locations.Propertys;
using NUnit.Framework;

namespace MonopolyTests.LocationTests.PropertysTests
{
    [TestFixture]
    public class StreetTests
    {
        private Int32 playerOneId;
        private Int32 playerTwoId;
        private Street baltic;
        private Street mediterranean;
        private IBanker banker;

        [SetUp]
        public void SetUp()
        {
            playerOneId = 0;
            playerTwoId = 1;
            banker = new TraditionalBanker(new[] { playerOneId, playerTwoId });
            var purpleStreets = new List<Street>();
            mediterranean = new Street(1, "Mediterranean Avenue", 60, 2, banker, purpleStreets);
            baltic = new Street(3, "Baltic Avenue", 60, 4, banker, purpleStreets);

            purpleStreets.AddRange(new Street[] { mediterranean, baltic });
        }

        [Test]
        public void TestPlayerPaysRentValueWhenNotAllInGroupAreOwned()
        {
            baltic.LandedOnBy(playerOneId);

            baltic.LandedOnBy(playerTwoId);
            Assert.That(banker.GetBalanceFor(playerTwoId), Is.EqualTo(1496));
        }

        [Test]
        public void TestPlayerPaysTwiceTheRentValueWhenOwnerOwnsGroup()
        {
            baltic.LandedOnBy(playerOneId);
            mediterranean.LandedOnBy(playerOneId);

            baltic.LandedOnBy(playerTwoId);
            Assert.That(banker.GetBalanceFor(playerTwoId), Is.EqualTo(1492));
        }
    }
}
