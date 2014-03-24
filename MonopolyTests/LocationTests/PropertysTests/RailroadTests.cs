using System.Collections.Generic;
using Monopoly;
using Monopoly.Locations.Propertys;
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

        [SetUp]
        public void SetUp()
        {
            car = new Player("car", 2000);
            horse = new Player("horse", 2000);

            var railroads = new List<Railroad>();
            readingRailroad = new Railroad(5, "Reading Railroad", 250, 25, railroads); 
            pennsylvaniaRailroad = new Railroad(15, "Pennsylvania Railroad", 250, 25, railroads);
            boRailroad = new Railroad(25, "B. & O. Railroad", 250, 25, railroads);
            shortLineRailroad = new Railroad(35, "Short Line Railroad", 250, 25, railroads);

            railroads.AddRange(new Railroad[] { readingRailroad, pennsylvaniaRailroad, boRailroad, shortLineRailroad });
        }

        [Test]
        public void TestRentForOneRailroadOwnerIs25()
        {
            readingRailroad.LandedOnBy(car);
            readingRailroad.LandedOnBy(horse);
            
            Assert.That(horse.Balance, Is.EqualTo(1975));
        }

        [Test]
        public void TestRentForTwoRailRoadOwnerIs50()
        {
            readingRailroad.LandedOnBy(car);
            pennsylvaniaRailroad.LandedOnBy(car);

            pennsylvaniaRailroad.LandedOnBy(horse);
            Assert.That(horse.Balance, Is.EqualTo(1950));
        }

        [Test]
        public void TestRentForThreeRailroadsOwnedIs100()
        {
            readingRailroad.LandedOnBy(car);
            pennsylvaniaRailroad.LandedOnBy(car);
            boRailroad.LandedOnBy(car);

            readingRailroad.LandedOnBy(horse);
            Assert.That(horse.Balance, Is.EqualTo(1900));
        }

        [Test]
        public void TestRentForFourRailroadsOwnedIs200()
        {
            readingRailroad.LandedOnBy(car);
            pennsylvaniaRailroad.LandedOnBy(car);
            boRailroad.LandedOnBy(car);
            shortLineRailroad.LandedOnBy(car);

            readingRailroad.LandedOnBy(horse);
            Assert.That(horse.Balance, Is.EqualTo(1800));
        }
    }
}
