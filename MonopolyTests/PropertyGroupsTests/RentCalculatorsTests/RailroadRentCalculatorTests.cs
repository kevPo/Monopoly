using System.Collections.Generic;
using Monopoly;
using Monopoly.Locations;
using Monopoly.PropertyGroups.RentCalculators;
using MonopolyTests.Fakes;
using NUnit.Framework;

namespace MonopolyTests.PropertyGroupsTests.RentCalculatorsTests
{
    [TestFixture]
    public class RailroadRentCalculatorTests
    {
        private IPlayer car;
        private Property readingRailroad;
        private Property pennsylvaniaRailroad;
        private Property boRailroad;
        private Property shortLineRailroad;
        private IEnumerable<Property> properties;
        private RentCalculator rentCalculator;

        [SetUp]
        public void SetUp()
        {
            car = new Player("car", 2000);
            var banker = new FakeBanker();
            readingRailroad = new Property(5, "Reading Railroad", 200, 25, banker);
            pennsylvaniaRailroad = new Property(15, "Pennsylvania Railroad", 200, 25, banker);
            boRailroad = new Property(25, "B. & O. Railroad", 200, 25, banker);
            shortLineRailroad = new Property(35, "Short Line Railroad", 200, 25, banker);
            properties = new Property[]
            {
                readingRailroad, 
                pennsylvaniaRailroad, 
                boRailroad, 
                shortLineRailroad
            };
            rentCalculator = new RailroadRentCalculator();
        }

        [Test]
        public void TestRentForOneRailroadOwnerIs25()
        {
            readingRailroad.LandedOnBy(car);
            var rent = rentCalculator.CalculateRentFor(readingRailroad, properties);
            Assert.That(rent, Is.EqualTo(25));
        }

        [Test]
        public void TestRentForTwoRailRoadOwnerIs50()
        {
            readingRailroad.LandedOnBy(car);
            pennsylvaniaRailroad.LandedOnBy(car);
            var rent = rentCalculator.CalculateRentFor(readingRailroad, properties);
            Assert.That(rent, Is.EqualTo(50));
        }

        [Test]
        public void TestRentForThreeRailroadsOwnedIs100()
        {
            readingRailroad.LandedOnBy(car);
            pennsylvaniaRailroad.LandedOnBy(car);
            boRailroad.LandedOnBy(car);
            var rent = rentCalculator.CalculateRentFor(readingRailroad, properties);
            Assert.That(rent, Is.EqualTo(100));
        }

        [Test]
        public void TestRentForFourRailroadsOwnedIs200()
        {
            readingRailroad.LandedOnBy(car);
            pennsylvaniaRailroad.LandedOnBy(car);
            boRailroad.LandedOnBy(car);
            shortLineRailroad.LandedOnBy(car);
            var rent = rentCalculator.CalculateRentFor(readingRailroad, properties);
            Assert.That(rent, Is.EqualTo(200));
        }
    }
}
