using System.Collections.Generic;
using Monopoly.Banker;
using Monopoly.Locations.Propertys;
using Monopoly.Players;
using NUnit.Framework;

namespace MonopolyTests.LocationTests.PropertysTests
{
    [TestFixture]
    public class RailroadTests
    {
        private IPlayer car;
        private IPlayer horse;
        private Railroad readingRailroad;
        private Railroad pennsylvaniaRailroad;
        private Railroad boRailroad;
        private Railroad shortLineRailroad;
        private IBanker banker;

        [SetUp]
        public void SetUp()
        {
            car = new Player(0, "car");
            horse = new Player(1, "horse");
            banker = new TraditionalBanker(new [] { car.Id, horse.Id });
            var railroads = new List<Railroad>();
            readingRailroad = new Railroad(5, "Reading Railroad", 250, 25, banker, railroads); 
            pennsylvaniaRailroad = new Railroad(15, "Pennsylvania Railroad", 250, 25, banker, railroads);
            boRailroad = new Railroad(25, "B. & O. Railroad", 250, 25, banker, railroads);
            shortLineRailroad = new Railroad(35, "Short Line Railroad", 250, 25, banker, railroads);

            railroads.AddRange(new Railroad[] { readingRailroad, pennsylvaniaRailroad, boRailroad, shortLineRailroad });
        }

        [Test]
        public void TestRentForOneRailroadOwnerIs25()
        {
            readingRailroad.LandedOnBy(car.Id);
            readingRailroad.LandedOnBy(horse.Id);
            
            Assert.That(banker.GetBalanceFor(horse.Id), Is.EqualTo(1475));
        }

        [Test]
        public void TestRentForTwoRailRoadOwnerIs50()
        {
            readingRailroad.LandedOnBy(car.Id);
            pennsylvaniaRailroad.LandedOnBy(car.Id);

            pennsylvaniaRailroad.LandedOnBy(horse.Id);
            Assert.That(banker.GetBalanceFor(horse.Id), Is.EqualTo(1450));
        }

        [Test]
        public void TestRentForThreeRailroadsOwnedIs100()
        {
            readingRailroad.LandedOnBy(car.Id);
            pennsylvaniaRailroad.LandedOnBy(car.Id);
            boRailroad.LandedOnBy(car.Id);

            readingRailroad.LandedOnBy(horse.Id);
            Assert.That(banker.GetBalanceFor(horse.Id), Is.EqualTo(1400));
        }

        [Test]
        public void TestRentForFourRailroadsOwnedIs200()
        {
            readingRailroad.LandedOnBy(car.Id);
            pennsylvaniaRailroad.LandedOnBy(car.Id);
            boRailroad.LandedOnBy(car.Id);
            shortLineRailroad.LandedOnBy(car.Id);

            readingRailroad.LandedOnBy(horse.Id);
            Assert.That(banker.GetBalanceFor(horse.Id), Is.EqualTo(1300));
        }
    }
}
