using System;
using System.Collections.Generic;
using Monopoly.Banker;
using Monopoly.Locations.Propertys;
using NUnit.Framework;

namespace MonopolyTests.LocationTests.PropertysTests
{
    [TestFixture]
    public class RailroadTests
    {
        private Int32 playerOneId;
        private Int32 playerTwoId;
        private Railroad readingRailroad;
        private Railroad pennsylvaniaRailroad;
        private Railroad boRailroad;
        private Railroad shortLineRailroad;
        private IBanker banker;

        [SetUp]
        public void SetUp()
        {
            playerOneId = 0;
            playerTwoId = 1;
            banker = new TraditionalBanker(new [] { playerOneId, playerTwoId });
            var railroads = new List<Railroad>();
            readingRailroad = new Railroad(5, "Reading Railroad", 250, 25, banker, railroads); 
            pennsylvaniaRailroad = new Railroad(15, "Pennsylvania Railroad", 250, 25, banker, railroads);
            boRailroad = new Railroad(25, "B. & O. Railroad", 250, 25, banker, railroads);
            shortLineRailroad = new Railroad(35, "Short Line Railroad", 250, 25, banker, railroads);

            railroads.AddRange(new Railroad[] 
                { readingRailroad, pennsylvaniaRailroad, boRailroad, shortLineRailroad });
        }

        [Test]
        public void TestRentForOneRailroadOwnerIs25()
        {
            readingRailroad.LandedOnBy(playerOneId);
            readingRailroad.LandedOnBy(playerTwoId);
            
            Assert.That(banker.GetBalanceFor(playerTwoId), Is.EqualTo(1475));
        }

        [Test]
        public void TestRentForTwoRailRoadOwnerIs50()
        {
            readingRailroad.LandedOnBy(playerOneId);
            pennsylvaniaRailroad.LandedOnBy(playerOneId);

            pennsylvaniaRailroad.LandedOnBy(playerTwoId);
            Assert.That(banker.GetBalanceFor(playerTwoId), Is.EqualTo(1450));
        }

        [Test]
        public void TestRentForThreeRailroadsOwnedIs100()
        {
            readingRailroad.LandedOnBy(playerOneId);
            pennsylvaniaRailroad.LandedOnBy(playerOneId);
            boRailroad.LandedOnBy(playerOneId);

            readingRailroad.LandedOnBy(playerTwoId);
            Assert.That(banker.GetBalanceFor(playerTwoId), Is.EqualTo(1400));
        }

        [Test]
        public void TestRentForFourRailroadsOwnedIs200()
        {
            readingRailroad.LandedOnBy(playerOneId);
            pennsylvaniaRailroad.LandedOnBy(playerOneId);
            boRailroad.LandedOnBy(playerOneId);
            shortLineRailroad.LandedOnBy(playerOneId);

            readingRailroad.LandedOnBy(playerTwoId);
            Assert.That(banker.GetBalanceFor(playerTwoId), Is.EqualTo(1300));
        }
    }
}
